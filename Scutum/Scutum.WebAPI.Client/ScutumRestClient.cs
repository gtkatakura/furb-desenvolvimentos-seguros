using RestSharp;
using System;

namespace Scutum.WebAPI.Client
{
    public class ScutumRestClient : RestClient
    {
        public ScutumRestClient(string baseUrl)
            : base(baseUrl)
        { }

        public ScutumRestClient(Uri baseUrl)
            : base(baseUrl)
        { }

        public void Authenticate(string username, string password)
        {
            base.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public void Deauthenticate()
        {
            base.Authenticator = null;
        }
    }
}