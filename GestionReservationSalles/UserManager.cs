namespace GestionReservationSalles
{
    internal class UserManager
    {
        public static UserManager Instance { get; private set; } = new UserManager();

        public User? CurrentUser { get; private set; }

        private List<User> users;

        public UserManager()
        {
            users = new List<User>()
            {
                new User() { Name = "Admin", Email = "admin@exemple.com", Password = "admin123", Role = "admin" },
                new User() { Name = "User", Email = "user@exemple.com", Password = "user123", Role = "user" }
            };
        }

        public bool Authenticate(string email, string password)
        {
            User? user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                CurrentUser = user;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool Register(string name, string email, string password)
        {
            if (users.Any(u => u.Email == email))
            {
                return false; 
            }

            User user = new User()
            {
                Name = name,
                Email = email,
                Password = password
            };

            users.Add(user);
            return true;
        }
    }
}
