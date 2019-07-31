using System;
using Xunit;
using ChatApp;
using FluentAssertions;

namespace ChatAppTest
{
    public class DisplayFixture
    {
        private Display _display = new Display(new Message("Hello", "Anil", "Govind"));
        [Fact]
        public void TestDisplayObject()
        {
            
            Assert.IsType<Display>(_display);
        }

        [Fact]
        public void TestShowMessage()
        {
            var message = _display.GetMeassage();

            message.Should().Be("Hello");
        }
    }
}
