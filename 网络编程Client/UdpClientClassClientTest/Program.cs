using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpClientClassClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建UdpClient.
            UdpClient client = new UdpClient();

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                const string strIp = "192.168.2.72";
                client.Send(data, data.Length, new IPEndPoint(IPAddress.Parse(strIp), 7788));
            }

            client.Close();
            Console.ReadKey();
        }
    }
}
