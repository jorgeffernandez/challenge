namespace Challenge.Shared.Utils
{
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;

    public static class Common
    {
        public static string GetIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = host.AddressList.FirstOrDefault(i => i.AddressFamily == AddressFamily.InterNetwork);

            return (ipAddress == null) ? string.Empty : ipAddress.ToString();
        }
    }
}