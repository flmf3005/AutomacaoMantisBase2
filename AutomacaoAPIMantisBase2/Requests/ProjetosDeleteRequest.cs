using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class ProjetosDeleteRequest : RequestBase
    {
        public ProjetosDeleteRequest(int project)
        {
            requestService = "/api/rest/projects/" + project;
            method = Method.DELETE;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody()
        {
            
        }
    }
}
