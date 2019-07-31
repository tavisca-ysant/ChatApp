using System;

namespace ChatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NetworkHost networkHost = new NetworkHost();
            Console.WriteLine("Enter your choice");
            
           
            bool flag = true;
            
                Console.WriteLine("Do you want to send ");
                char choice = Char.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 'N':

                        networkHost.StartListening();
                        break;
                    case 'Y':
                        networkHost.Connect("172.16.5.174");
                        break;
                    
                }
            
            Console.ReadKey();
        }
    }
    public class User
    {

    }
}
