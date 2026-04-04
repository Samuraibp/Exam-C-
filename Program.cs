using System.Collections;
using System.Text.Json;

namespace Exam_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            string path = "users.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    users = JsonSerializer.Deserialize<List<User>>(fs) ?? new List<User>();
                }
            }

            bool program = true;

            while (program)
            {
                Console.WriteLine("=== Welcome to Quiz System ===");
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Login");
                Console.WriteLine("0 - Exit");

                int.TryParse(Console.ReadLine(), out int option);

                switch (option)
                {
                    case 0:
                        program = false;
                        break;

                    case 1:
                        Console.WriteLine("=== Registration ===");

                        string login;
                        while (true)
                        {
                            Console.Write("Enter login: ");
                            login = Console.ReadLine();

                            if (users.Any(u => u.Login == login))
                            {
                                Console.WriteLine("Login already exists!");
                                continue;
                            }
                            break;
                        }

                        Console.Write("Enter password: ");
                        string pass = Console.ReadLine();

                        DateTime date;
                        while (true)
                        {
                            Console.Write("Enter date of birth: ");
                            if (DateTime.TryParse(Console.ReadLine(), out date))
                                break;

                            Console.WriteLine("Invalid date!");
                        }

                        users.Add(new User(login, pass, date));

                        using (FileStream fs = new FileStream(path, FileMode.Create))
                        {
                            JsonSerializer.Serialize(fs, users, options);
                        }
                        Console.WriteLine($"Welcome!");
                        Console.WriteLine("Registration successful!");
                        program = false;
                        break;

                    case 2:
                        Console.WriteLine("=== Login ===");

                        Console.Write("Enter login: ");
                        string Login = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string Pass = Console.ReadLine();

                        var user = users.FirstOrDefault(u => u.Login == Login && u.Password == Pass);

                        if (user == null)
                        {
                            Console.WriteLine("Wrong login or password!");
                        }
                        else
                        {
                            Console.WriteLine($"Welcome, {user.Login}!");
                        }
                        program = false;
                        break;
                }
            }
        }
    }


    class User
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User(string? login, string password, DateTime date)
        {
            Login = login;
            Password = password;
            DateOfBirth = date;
        }

        public User() { }

        public void PrintInfo()
        {
            Console.WriteLine ("Login: " + Login);
            Console.WriteLine ("Password: " + Password);
            Console.WriteLine("Birthday: " +  DateOfBirth);
            Console.WriteLine();
        }

        public void GhengePassword(string password)
        {
            Password = password;
        }

        public void ChangeDateOfBirth(DateTime date)
        {
            DateOfBirth = date;
        }

    }
}
