using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication21.Models
{
    public class paypalconfig
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static paypalconfig()
        {
            var Config = getconfig();
            clientId = Config["clientId"];
            clientSecret = Config["clientSecret"];
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            var aPIContext = new APIContext(GetAccessToken());
            aPIContext.Config = getconfig();
            return aPIContext;
        }

    }
}