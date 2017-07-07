using System;

namespace _10412.ParseURL
{
    class ParseURL
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            string protocol = GetProtocol(url);
            string server = GetServer(url);
            string resource = GetResource(url);
            Console.WriteLine(protocol);
            Console.WriteLine(server);
            Console.WriteLine(resource);
        }

        public static string GetProtocol(string url)
        {
            int endIndex = url.IndexOf("://");
            string protocol = url.Substring(0, endIndex);
            return "[protocol] = " + protocol;
        }

        public static string GetServer(string url)
        {
            int protocolEndIndex = url.IndexOf("://")+3;
            int serverIndex = url.IndexOf('/', protocolEndIndex);
            string protocol = url.Substring(protocolEndIndex, serverIndex - protocolEndIndex);
            return "[server] = " + protocol;
        }

        public static string GetResource(string url)
        {
            int protocolEndIndex = url.IndexOf("://") + 3;
            int serverEndIndex = url.IndexOf('/', protocolEndIndex);
            string resource = url.Substring(serverEndIndex);
            return "[resource] = " + resource;
        }
    }
}
