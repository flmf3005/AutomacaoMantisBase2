using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class ArquivosTarefasGetRequest : RequestBase
    {
        public ArquivosTarefasGetRequest(int issue)
        {
            requestService = "/api/rest/issues/" + issue + "/files/";
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public ArquivosTarefasGetRequest(int issue, int file)
        {
            requestService = "/api/rest/issues/" + issue + "/files/" + file;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }
    }
}
