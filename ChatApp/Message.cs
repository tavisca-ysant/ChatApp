namespace ChatApp
{
    public class Message
    {
        public Message(string text)
        {
            Text = text;
            
        }
        public string Text { get; private set; }
        
    }
}
