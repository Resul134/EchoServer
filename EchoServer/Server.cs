using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using SuperSocket.SocketBase;
using SuperWebSocket;

class Server
{
    private static WebSocketServer EchoServer;

    public void Start()
    {
        EchoServer = new WebSocketServer();
        int port = 7777;
        EchoServer.Setup(port);
        EchoServer.NewSessionConnected += EchoServer_NewSessionConnected;
        EchoServer.NewMessageReceived += EchoServer_NewMessageRecieved;
        EchoServer.NewDataReceived += EchoServer_NewDataReceived;
        EchoServer.SessionClosed += Echoserver_SessionClosed;
        EchoServer.Start();
        Console.WriteLine("Server is running on port:" + port + "Press enter to exit");
        Console.ReadKey();


    }

    private static void Echoserver_SessionClosed(WebSocketSession session, CloseReason value)
    {
        Console.WriteLine("Session closed");
        
    }

    private static void EchoServer_NewDataReceived(WebSocketSession session, byte[] value)
    {
        Console.WriteLine("Data recieved: ");
    }

    private static void EchoServer_NewMessageRecieved(WebSocketSession session, string value)
    {
        Console.WriteLine("New message recieved: " + value);
        if (value == "Hello server")
        {
            session.Send("Hello client beetch");
        }
    }

    private static void EchoServer_NewSessionConnected(WebSocketSession session)
    {
        Console.WriteLine("New session connected!");
    }
}