namespace MasMovil.Componentes.Citaciones.Shared.Utils.Redis
{
    using Microsoft.Extensions.Configuration;
    using StackExchange.Redis;
    using System;
    using System.IO;
    using System.Linq;
   
    public static class ConnectionManager
    {
        private static string ConnectionString;

        static ConnectionManager()
        {
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        /*  var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{enviroment}.json", true)
                .Build();
                
            ConnectionString = config["ConnectionString:RedisConnectionString"];*/
        }

        private static string ServerName
        {
            get
            {
                return ConnectionString.Split(Convert.ToChar(",")).First().Split(Convert.ToChar(":")).First();
            }
        }

        private static int ServerPort
        {
            get
            {
                var server = ConnectionString.Split(Convert.ToChar(",")).First();
                if (server.Split(Convert.ToChar(":")).Count() > 1)
                {
                    return Convert.ToInt32(server.Split(Convert.ToChar(":")).Last());
                }
                return 6379;
            }
        }

        public static int DefaultDatabase
        {
            get
            {
                int databaseIndex = 0;
                var defaultDatabase = ConnectionString.Split(Convert.ToChar(",")).FirstOrDefault(t => t.Contains("defaultDatabase"));
                if (string.IsNullOrEmpty(defaultDatabase))
                {
                    return databaseIndex;
                }

                Int32.TryParse(defaultDatabase.Split(Convert.ToChar("=")).Last(), out databaseIndex);
                return databaseIndex;
            }
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConnectionString);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        public static IServer GetServer()
        {
            return Connection.GetServer(ServerName, ServerPort);
        }
    }
}
