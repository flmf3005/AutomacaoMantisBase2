using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class NotasDeleteRequest : RequestBase
    {
        string files = string.Empty;

        public NotasDeleteRequest(string id, string note)
        {
            requestService = "/api/rest/issues/" + id + "/notes/" + note;
            method = Method.DELETE;
            httpBasicAuthenticator = true;
        }
    }
}
