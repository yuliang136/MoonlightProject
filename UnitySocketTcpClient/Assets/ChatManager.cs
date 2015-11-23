using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public string ipAddress = "192.168.2.72";
    public int nPort = 7788;

    private Socket _clientSocket;
    private Thread t;
    private byte[] data = new byte[1024];

    private string _strMessage; // 消息容器. 在Update里频繁判断.

    #region Ui变量

    public Text _textInput;

    #endregion

    // Use this for initialization
	void Start ()
	{
	    ConnectToServer();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (!string.IsNullOrEmpty(_strMessage))
	    {
	        _textInput.text += "\n" + _strMessage;

	        _strMessage = string.Empty; // 清空消息.
	    }
    }

    public void OnDestroy()
    {
        _clientSocket.Shutdown(SocketShutdown.Both);

        // 必须由Client断开连接.
        _clientSocket.Close();
    }



    private void ConnectToServer()
    {
        _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // 发起连接.

        _clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), nPort));


        // 创建一个新的线程 用来接收消息
        t = new Thread(ReceiveMessage);
        t.Start();
    }

    /// <summary>
    /// 这个线程方法用来循环接收消息
    /// </summary>
    private void ReceiveMessage()
    {
        while (true)
        {
            if (_clientSocket.Connected == false)
            {
                break;
            }

            int nLength = _clientSocket.Receive(data);

            string message = Encoding.UTF8.GetString(data, 0, nLength);

            // 在单独的线程里操作了Unity的控件.
            //_textInput.text += "\n" + message;
            _strMessage = message;
        }
        


    }

    public void SendYLMessage(InputField ifMessage)
    {
        string message = ifMessage.text;

        byte[] data = Encoding.UTF8.GetBytes(message);

        _clientSocket.Send(data);

        // 清空字段.
        ifMessage.text = string.Empty;
    }
}
