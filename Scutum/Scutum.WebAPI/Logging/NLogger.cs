using NLog;

namespace Scutum.WebAPI.Logging
{
    internal static class NLogger
    {
        public static Logger Instance { get; private set; }

        static NLogger()
        {
            Instance = LogManager.GetCurrentClassLogger();
        }
    }
}