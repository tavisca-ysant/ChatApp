using System;
using System.Net;
using System.Net.Sockets;

namespace ChatApp
{
    public class NetworkHost
    {
        public TcpListener Socket = null;
        public void StartListening()
        {
            try
            {
                Socket = new TcpListener(localaddr: IPAddress.Any, port: 6666);
                Socket.Start();

                Console.WriteLine("Success");
                Console.WriteLine("Waiting for connect");
                while(true)
                {
                    TcpClient client = Socket.AcceptTcpClient();
                   
                    if (client.Connected)
                    {
                        Console.WriteLine("Connected");
                        
                        Conversation conversation = new Conversation(client);
                        conversation.Send();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to connect : " + ex);
                Console.ReadKey();
            }
        }

        public void StopListening(TcpClient client)
        {
            Socket.Stop();
        }

        public TcpClient Connect(string ipAddr)
        {
            
            string ip = ipAddr;
            int port = 6666;

            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, port);
                Console.WriteLine("Connected");
                Conversation conversation = new Conversation(client);
                conversation.Send();
                return client;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to connect : " + ex);
                Console.ReadKey();
                throw ex;
            }
        }
    }
}
