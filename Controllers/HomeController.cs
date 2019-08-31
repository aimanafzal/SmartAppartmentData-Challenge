using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace backend_challenge_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {


        [HttpGet("connect")]
        public ActionResult Get_ConnectToAuth0()
        {
            AuthTokenController authController = new AuthTokenController();
            IRestResponse response = authController.getResponseFromAuth0();
            HttpCookie cookie = null;
            if (response.IsSuccessful)
            {
                cookie = new HttpCookie()
                {
                    Value = response.Content
                };
                HttpContext.Session.SetString("responseContent", response.Content);
                return StatusCode(Convert.ToInt32(response.StatusCode), response.Content);
            }
            else
                return StatusCode(Convert.ToInt32(response.StatusCode), response.ErrorMessage);
        }
    }
}
