using Betting.Common.Helpers.IHelpers;
using Betting.Common.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace Betting.Common.Helpers
{
    public class RedisCacheHelper : ICacheHelper
    {
        private static Lazy<ConnectionMultiplexer> connection;
        static object connectLock = new object();

        public RedisCacheHelper(IOptions<AppSettingsModel> settings)
        {
            if (connection == null)
            {
                connection = new Lazy<ConnectionMultiplexer>(() =>
                {
                    return ConnectionMultiplexer.Connect(settings.Value.RedisConnectionString);
                });
            }
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return connection.Value;
            }
        }

        public T GetData<T>(string key)
        {
            try
            {
                var database = Connection.GetDatabase();
                var cacheValue = database.StringGet(key);

                if(!String.IsNullOrWhiteSpace(cacheValue))
                {
                    var result = JsonConvert.DeserializeObject<T>(cacheValue);
                    return result;
                }

                return default(T);
            }
            catch (Exception ex)
            {
                //Log

                return default(T);
            }
        }

        public void SetData<T>(string key, T data)
        {
            try
            {
                var database = Connection.GetDatabase();
                var json = JsonConvert.SerializeObject(data);

                var cacheValue = database.StringSet(key, json);
            }
            catch (Exception ex)
            {
                //Log

            }
        }
    }
}
