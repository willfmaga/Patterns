using StackExchange.Redis;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RedisAnimals.Helpers
{
    public class RedisHelper
    {
        private static readonly TimeSpan expiry = TimeSpan.FromMinutes(15);

        public enum DataBase : int
        {
            DadosUsuario = 0,
            DadosAplicacao = 1
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var cacheConnection = ConfigurationManager.AppSettings["Cache.Connection"];
            var options = ConfigurationOptions.Parse(cacheConnection);
            options.AbortOnConnectFail = false;
            options.ReconnectRetryPolicy = new LinearRetry(5000);
            var resultado = ConnectionMultiplexer.Connect(options);

            return resultado;
        });

        private static Lazy<ConnectionMultiplexer> abortOnConnectFailConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var cacheConnection = ConfigurationManager.AppSettings["Cache.Connection"];
            var options = ConfigurationOptions.Parse(cacheConnection);
            options.AbortOnConnectFail = true;
            options.ReconnectRetryPolicy = new LinearRetry(1000);
            return ConnectionMultiplexer.Connect(options);
        });

        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        public static ConnectionMultiplexer AbortOnConnectFailConnection => abortOnConnectFailConnection.Value;
        
        public static bool IsDevRedis => ConfigurationManager.AppSettings["Ambiente"] == "DESENVOLVIMENTO LOCAL";
    }
}