using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class LangRequest : RequestBase
    {
        public LangRequest(string lang)
        {
            requestService = "/api/rest/lang?string=" + lang;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public LangRequest(List<string> langs)
        {
            string text = null;
            foreach(string lang in langs)
            {
                text = text + "string[]=" + lang + "&";
            }

            requestService = "/api/rest/lang?" + text;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }
    }
}
