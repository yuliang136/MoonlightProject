using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatRoomServer
{
    /// <summary>
    /// 用来跟客服端做通信.
    /// </summary>
    class Client
    {
        private Socket _socketClient;
        private Thread _thread;

        private byte[] _bReceivedData = new byte[1024]; // 1024大小数据容器.

        // 构造函数.
        public Client(Socket s)
        {
            _socketClient = s;

            _thread = new Thread(ReceiveMessage);

            _thread.Start();
        }

        // 使用线程处理接收消息.
        private void ReceiveMessage()
        {
            // 一直接收客服端的数据
            while (true)
            {

                //// 在接受数据之前，判断Socket连接是否断开.
                //if (_socketClient.Connected == false)
                //{
                //    break; // 跳出循环 终止线程的执行.
                //}

                bool bNotConnect = _socketClient.Poll(10, SelectMode.SelectRead);

                if (bNotConnect)
                {
                    break; // 
                }

                // Client端断开连接时，Server还在监听.

                // 客服端会等在这里. 如果Unity Client直接断开 会收到一条Length为0的消息
                int nLength = _socketClient.Receive(_bReceivedData);

                string message = Encoding.UTF8.GetString(_bReceivedData, 0, nLength);

                // TODO:服务器端接收到数据，要把这个数据分发到客服端.
                Console.WriteLine("收到了消息" + message);
            }
        }

    }
}
