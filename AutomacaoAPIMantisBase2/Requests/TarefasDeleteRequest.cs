using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class TarefasDeleteRequest : RequestBase
    {
        string files = string.Empty;

        public TarefasDeleteRequest(string id)
        {
            requestService = "/api/rest/issues/" + id;
            method = Method.DELETE;
            httpBasicAuthenticator = true;
        }
    }
}
