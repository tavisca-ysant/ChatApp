using System;

namespace ChatApp
{
    public class Display
    {
        public Message _message;
        public Display(Message message)
        {
            this._message = message;    
        }

        public void Show()
        {
            Console.WriteLine(_message.Text);
        }

        public string GetMeassage()
        {
            return _message.Text;
        }
    }
}
