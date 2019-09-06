using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Jose;
using JWT;
using JWT.Models;

namespace JWT.Controllers
{
    public class TokenController : ApiController
    {
        public object Post(LoginData model)
        {
            var secret = WebConfigurationManager.AppSettings["JWTSalt"].ToString();

            if (model.UserName == "andy" && model.Password == "abcd")
            {
                //TODO 可擴充自己要的欄位
                var payload = new JwtAuthObject()
                {
                    Id = model.UserName,
                    Expiration = DateTime.Now.AddHours(3),
                    Name = model.UserName
                };

                return new
                {
                    Result = true,
                    token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS256)
                };
            }
            else
            {
                throw new UnauthorizedAccessException("帳密錯誤");
            }
        }
    }

    public class LoginData
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
