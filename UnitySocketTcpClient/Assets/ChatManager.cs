﻿using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class ChatManager : MonoBehaviour
{

    public string ipAddress = "192.168.2.72";
    public int nPort = 7788;

    private Socket _clientSocket;

	// Use this for initialization
	void Start ()
	{
	    ConnectToServer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void ConnectToServer()
    {
        _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // 发起连接.

        _clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), nPort));

    }
}
