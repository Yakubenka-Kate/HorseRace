namespace dataReading
{
    /// <summary>
    /// Player Information
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Earned points in the game
        /// </summary>
        public string Text { get; set; }

        public User()
        {
            Name = string.Empty;
            Text = string.Empty;
        }

        public User(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public override string ToString() => $"{Name} - {Text}";

    }
}

