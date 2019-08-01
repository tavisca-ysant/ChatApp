using System;
using System.Net;

namespace ChatApp
{
    public class User
    {
        public string _userName;
        public string peerName;
        
        public int _userPort;
        public IPAddress ipAddress;

        public User(string userName)
        {
            _userName = userName;
            
        }

        public override string ToString()
        {
            return _userName;
        }

        public void AcceptUserDetails()
        {
            //Console.Write("Enter your name");
            //_userName = Console.ReadLine();
            //Console.Write("Enter the name of user you wish to connect to (username@ipaddress)");
            //_peerName = Console.ReadLine();
            
            //Console.Write("Enter your name");
            //_userName = Console.ReadLine();


        }

    }
}
