using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class ConfigRequest : RequestBase
    {
        public ConfigRequest(string config)
        {
            requestService = "/api/rest/config?option=" + config;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public ConfigRequest(List<string> configs)
        {
            string text = null;
            foreach(string config in configs)
            {
                text = text + "option[]=" + config + "&";
            }

            requestService = "/api/rest/config?" + text;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }
    }
}
