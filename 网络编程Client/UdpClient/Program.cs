using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建socket.
            Socket udpClient = new Socket(  AddressFamily.InterNetwork,
                                            SocketType.Dgram,
                                            ProtocolType.Udp);
            string strIp = "192.168.2.72";

            while (true)
            {
                // 发送数据.
                EndPoint serverPoint = new IPEndPoint(IPAddress.Parse(strIp), 7788);
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.SendTo(data, serverPoint);
            }


            udpClient.Close();
            Console.ReadKey();
        }
    }
}
