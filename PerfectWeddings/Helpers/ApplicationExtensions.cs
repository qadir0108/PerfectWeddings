using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PerfectWeddings.Helpers
{
    public static class ApplicationExtensions
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        //Creating a function that uses the API function...
        private static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
        /// <summary>
        /// Gets LAN IPAddress and do not return localhost
        /// </summary>
        /// <returns>IPAddress</returns>
        public static IPAddress GetCurrentIpAddress()
        {
            try
            {
                var isConnected = IsConnectedToInternet();
                if (!isConnected)
                    throw new Exception("You're not connected to the Internet!");

                var ips = GetIpAddressList();
                IPAddress localAddr = null;
                //IPAddress localhost = null;

                foreach (var ip in ips.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).Where(ip => !IPAddress.IsLoopback(ip)))
                {
                    localAddr = ip;
                }

                return localAddr;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.GetExceptionMessage("While GetCurrentIpAddress"));
            }
        }
        /// <summary>
        /// Returns list of all interfaces IPAddress
        /// </summary>
        /// <returns>List<IPAddress/></returns>
        public static List<IPAddress> GetIpAddressList()
        {
            try
            {
                var ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Select(ip => ip).ToList();

                return ips;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.GetExceptionMessage("While GetIpAddressList"));
            }
        }
        /// <summary>
        /// Returns only IPAddress which is connected.
        /// </summary>
        /// <returns>IPAddress</returns>
        public static IPAddress GetActiveIpAddress()
        {

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            IPAddress iPAddress = null;
            foreach (var networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses.Where(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork))
                    {
                        if (!IPAddress.IsLoopback(ip.Address))
                            iPAddress = ip.Address;
                    }
                }
            }
            return iPAddress;
        }
        /// <summary>
        /// Gets External IPAddress
        /// </summary>
        /// <returns>IPAddress</returns>
        public static IPAddress GetExternalIp()
        {
            try
            {
                if (!IsConnectedToInternet())
                    throw new Exception("You're not connected to the Internet!");

                var externalIp = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                externalIp = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                    .Matches(externalIp)[0].ToString();
                return IPAddress.Parse(externalIp);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets Client's IPAddress
        /// </summary>
        /// <returns>string</returns>
        public static string GetClientIpAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// Transform object into string data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The string value.</returns>
        public static string AsString(this object item)
        {
            string defaultString = "";
            if (item == null || item.Equals(DBNull.Value))
                return defaultString;

            return item.ToString().Trim();
        }
    }
}