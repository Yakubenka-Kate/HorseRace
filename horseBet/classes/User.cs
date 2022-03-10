namespace horseBet.classes 
{
    internal class User
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public User()
        {
            Name = "";
            Text = "";
        }

        public User(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public override string ToString() => $"{Name} - {Text}";

    }
}
