using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestSharpDemo.BaseConfig
{
   public static class ConfigData
    {
        private static string hostName;
        private static string guid;
        private static string productid;
        private static string moduleid;
        private static string clientid;

        public static IConfigurationRoot Configuration;

        public static void LoadConfigData()
        {
            var configDataBuilder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("AppConfig.json");
            Configuration = configDataBuilder.Build();

            ConfigData.HostName = Configuration["hostName"];
            ConfigData.guid = Configuration["guid"];

            ConfigData.productid = Configuration["productId"];
            ConfigData.moduleid = Configuration["moduleId"];
            ConfigData.clientid = Configuration["clientId"];



        }

        public static string HostName  { get => hostName; set=> hostName = value; }
        public static string Guid { get => guid; set => guid = value; }
        public static string ProductId { get => productid; set => guid = productid; }

        public static string ModuleId { get => moduleid; set => guid = moduleid; }

        public static string ClientId { get => clientid; set => guid = moduleid; }




    }
    
}
