using Avalonia.Controls;
using System.Net;
using System.Net.NetworkInformation;

namespace NETWorks
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            networkCard.Content = getNetworkCardName();
            ipv4.Content = "IPv4: " + getIPv4();
            ipv6.Content = "IPv6: " + getIPv6();
            connectionType.Content = getConnectionType();
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
            return string.Empty;
        }

        public string getConnectionType()
        {
            return string.Empty;
        }
    
    }
}
