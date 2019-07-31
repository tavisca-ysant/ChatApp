using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ChatApp;
using FluentAssertions;

namespace ChatAppTest
{
    public class MessageFixture
    {
        private Message _meassage = new Message("Hello", "Anil", "Govind");

        [Fact]
        public void TestMeassageText()
        {
            var meassageText = _meassage.Text;
            meassageText.Should().Be("Hello");
        }

        [Fact]
        public void TestMeassageSource()
        {
            var messageSender = _meassage.Source;
            messageSender.Should().Be("Anil");
        }

        [Fact]
        public void TestMeassageDestination()
        {
            var messageDestination = _meassage.Destination;
            messageDestination.Should().Be("Govind");
        }
    }
}
