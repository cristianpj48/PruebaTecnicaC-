namespace CurrencyConverterAPI
{
    public class AuthenticationService
    {
        private static readonly List<User> Users =
        [
        new User { Username = "user1", Password = "1234", Name = "John Doe", Role = "Admin" },
        new User { Username = "user2", Password = "1234", Name = "Jane Smith", Role = "User" },
        new User { Username = "user3", Password = "1234", Name = "Alice Johnson", Role = "User" },
        new User { Username = "user4", Password = "1234", Name = "Bob Brown", Role = "User" },
        new User { Username = "user5", Password = "1234", Name = "Charlie Davis", Role = "Admin" }
    ];

        public Response ValidateUser(User loginUser)
        {
            User user = Users.FirstOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (user == null)
            {
                return new Response
                {
                    State = State.Rechazado,
                    MessageText = "Invalido username o password",
                    ResponseText = string.Empty
                };
            }

            return new Response
            {
                State = State.Aceptado,
                MessageText = "Login exitoso",
                ResponseText = $"Nombre: {user.Name}, Role: {user.Role}"
            };
        }
    }

}
