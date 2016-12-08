using Scutum.Business;
using Scutum.Library.Helper;
using Scutum.Model;
using System;
using System.Net.Http.Headers;

namespace Scutum.WebAPI.Config.Security
{
    public static class AuthorizationUtil
    {
        private static string scheme = "Basic";
        public readonly static AuthenticationHeaderValue AuthenticationHeader = new AuthenticationHeaderValue(scheme);

        public static bool IsValid(AuthenticationHeaderValue header, out Model.Usuario user)
        {
            user = null;

            if (header != null && header.Scheme == scheme)
            {
                var credentials = header.Parameter;

                if (!String.IsNullOrWhiteSpace(credentials))
                {
                    var decodedCredentials = credentials.FromBase64String();

                    var separator = decodedCredentials.IndexOf(':');
                    var username = decodedCredentials.Left(separator);
                    var password = decodedCredentials.Substring(separator + 1);

                    user = new Business.Usuario().Find(username, password);

                    return user != null;
                }
            }

            return false;
        }
    }
}