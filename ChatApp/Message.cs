namespace ChatApp
{
    public class Message
    {
        public Message(string text, string source, string destination)
        {
            Text = text;
            Source = source;
            Destination = destination;
        }
        public string Text { get; private set; }
        public string  Source { get; private set; }
        public string Destination { get; private set; }
    }
}
