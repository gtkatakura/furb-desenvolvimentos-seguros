using Scutum.Business;
using Scutum.Model;
using System;
using System.Threading;

namespace Scutum.WebAPI.Helper
{
    public static class IdentityUtil
    {
        public static string GetUsername()
        {
            return Thread.CurrentPrincipal.Identity.Name;
        }

        public static Model.Usuario GetUser()
        {
            return new Business.Usuario().Find(GetUsername());
        }

        public static string[] GetRoles(Model.Usuario user)
        {
            return user.Nivel.ToString().Split(new string[] { ", " }, StringSplitOptions.None);
        }
    }
}