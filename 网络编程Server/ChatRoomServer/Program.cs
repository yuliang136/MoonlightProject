using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomServer
{
    class Program
    {
        private static List<Client> clientList = new List<Client>();

        static void Main(string[] args)
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 绑定ip.
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("192.168.2.72"), 7788));

            // 线程？
            tcpServer.Listen(100);

            Console.WriteLine("server running..");

            // 死循环？ 
            while (true)
            {
                Socket clientSocket = tcpServer.Accept();

                Console.WriteLine("a client is connected!");

                // 把与每个客户端通信的逻辑.(收发消息.) 放到client端里做处理.
                Client client = new Client(clientSocket);

                clientList.Add(client);
            }
            


        }
    }
}
