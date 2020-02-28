﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace Project.CrossCutting.SettingsInjection
{
    public class SettingsInjection
    {
        private static IConfigurationRoot _config = null;

        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_config == null)
                {
                    _config = InjectSettings();
                }

                return _config;
            }
        }


        private static IConfigurationRoot InjectSettings()
        {
            try
            {
                //diretório de execução do projeto
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).ToString();
                basePath = basePath.Replace(@"file:\", "");

                //injeção de dependencia do arquivo appsettings.json
                var builder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json");

                return builder.Build();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
