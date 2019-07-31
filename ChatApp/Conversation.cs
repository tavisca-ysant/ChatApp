using System;
using System.Net.Sockets;
using System.Threading;

namespace ChatApp
{
    public class Conversation
    {
        private TcpClient _socket;

        public Conversation(TcpClient socket)
        {
            this._socket = socket;
        }
        public void Send()
        {
            try
            {
                NetworkStream networkStream = _socket.GetStream();
                Thread thread = new Thread(_ => ReceiveData((TcpClient)_));
                thread.Start(_socket);
                Console.WriteLine("You : ");
                string message;
                while(!(string.IsNullOrEmpty(message = Console.ReadLine())) && message != "bye")
                {
                    byte[] buffer = Stream.Encode(message);
                    networkStream.Write(buffer);
                }
                Console.WriteLine("Disconnected");
                thread.Join();
                networkStream.Close();
                _socket.Close();
                Console.ReadKey();
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
                if (!DecodedData.Equals("bye"))
                    Console.WriteLine($"received : {DecodedData}");
                else
                    System.Environment.Exit(1);
            }
        }
    }
}
