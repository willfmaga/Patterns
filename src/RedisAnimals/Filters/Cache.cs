using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using Swashbuckle.Swagger;
using RedisAnimals.Helpers;

namespace RedisAnimals.Filters
{
    public class Cache : ActionFilterAttribute, IOperationFilter
    {

        public int DB = -1;

        /// <summary>
        /// Expiração do Cache em Segundos, padrão 3600 segundo (1 hora)
        /// </summary>
        public int Expiracao = 60;
        private string KEY { get; set; }
        private bool PerUser { get; set; }
        public string[] HeaderParameter { get; set; }
        public bool ForceExpiration { get; set; }
        public Type ResponseType { get; set; }

        public Cache(string Key)
        {
            KEY = Key;
        }

        /// <summary>
        /// Inclui na composição da chave do cache, o username
        /// </summary>
        /// <param name="perUser"></param>
        public Cache(bool perUser = true)
        {
            PerUser = perUser;
        }

        /// <summary>
        /// Inclui na composição de chave do cache parametros de header
        /// </summary>
        /// <param name="headerParameter"></param>
        public Cache(string[] headerParameter = null)
        {
            HeaderParameter = headerParameter;
        }

        public Cache() { }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (actionContext.Request.Method != HttpMethod.Get)
            {
                throw new Exception("Cache só pode ser configurado para HTTP Method GET");
            }

            try
            {

                var Environment = ConfigurationManager.AppSettings["Cache.Environment"];

                var ignoreCache = HttpContext.Current?.Request?.Headers?.GetValues("Edenred-Ignore-Cache")?.GetValue(0)?.ToString()?.ToLower()?.Equals("true") ?? false;
                if ((Environment.Equals("challenge") ||
                     Environment.Equals("staging")||
                     Environment.Equals("development"))
                    && ignoreCache)
                {
                    return;
                }

                //TODO: Abstrair no DI
                IDatabase cache = RedisHelper.Connection.GetDatabase(db: DB);

                //Monta a key automática se não houver.
                string cacheKey = string.IsNullOrEmpty(KEY)
                    ? actionContext.Request.RequestUri.PathAndQuery
                    : KEY;

                //Adiciona parametro de header na chave do cache
                if (HeaderParameter != null)
                {
                    foreach (var header in HeaderParameter)
                    {
                        if (actionContext.Request.Headers != null && actionContext.Request.Headers.TryGetValues(header, out var values))
                        {
                            cacheKey = string.Concat(string.Join("", values), ":", cacheKey);
                        }
                    }
                }

                //Adiciona o nome do usuário na chave do cache.
                if (PerUser)
                {
                    var user = HttpContext.Current?.User?.Identity?.Name ?? throw new Exception("Usuário não informado, não foi possível incluir no cache");
                    cacheKey = string.Concat(user, ":", cacheKey);
                }

                //Adiciona o ambiente na chave do cache
                cacheKey = string.Concat(Environment, ":", cacheKey);

                var responseCache = cache.StringGet(new RedisKey(cacheKey));

                if (responseCache.HasValue)
                {

                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Content = new StringContent(responseCache)
                    };

                    actionContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    actionContext.Response.Headers.Add("Edenred-Cache", "true");

                    if (ForceExpiration)
                        cache.KeyDelete(new RedisKey(cacheKey));

                    return;
                }

                actionContext.Request.Headers.Add("Edenred-Cache-Key", cacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

            try
            {

                if (actionExecutedContext.Response == null ||
                        !actionExecutedContext.Response.IsSuccessStatusCode ||
                            actionExecutedContext.Response.Content == null)
                {
                    return;
                }

                var cacheKey = actionExecutedContext.Request.Headers.Contains("Edenred-Cache-Key") ?
                        actionExecutedContext.Request.Headers.GetValues("Edenred-Cache-Key").ToList().FirstOrDefault()
                        : string.Empty;

                if (string.IsNullOrEmpty(cacheKey))
                {
                    return;
                }

                IDatabase cache = RedisHelper.Connection.GetDatabase(db: DB);
                var responseObject = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;

                if (ResponseType != null)
                {
                    var jsonObject = JObject.Parse(responseObject);
                    var isSucesso = bool.TryParse(jsonObject["isSucesso"]?.ToString(), out var isSucessoConverted) ? isSucessoConverted : false;

                    if (!isSucesso)
                    {
                        return;
                    }
                }

                cache.StringSet(new RedisKey(cacheKey), responseObject, expiry: new TimeSpan(0, 0, Expiracao));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            base.OnActionExecuted(actionExecutedContext);
        }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {

        }
    }
}