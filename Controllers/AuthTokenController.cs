using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_challenge_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
// using RestClientDotNet;
// using RestRequest;
using RestSharp;

namespace backend_challenge_api.Controllers
{

    public class AuthTokenController
    {
        public AuthTokenController()
        {
        }
        public IRestResponse getResponseFromAuth0()
        {
            try
            {
                Auth credentials = new Auth();
                string baseURI = credentials.getAuthBaseURI;
                string client_id = credentials.getClientID;
                var client = new RestSharp.RestClient(baseURI);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", client_id, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;

            }
            catch (System.Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}