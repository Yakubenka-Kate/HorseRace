using dataReading;

namespace processing
{
    /// <summary>
    /// Adding a new user
    /// </summary>
    internal class CreateNewUser
    {
        /// <summary>
        /// The user in the game
        /// </summary>
        public User? User { get; set; }

        public void AddUser(string name, string profit)
        {
            User = new User(name, profit);
            Reader.CreateOrWrite(User);
        }

        public override string ToString()
        {
            return $"{User!.Name} {User.Text}";
        }
    }
}
