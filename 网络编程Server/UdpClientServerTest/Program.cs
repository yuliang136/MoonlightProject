using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpClientServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建udpClient绑定IP和端口号.
            const string strIp = "192.168.2.72";
            UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(strIp),7788));

            while (true)
            {
                // 接收数据.
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);

                // 返回值是字节数组 是数据.
                byte[] data = udpClient.Receive(ref point); // 通过point确定数据来自哪个ip的哪个端口号.

                string message = Encoding.UTF8.GetString(data);

                Console.WriteLine("收到了消息：" + message);
            }


            udpClient.Close();
            Console.ReadKey();
        }
    }
}
