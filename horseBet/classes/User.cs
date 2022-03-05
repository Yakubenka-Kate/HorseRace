namespace horseBet.classes 
{
    internal class User
    {
        private string name;
        private string text;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public User()
        {
            name = "";
            text = "";
        }

        public User(string name, string text)
        {
            this.name = name;
            this.text = text;
        }     

    }
}
