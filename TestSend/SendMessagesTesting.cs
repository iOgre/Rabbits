using System;
using SendMessages;
using Xunit;


namespace TestSend
{
    public class SendMessagesTesting
    {
        
        
        [Fact]
        public void TestSendMessagesIsOk()
        {
           var sender = new Send();
            Assert.NotNull(sender);
        }

        [Fact]
        public void SendMessageReturnsMessageText()
        {
            var sender = new Send();
            Assert.Equal("hello rabbit", sender.Act("hello rabbit"));
        }
        
    }
}