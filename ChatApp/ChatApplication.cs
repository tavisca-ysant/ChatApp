using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace ChatApp
{
    public class ChatApplication
    {
        static string GetIp()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry ipentry = Dns.GetHostEntry(hostname);
            IPAddress[] addr = ipentry.AddressList;
            return addr[addr.Length - 1].ToString();
        }
        public void Start()
        {
            Console.WriteLine("Enter your name");
            string Name = Console.ReadLine();
            Console.Title = $"{Name}";
            User user = new User(Name);
            user.ipAddress = IPAddress.Parse(GetIp());
            char choice;
            // Console.WriteLine(user.ToString());
            
           
            
            NetworkHost networkHost = new NetworkHost(user);
            // Console.WriteLine("Enter your choice");

            //bool flag = true;
            //  networkHost.StartListening();
            Console.WriteLine("Do you want to connect (Y/N) ?");
            choice = Char.Parse(Console.ReadLine());
            switch (choice)
            {
                case 'N':
                    networkHost.StartListening();
                    break;
                case 'Y':
                    Console.WriteLine("Whom do you want to connect?(username@ip)");
                    string userDetails = Console.ReadLine();
                    user.peerName = userDetails.Split("@")[0];
                    networkHost.Connect(userDetails.Split("@")[1]);
                    break;
            }

            Console.ReadKey();
        }

    }
}
