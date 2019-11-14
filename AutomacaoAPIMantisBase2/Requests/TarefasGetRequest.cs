using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class TarefasGetRequest : RequestBase
    {
        public TarefasGetRequest()
        {
            requestService = "/api/rest/issues/";
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public TarefasGetRequest(string issue)
        {
            requestService = "/api/rest/issues/" + issue;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public TarefasGetRequest(int project)
        {
            requestService = "/api/rest/issues/?project_id=" + project;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public TarefasGetRequest(string filter, bool filtro)
        {
            requestService = "/api/rest/issues?filter_id=" + filter;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }
    }
}
