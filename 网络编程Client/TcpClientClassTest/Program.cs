using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 当我们创建tcpclient对象的时候，就会和Server建立连接.
            string strIp = "192.168.2.72";
            TcpClient client = new TcpClient(strIp, 7788);

            // 通过网络流进行数据的交换.
            NetworkStream stream = client.GetStream();

            // 利用死循环. 重复向服务器端发送数据.
            while (true)
            {
                // Write写入数据就是发送数据.
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }

            stream.Close();
            client.Close();
            Console.ReadKey();
        }
    }
}
