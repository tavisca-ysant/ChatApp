using System;
using System.Net.Sockets;
using System.Threading;

namespace ChatApp
{
    public class Conversation
    {
        private TcpClient _socket;
        private User _user;
        public Conversation(TcpClient socket, User user)
        {
            this._socket = socket;
            _user = user;
        }
        public void Send()
        {
            try
            {
                NetworkStream networkStream = _socket.GetStream();
                Thread thread = new Thread(_ => ReceiveData((TcpClient)_));
                thread.Start(_socket);
                //Console.WriteLine("< "+_user+" > ");
                string message;
                //Console.Write(_user+": ");
                while(!(string.IsNullOrEmpty(message = Console.ReadLine())) && message != "bye" && message != "Bye")
                {

                    byte[] buffer = Stream.Encode(_user+" : "+message);
                    networkStream.Write(buffer);
                }

                Console.WriteLine("Disconnected");
               // thread.Join();
                networkStream.Close();
                _socket.Close();
                System.Environment.Exit(0);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
                Console.ReadKey();
            }
            

        }

        private void ReceiveData(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                string DecodedData = Stream.Decode(receivedBytes, byte_count);
                if (!DecodedData.Equals("bye") )
                    Console.WriteLine($"{DecodedData}");
                else
                {
                    System.Environment.Exit(1);
                    Console.ReadKey();
                }

            }
        }
    }
}
