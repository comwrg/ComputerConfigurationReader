using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Protocol
    {
        private Action<string> _callback;
        private TcpListener _tcpListener;
        public void Start(Action<string> callback, int port = 8888)
        {
            _callback = callback;
            _tcpListener = new TcpListener(IPAddress.Any, port);
            _tcpListener.Start();
            Thread thread = new Thread(StartThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void StartThread()
        {
            while (true)
            {
                TcpClient client = _tcpListener.AcceptTcpClient();
                Thread thread = new Thread(ClientConnent);
                thread.IsBackground = true;
                thread.Start(client);
            }
        }
        private void ClientConnent(object o)
        {
            TcpClient client = (TcpClient) o;
            var stream = client.GetStream();
            var bytes = new byte[1024];
            var i = stream.Read(bytes, 0, bytes.Length);
            var msg = Encoding.UTF8.GetString(bytes, 0, i);
            _callback(msg);
        }
    }
}