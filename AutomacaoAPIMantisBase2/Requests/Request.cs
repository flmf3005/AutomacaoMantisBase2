using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class Request : RequestBase
    {
        public Request()
        {
            requestService = "/api/rest/projects/";
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody()
        {
            
        }
    }
}
