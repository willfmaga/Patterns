using Microsoft.SqlServer.Server;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RedisAnimals.Filters;

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisAnimals.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Cache(true, Expiracao = 300, ResponseType = typeof(ResponseHTTP))]
        public IHttpActionResult Get(int id)
        {
            var animal = new Animal() { name = "Leão" };
            return Ok(new ResponseHTTP { isSucesso = true, Resultado = JsonConvert.SerializeObject(animal) });
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public class ResponseHTTP
        {
            public bool isSucesso { get; set; } = false;
            public string Resultado { get; set; }
        }

        public class Animal
        {
            public string name { get; set; }
        }
    }
}
