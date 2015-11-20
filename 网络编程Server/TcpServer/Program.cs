using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 创建Socket.

            // AddressFamily.InterNetwork 内网. ??
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 绑定IP和端口号.
            // IPEndPoint实现了抽象类. 192.168.2.72


            IPAddress ipaddress = new IPAddress(new byte[]{192,168,2,72});
            int nPort = 7788;

            EndPoint point = new IPEndPoint(ipaddress, 7788); // ipendpoint 对ip+端口做了一层封装的类.
            tcpServer.Bind(point); // 向操作系统申请一个可用的ip跟端口号，用来做通信.


            // 3，等待客服端连接.
            // 最大连接数.
            tcpServer.Listen(100);

            // 4 接收连接
            Socket clientSocket = tcpServer.Accept(); // 暂停当前线程，直到有一个客服端连接过来. 之后进行下面的代码.


            // 使用返回的Socket跟客服端做通信.

            // 发送消息.
            string message = "hello 欢迎您";

            // 把字符串转化为buffer数组.
            byte[] getData = Encoding.UTF8.GetBytes(message);

            clientSocket.Send(getData);


            // 接收数据.
            byte[] inputData = new byte[1024];
            int nLength = clientSocket.Receive(inputData);

            string strInput = Encoding.UTF8.GetString(inputData, 0, nLength);
            Console.WriteLine(strInput);

            Console.ReadKey();
        }
    }
}
