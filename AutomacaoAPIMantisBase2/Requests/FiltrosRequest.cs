using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class FiltrosRequest : RequestBase
    {
        public FiltrosRequest()
        {
            requestService = "/api/rest/filters/";
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public FiltrosRequest(int filter, Method metodo)
        {
            requestService = "/api/rest/filters/" + filter;
            method = metodo;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody()
        {
            
        }
    }
}
