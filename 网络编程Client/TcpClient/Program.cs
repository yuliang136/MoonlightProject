using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 创建socket.
            Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2 发起建立连接的请求.

            // 通过ip： 端口号 定位一个要连接的服务器端.

            IPAddress ipAddress = IPAddress.Parse("192.168.2.72"); // 把一个字符串的IP转化为一个IPAddress对象.
            EndPoint point = new IPEndPoint(ipAddress, 7788);
            tcpClient.Connect(point);

            byte[] data = new byte[1024]; // 这里传递一个byte数组，实际上这个data数组用来接收数据.

            // length表示接收了多少字节的数组.
            int length = tcpClient.Receive(data);

            string message = Encoding.UTF8.GetString(data,0,length); // 只把接收到的数据做一个转化.

            Console.WriteLine(message);

            // 向服务器端发送消息.
            string messageInput = Console.ReadLine(); // 读取用户的输入，把输入发送到服务器端.
            byte[] dataSend = Encoding.UTF8.GetBytes(messageInput); // 把字符串转化为字节.

            tcpClient.Send(dataSend);

            Console.ReadKey();
        }
    }
}
