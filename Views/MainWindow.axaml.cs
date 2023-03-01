using Avalonia.Controls;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace NETWorks.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public string getIPv4()
        {
            string ipv4Address = string.Empty;
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipv4Address = ip.Address.ToString();
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(ipv4Address))
                {
                    break;
                }
            }
            return ipv4Address;
        }

        public string getIPv6()
        {
            return string.Empty;
        }
        public string getNetworkCardName()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            return nics[0].Description;
        }

        public string getConnectionType()
        {
            NetworkInterfaceType[] connectionTypes = {
                NetworkInterfaceType.Ethernet,
                NetworkInterfaceType.Wireless80211,
                NetworkInterfaceType.Ppp
            };

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up && connectionTypes.Contains(ni.NetworkInterfaceType))
                {
                    return ni.NetworkInterfaceType.ToString();
                }
            }

            return string.Empty;
        }
    }
}
