using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ChatApp;
using FluentAssertions;
using System.Net.Sockets;

namespace ChatAppTest
{
    public class NetworkHostFixture
    {
        [Fact]
        public void TestNetworkHostConnect()
        {
            NetworkHost host = new NetworkHost();
            TcpClient client;
            try
            {
                client = host.Connect("192.168.0.105");
                Assert.IsType<TcpClient>(client);
            }
            catch(Exception ex)
            {
                Assert.IsType<Exception>(ex);
            }
            

            
        }
        [Fact]
        public void TestNetworkHostListening()
        {

        }
    }
}
