namespace MasMovil.Componentes.Citaciones.Shared.Utils.Helpers
{
    using MasMovil.Componentes.Citaciones.Shared.Models.Enums;
    using MasMovil.Componentes.Citaciones.Shared.Models.Redis;
    using MasMovil.Componentes.Citaciones.Shared.Utils.Redis;
    using Microsoft.ApplicationInsights;
    using Newtonsoft.Json;
    using StackExchange.Redis;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    public static class CacheHelper
    {
        static IDatabase cache = ConnectionManager.Connection.GetDatabase();
        static readonly TelemetryClient telemetryClient = new TelemetryClient();

        public static CacheObject<T> GetInsert<T>(Expression<Func<T>> getFunction, ExpiryTime expiry) where T : class
        {
            var key = RedisKeysGenerator.GenerateKey(getFunction);
            return GetInsert(key, getFunction.Compile(), expiry);
        }

        internal static object GetInsert(Func<object> p, ExpiryTime day)
        {
            throw new NotImplementedException();
        }

        public static CacheObject<T> GetInsert<T>(Expression<Func<T>> getFunction) where T : class
        {
            var key = RedisKeysGenerator.GenerateKey(getFunction);
            return GetInsert(key, getFunction.Compile(), ExpiryTime.None);
        }

        public static async Task<CacheObject<T>> GetInsertAsync<T>(Expression<Func<Task<T>>> getFunction, ExpiryTime expiry) where T : class
        {
            var key = RedisKeysGenerator.GenerateKey(getFunction);
            return await GetInsert(key, getFunction.Compile(), expiry).ConfigureAwait(false);
        }

        public static async Task<CacheObject<T>> GetInsertAsync<T>(Expression<Func<Task<T>>> getFunction) where T : class
        {
            var key = RedisKeysGenerator.GenerateKey(getFunction);
            return await GetInsert(key, getFunction.Compile(), ExpiryTime.None).ConfigureAwait(false);
        }

        public static async Task<CacheObject<T>> GetInsertAsync<T>(Expression<Func<Task<T>>> getFunction, string applicationName, ExpiryTime expiry) where T : class
        {
            var key = RedisKeysGenerator.GenerateKey(getFunction, applicationName);
            return await GetInsert(key, getFunction.Compile(), expiry).ConfigureAwait(false);
        }

        public static async Task<CacheObject<T>> GetInsertAsync<T>(Expression<Func<Task<T>>> getFunction, string applicationName) where T : class
        {
            var key = RedisKeysGenerator.GenerateKey(getFunction, applicationName);
            return await GetInsert(key, getFunction.Compile(), ExpiryTime.None).ConfigureAwait(false);
        }

        public static void ClearDatabase(int databaseIndex)
        {
            ConnectionManager.GetServer().FlushDatabase(databaseIndex);
        }

        public static void ClearDatabaseFilter(string pattern)
        {
            try
            {
                var keys = ConnectionManager.GetServer().Keys(cache.Database, pattern + "*").ToArray();
                cache.KeyDelete(keys);
            }
            catch (Exception ex)
            {
                AppInsightsHelper.TrackException(ex);
            }
        }

        public static CacheObject<T> Get<T>(string key, Func<T> getFunction) where T : class
        {
            var value = GetValue(key);

            if (value.IsNullOrEmpty || value == RedisValue.Null)
            {
                return GetCacheObject(getFunction(), false);
            }
            else
            {
                return GetCacheObject(JsonConvert.DeserializeObject<T>(value), true);
            }
        }

        public static void Insert<T>(string key, T value, int expiry) where T : class
        {
            SetValue(key, value, expiry);
        }

        public static CacheObject<T> Get<T>(string key) where T : class
        {
            var value = GetValue(key);

            if (value.IsNullOrEmpty || value == RedisValue.Null)
            {
                return GetCacheObject(default(T), false);
            }
            else
            {
                return GetCacheObject(JsonConvert.DeserializeObject<T>(value), true);
            }
        }

        static CacheObject<T> GetInsert<T>(string key, Func<T> getFunction, ExpiryTime expiry) where T : class
        {
            var value = GetValue(key);

            if (value.IsNullOrEmpty || value == RedisValue.Null)
            {
                var dbValue = getFunction();
                SetValue(key, dbValue, expiry);
                return GetCacheObject(dbValue, false);
            }
            else
            {
                return GetCacheObject(JsonConvert.DeserializeObject<T>(value), true);
            }
        }

        static async Task<CacheObject<T>> GetInsert<T>(string key, Func<Task<T>> getFunction, ExpiryTime expiry) where T : class
        {
            var value = GetValue(key);

            if (value.IsNullOrEmpty || value == RedisValue.Null)
            {
                var dbValue = await getFunction().ConfigureAwait(false);
                SetValue(key, dbValue, expiry);
                return GetCacheObject(dbValue, false);
            }
            else
            {
                return GetCacheObject(JsonConvert.DeserializeObject<T>(value), true);
            }
        }

        static RedisValue GetValue(string key)
        {
            var timer = GetTimerInfo();
            try
            {
                var value = cache.StringGet(key);
                ManageOk(timer, "StringGet", $"({key})");
                return value;
            }
            catch (Exception ex)
            {
                ManageException(ex, timer, "StringGet", $"({key})");
                return RedisValue.Null;
            }
        }

        static void SetValue<T>(string key, T value, int expiry) where T : class
        {
            SetValue(key, value, GetExpiryTime(expiry));
        }

        static void SetValue<T>(string key, T value, ExpiryTime expiry) where T : class
        {
            SetValue(key, value, GetExpiryTime(expiry));
        }

        static void SetValue<T>(string key, T value, TimeSpan? expiry) where T : class
        {
            var timer = GetTimerInfo();
            try
            {
                cache.StringSet(key, JsonConvert.SerializeObject(value), expiry: expiry);
                ManageOk(timer, "StringSet", $"({key})");
            }
            catch (Exception ex)
            {
                ManageException(ex, timer, "StringSet", $"({key})");
            }
        }

        static TimeSpan? GetExpiryTime(ExpiryTime expiry)
        {
            TimeSpan? timeSpan = null;
            if (expiry != ExpiryTime.None)
            {
                timeSpan = TimeSpan.FromMinutes((int)expiry);
            }
            return timeSpan;
        }

        static TimeSpan? GetExpiryTime(int expiry)
        {
            return TimeSpan.FromMinutes(expiry);
        }

        static void ManageException(Exception ex, TimerInfo timer, string dependencyName, string data)
        {
            AppInsightsHelper.TrackException(ex);
            ManageException(timer, dependencyName, data);
        }

        static void ManageException(TimerInfo timer, string dependencyName, string data)
        {
            timer.Watch.Stop();
            telemetryClient.TrackDependency("Redis", cache.Multiplexer.Configuration.Split(',')[0], dependencyName, data, timer.StarTime, timer.Watch.Elapsed, "500", false);
        }

        static void ManageOk(TimerInfo timer, string dependencyName, string data)
        {
            timer.Watch.Stop();
            telemetryClient.TrackDependency("Redis", cache.Multiplexer.Configuration.Split(',')[0], dependencyName, data, timer.StarTime, timer.Watch.Elapsed, "200", true);
        }

        static TimerInfo GetTimerInfo()
        {
            var info = new TimerInfo()
            {
                Watch = new Stopwatch(),
                StarTime = DateTime.Now
            };
            info.Watch.Start();
            return info;
        }

        static CacheObject<T> GetCacheObject<T>(T value, bool isFromCache) where T : class
        {
            return new CacheObject<T>()
            {
                Value = value,
                IsFromCache = isFromCache,
            };
        }

        private class TimerInfo
        {
            public Stopwatch Watch { get; set; }
            public DateTime StarTime { get; set; }
        }
    }
}
