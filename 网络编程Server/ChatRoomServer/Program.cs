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

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="message"></param>
        public static void BroadcastMessage(string message)
        {
            var notConnectedList = new List<Client>();

            foreach (var client in clientList)
            {
                if (client.Connected)
                {
                    client.SendMessage(message);
                }
                else
                {
                    notConnectedList.Add(client);
                }
            }

            foreach (var notConnectClient in notConnectedList)
            {
                clientList.Remove(notConnectClient);
            }
        }

        static void Main(string[] args)
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string StrIp = "192.168.2.72";

            // 绑定ip.
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse(StrIp), 7788));

            // 线程？
            tcpServer.Listen(100);

            Console.WriteLine("Server running..");

            // 死循环？ 
            while (true)
            {
                Socket clientSocket = tcpServer.Accept();

                Console.WriteLine("A client is connected!");

                // 把与每个客户端通信的逻辑.(收发消息.) 放到client端里做处理.
                Client client = new Client(clientSocket);

                clientList.Add(client);
            }



        }
    }
}
