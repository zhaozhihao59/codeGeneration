using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.InteropServices;
using System.Management;

namespace codeGeneration
{
    class GetIp
    {
        public List<String> list = new List<string>();
        public GetIp() {
            list.Add("10.0.1.1");
            list.Add("10.0.17.1");
        }
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        //获取本机的IP 
        public string getLocalIP()
        {
            string strHostName = Dns.GetHostName();  //得到本机的主机名 
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP 
            
            string strAddr = ipEntry.AddressList[0].ToString();
            return (strAddr);
        }
        //获取本机的默认网关
        public string[] getLocalNetInfo()
        {
            string[] mac = new string[2];
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                {
                    mac[0] = (mo["IPAddress"] as String[])[0];//IP地址
                    if (mo["DefaultIPGateway"] != null)
                    {
                        mac[1] = (mo["DefaultIPGateway"] as String[])[0];//默认网关
                    }
                    break;

                }
            }
            return (mac);
        } 
    }
}
