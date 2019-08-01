using System;
using System.Net;
using System.Net.Sockets;

namespace ChatApp
{
    public class NetworkHost
    {
        
        private User _user;
        
        public NetworkHost(User user)
        {
            _user = user;
        }


        public TcpListener Socket = null;
        public void StartListening()
        {
            try
            {
                Socket = new TcpListener(_user.ipAddress, port: 6666);
                Socket.Start();

                
                while(true)
                {
                    Console.WriteLine("Waiting to connect");
                    
                    TcpClient client = Socket.AcceptTcpClient();
                    
                    if (client.Connected)
                    {
                        
                        Console.WriteLine("=======Connected ============");
                        
                        Conversation conversation = new Conversation(client, _user);
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

        public void Connect(string ipAddr)
        {
            
            string ip = ipAddr;
            int port = 6666;

            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, port);
                Console.WriteLine($"============Connected============");
                Conversation conversation = new Conversation(client, _user);
                conversation.Send();
               
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
