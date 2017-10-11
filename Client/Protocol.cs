using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Protocol
    {
        private TcpClient _tcpClient;
        private Socket _client;
        public Protocol(string ip, int port)
        {
            _tcpClient = new TcpClient();
            _tcpClient.Connect(ip, port);
            _client = _tcpClient.Client;


        }

        public void Send(string msg)
        {
            _client.Send(Encoding.UTF8.GetBytes(msg));
        }
    }
}