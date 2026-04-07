using System.Collections;
using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exam_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();

            List<Question> allQuestions = new List<Question>
            {
                // HISTORY (5)
                new Question {
                    Text = "Who was the first President of the United States?",
                    Options = new List<string> { "George Washington", "Abraham Lincoln", "John Adams", "Thomas Jefferson" },
                    CorrectIndex = 0,
                    Answer = "Incorrect",
                    Category = "History"
                },
                new Question {
                    Text = "In which year did World War II end?",
                    Options = new List<string> { "1942", "1945", "1939", "1950" },
                    CorrectIndex = 1,
                    Answer = "Incorrect",
                    Category = "History"
                },
                new Question {
                    Text = "Which empire built the Colosseum?",
                    Options = new List<string> { "Greek Empire", "Roman Empire", "Ottoman Empire", "Persian Empire" },
                    CorrectIndex = 1,
                    Answer = "Incorrect",
                    Category = "History"
                },
                new Question {
                    Text = "Who discovered America?",
                    Options = new List<string> { "Christopher Columbus", "Vasco da Gama", "James Cook", "Marco Polo" },
                    CorrectIndex = 0,
                    Answer = "Incorrect",
                    Category = "History"
                },
                new Question {
                    Text = "The Cold War was mainly between the USA and which country?",
                    Options = new List<string> { "Germany", "China", "USSR", "Japan" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "History"
                },

                // GEOGRAPHY (5)
                new Question {
                    Text = "What is the capital of France?",
                    Options = new List<string> { "Berlin", "Madrid", "Paris", "Rome" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Geography"
                },
                new Question {
                    Text = "Which is the largest ocean?",
                    Options = new List<string> { "Atlantic", "Indian", "Pacific", "Arctic" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Geography"
                },
                new Question {
                    Text = "Which country has the largest population?",
                    Options = new List<string> { "USA", "India", "China", "Brazil" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Geography"
                },
                new Question {
                    Text = "Mount Everest is located in which mountain range?",
                    Options = new List<string> { "Alps", "Andes", "Himalayas", "Rockies" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Geography"
                },
                new Question {
                    Text = "What is the longest river in the world?",
                    Options = new List<string> { "Amazon", "Nile", "Yangtze", "Mississippi" },
                    CorrectIndex = 1,
                    Answer = "Incorrect",
                    Category = "Geography"
                },

                // BIOLOGY (5)
                new Question {
                    Text = "What is the basic unit of life?",
                    Options = new List<string> { "Atom", "Cell", "Organ", "Tissue" },
                    CorrectIndex = 1,
                    Answer = "Incorrect",
                    Category = "Biology"
                },
                new Question {
                    Text = "Which organ pumps blood?",
                    Options = new List<string> { "Liver", "Brain", "Heart", "Lungs" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Biology"
                },
                new Question {
                    Text = "What gas do plants absorb?",
                    Options = new List<string> { "Oxygen", "Carbon dioxide", "Nitrogen", "Hydrogen" },
                    CorrectIndex = 1,
                    Answer = "Incorrect",
                    Category = "Biology"
                },
                new Question {
                    Text = "DNA stands for?",
                    Options = new List<string> {
                        "Deoxyribonucleic Acid",
                        "Dynamic Network Analysis",
                        "Digital Numeric Array",
                        "None of the above"
                    },
                    CorrectIndex = 0,
                    Answer = "Incorrect",
                    Category = "Biology"
                },
                new Question {
                    Text = "Which part of the cell contains genetic material?",
                    Options = new List<string> { "Nucleus", "Membrane", "Cytoplasm", "Ribosome" },
                    CorrectIndex = 0,
                    Answer = "Incorrect",
                    Category = "Biology"
                },

                // TECHNOLOGY (5)
                new Question {
                    Text = "What does CPU stand for?",
                    Options = new List<string> {
                        "Central Processing Unit",
                        "Computer Personal Unit",
                        "Central Power Unit",
                        "Control Processing Unit"
                    },
                    CorrectIndex = 0,
                    Answer = "Incorrect",
                    Category = "Technology"
                },
                new Question {
                    Text = "Which language is primarily used in .NET?",
                    Options = new List<string> { "Python", "C#", "JavaScript", "C++" },
                    CorrectIndex = 1,
                    Answer = "Incorrect",
                    Category = "Technology"
                },
                new Question {
                    Text = "What does HTML stand for?",
                    Options = new List<string> {
                        "HyperText Markup Language",
                        "HighText Machine Language",
                        "Hyper Transfer Mark Language",
                        "Home Tool Markup Language"
                    },
                    CorrectIndex = 0,
                    Answer = "Incorrect",
                    Category = "Technology"
                },
                new Question {
                    Text = "Which company developed Windows OS?",
                    Options = new List<string> { "Apple", "Google", "Microsoft", "IBM" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Technology"
                },
                new Question {
                    Text = "What is the brain of the computer?",
                    Options = new List<string> { "RAM", "Hard Drive", "CPU", "GPU" },
                    CorrectIndex = 2,
                    Answer = "Incorrect",
                    Category = "Technology"
                }
            };

            // History Quiz
            Quiz historyQuiz = new Quiz
            {
                Name = "History Quiz",
                Questions = allQuestions
                    .Where(q => q.Category.ToUpper() == "HISTORY")
                    .ToList()
            };

            // Geography Quiz
            Quiz geographyQuiz = new Quiz
            {
                Name = "Geography Quiz",
                Questions = allQuestions
                    .Where(q => q.Category.ToUpper() == "GEOGRAPHY")
                    .ToList()
            };

            // Biology Quiz
            Quiz biologyQuiz = new Quiz
            {
                Name = "Biology Quiz",
                Questions = allQuestions
                    .Where(q => q.Category.ToUpper() == "BIOLOGY")
                    .ToList()
            };

            // Technology Quiz
            Quiz technologyQuiz = new Quiz
            {
                Name = "Technology Quiz",
                Questions = allQuestions
                    .Where(q => q.Category.ToUpper() == "TECHNOLOGY")
                    .ToList()
            };


            List<QuizResult> Results = new List<QuizResult>();


            string user_path = "users.json";
            string results_path = "results.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            if (File.Exists(user_path))
            {
                using (FileStream fs = new FileStream(user_path, FileMode.Open))
                {
                    users = JsonSerializer.Deserialize<List<User>>(fs) ?? new List<User>();
                }
            }

            if (File.Exists(results_path))
            {
                using (FileStream fsr = new FileStream(results_path, FileMode.Open))
                {
                    Results = JsonSerializer.Deserialize<List<QuizResult>>(fsr) ?? new List<QuizResult>();
                }

            }

            bool loged = false;

            
            Console.WriteLine("=== Welcome to Quiz System ===");
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Login");
            Console.WriteLine("0 - Exit");

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            switch (option)
            {
                case 0:
                    return;
          

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
                        if (!DateTime.TryParse(Console.ReadLine(), out date))
                            break;

                        Console.WriteLine("Invalid date!");
                    }

                    users.Add(new User(login, pass, date));

                    using (FileStream fs = new FileStream(user_path, FileMode.Create))
                    {
                        JsonSerializer.Serialize(fs, users, options);
                    }
                    Console.WriteLine($"Welcome!");
                    Console.WriteLine("Registration successful!");
                    loged = true;
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
                    loged = true;
                    break;
            }

            if (loged)
            {
                while (true)
                {
                    Console.WriteLine("=== Quiz Menu ===");
                    Console.WriteLine("1 - Start new quiz");
                    Console.WriteLine("2 - View my past quiz results");
                    Console.WriteLine("3 - View Top-20 for a quiz");
                    Console.WriteLine("4 - Settings (change password / date of birth)");
                    Console.WriteLine("0 - Exit");
                    Console.Write("Select option: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Ivalid choice!");
                        return;
                    }
                    switch (choice)
                    {
                        case 0:
                            return;

                        case 1:
                            Console.WriteLine("1 - History");
                            Console.WriteLine("2 - Geography");
                            Console.WriteLine("3 - Biology");
                            Console.WriteLine("4 - Technology");
                            Console.WriteLine("5 - Mixed");

                            if (!int.TryParse(Console.ReadLine(), out int sub))
                            {
                                Console.WriteLine("Invalid choice"!);
                                return;
                            }

                            if (sub == 1)
                            {
                                historyQuiz.Run();
                                Results.Add(new QuizResult(
                                            historyQuiz.Name,
                                            historyQuiz.Score,
                                            DateTime.Now ));                      
                                using (FileStream fsr = new FileStream(results_path, FileMode.Create))
                                {
                                    JsonSerializer.Serialize(fsr, Results, options);
                                }
                            }
                            break;

                        case 2:
                            foreach (var result in Results)
                                result.PrintResults();
                            break;
                    }
                }
            }


        }
    }

    
    public class User
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Login { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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

    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
    }


    public class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public int Score { get; set; }

        public void Run()
        {
            foreach (var q in Questions)
            {
                Console.WriteLine(q.Text);

                for (int i = 0; i < q.Options.Count; i++)
                    Console.WriteLine($"{i + 1} - {q.Options[i]}");

                int answer = int.Parse(Console.ReadLine());

                if (answer - 1 == q.CorrectIndex)
                {
                    Console.WriteLine("Correct!\n");
                    Score++;
                }
                else Console.WriteLine("Incorrect!\n");
            }

            Console.WriteLine("Number of your correct answers is: " + Score);
            Console.WriteLine();
        }
    }
    public class QuizResult
    {
        public string QuizName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public QuizResult(string name, int score, DateTime date)
        {
            QuizName = name;
            Score = score;
            Date = date;
        }

        public QuizResult() { }

        public void PrintResults ()
        {
            Console.WriteLine("Quiz subject: " +  QuizName);
            Console.WriteLine("Score: " + Score);
            Console.WriteLine("Date: " + Date);
            Console.WriteLine();

        }
    }

    
}
