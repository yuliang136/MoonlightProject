using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpListenerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 TcpListener对socket进行了一层封装，这个类里面会去创建socket对象.
            string strIp = "192.168.2.72";
            TcpListener listener = new TcpListener(IPAddress.Parse(strIp), 7788);

            // 2 开始进行监听.
            listener.Start();

            // 3 等待客服端连接过来.
            TcpClient client = listener.AcceptTcpClient();

            // 4 取得客服端发送过来的数据.
            // 从这个网络流可以读取从客服端发送过来的数据.
            NetworkStream stream = client.GetStream(); // 得到网络流. NetworkStream.

            byte[] data = new byte[1024]; // 创建一个数据的容器 用来承接数据.

            // 0 表示从数组的哪个索引开始存放数据.
            // 1024 表示最大读取的字节数.

            while (true)
            {
                // 最多读取1024个.
                // 不足1024个时，有多少读取多少.
                // 超过1024 最多读1024.
                int nReadLength = stream.Read(data, 0, 1024); // 读取数据.
                string message = Encoding.UTF8.GetString(data, 0, nReadLength);
                Console.WriteLine(message);
            }


            // 关闭释放资源

            stream.Close(); // 关闭流
            client.Close(); // 关闭客服端连接.
            listener.Stop(); // 关闭监听.


            Console.ReadKey();
        }
    }
}
