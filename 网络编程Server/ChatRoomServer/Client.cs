using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomServer
{
    /// <summary>
    /// 用来跟客服端做通信.
    /// </summary>
    class Client
    {
        private Socket clientSocket;

        public Client(Socket s)
        {
            clientSocket = s;
        }
    }
}
