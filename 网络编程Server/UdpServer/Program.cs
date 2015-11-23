using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1,数据包.
            // Udp.
            Socket udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // 2,绑定Ip.
            const string strIp = "192.168.2.72";
            udpServer.Bind(new IPEndPoint(IPAddress.Parse(strIp), 7788));

            // 3,接收数据.
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[1024];

            // 这个方法会数据来源(ip:port)放在第二个参数上.
            int nLength = udpServer.ReceiveFrom(data, ref remoteEndPoint);

            string message = Encoding.UTF8.GetString(data, 0, nLength);

            Console.WriteLine("From IP" + (remoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                              (remoteEndPoint as IPEndPoint).Port.ToString() + "收到了数据：" + message);

            udpServer.Close();
            Console.ReadKey();
        }
    }
}
