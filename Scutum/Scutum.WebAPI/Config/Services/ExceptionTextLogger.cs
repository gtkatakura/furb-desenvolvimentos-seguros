using Scutum.WebAPI.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Scutum.WebAPI.Config.Services
{
    public class ExceptionTextLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            NLogger.Instance.ErrorException(String.Empty, context.Exception);
            base.Log(context);
        }
    }
}