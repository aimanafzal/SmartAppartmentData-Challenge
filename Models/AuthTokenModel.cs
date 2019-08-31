using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace backend_challenge_api.Model
{
    public class Auth
    {
        IConfigurationBuilder _builder;
        IConfigurationRoot _configuration;
        public Auth()
        {
            _builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");
            _configuration = _builder.Build();

        }
        public string getAuthBaseURI
        {
            get { return _configuration["Auth0:baseuri"]; }
        }
        public string getClientID
        {
            get { return _configuration["Auth0:client_id"]; }

        }
    }

}