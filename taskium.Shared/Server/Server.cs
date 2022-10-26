using System;
using TaskiumRestAPI.Api;

namespace taskium
{
    public static class Server
    {
        private static TaskiumServerApi api = null;
        public static TaskiumServerApi Calls {
            get {
                return Server.ApiFactory();
            }
        }

        private static TaskiumServerApi ApiFactory()
        {
            if (Server.api == null) {
                var host = Environment
                    .GetEnvironmentVariable("TASKIUM_SERVER_HOST");
                if (string.IsNullOrEmpty(host)) 
                    throw new Exception("TASKIUM_SERVER_HOST not set");

                var port = Environment
                    .GetEnvironmentVariable("TASKIUM_SERVER_PORT");
                if (string.IsNullOrEmpty(port)) 
                    throw new Exception("TASKIUM_SERVER_PORT not set");

                Server.api = new($"http://{host}:{port}");
            }

            return Server.api;
        }
    }
}
