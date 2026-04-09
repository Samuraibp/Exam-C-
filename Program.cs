using System.Text.Json;
namespace Exam_C_
{
    internal class Program
    {
        static public void OpenEditor(List<Question> questions, string path, JsonSerializerOptions? options)
        {
            QuizEditor editor = new QuizEditor(questions);
            editor.Run();
            using FileStream fs = new FileStream(path, FileMode.Create);
            JsonSerializer.Serialize(fs, questions, options);
        }

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            User currentUser = null;
            List<QuizResult> Results = new List<QuizResult>();

            string user_path = "users.json";
            string results_path = "results.json";
            string questions_path = "questions.json";

            var options = new JsonSerializerOptions { WriteIndented = true };

            if (File.Exists(user_path))
            {
                using FileStream fs = new FileStream(user_path, FileMode.Open);
                users = JsonSerializer.Deserialize<List<User>>(fs) ?? new List<User>();
            }

            if (File.Exists(results_path))
            {
                using FileStream fs = new FileStream(results_path, FileMode.Open);
                Results = JsonSerializer.Deserialize<List<QuizResult>>(fs) ?? new List<QuizResult>();
            }

            List<Question> allQuestions = new List<Question>();

            if (File.Exists(questions_path))
            {
                using FileStream fs = new FileStream(questions_path, FileMode.Open);
                allQuestions = JsonSerializer.Deserialize<List<Question>>(fs) ?? new List<Question>();
            }
            else
            {
                allQuestions = new List<Question>
                {
                    // History 
                    new Question("Who was the first President of the United States?",
                        new List<string>{"George Washington","Abraham Lincoln","John Adams","Thomas Jefferson"}, new List<int>{0},"History"),
                    new Question("In which year did World War II end?",
                        new List<string>{"1942","1945","1939","1950"}, new List<int>{1},"History"),
                    new Question("Which empire built the Colosseum?",
                        new List<string>{"Greek","Roman","Ottoman","Persian"}, new List<int>{1},"History"),
                    new Question("Who discovered America?",
                        new List<string>{"Christopher Columbus","Vasco da Gama","James Cook","Marco Polo"}, new List<int>{0},"History"),
                    new Question("Cold War was between USA and?",
                        new List<string>{"Germany","China","USSR","Japan"}, new List<int>{2},"History"),
                    new Question("The Great Fire of London happened in?",
                        new List<string>{"1666","1650","1700","1688"}, new List<int>{0},"History"),
                    new Question("Renaissance began in which country?",
                        new List<string>{"France","Italy","Spain","England"}, new List<int>{1},"History"),
                    new Question("Who wrote the Communist Manifesto?",
                        new List<string>{"Karl Marx","Lenin","Trotsky","Stalin"}, new List<int>{0},"History"),
                    new Question("Which two countries were part of the Triple Alliance in WWI?",
                        new List<string>{"Germany","France","Italy","Russia"}, new List<int>{0,2},"History"), // несколько правильных
                    new Question("Which event started World War I?",
                        new List<string>{"Assassination of Franz Ferdinand","Fall of Berlin Wall","Battle of Hastings","French Revolution"}, new List<int>{0},"History"),
                    new Question("Who was the first emperor of Rome?",
                        new List<string>{"Augustus","Julius Caesar","Nero","Caligula"}, new List<int>{0},"History"),
                    new Question("French Revolution started in?",
                        new List<string>{"1789","1776","1804","1799"}, new List<int>{0},"History"),
                    new Question("Who was known as the Maid of Orleans?",
                        new List<string>{"Joan of Arc","Marie Antoinette","Catherine the Great","Elizabeth I"}, new List<int>{0},"History"),
                    new Question("American Civil War took place in?",
                        new List<string>{"1861-1865","1775-1783","1812-1815","1914-1918"}, new List<int>{0},"History"),
                    new Question("Which two nations fought the Hundred Years' War?",
                        new List<string>{"France","England","Spain","Portugal"}, new List<int>{0,1},"History"), // несколько правильных
                    new Question("Who led the Soviet Union during WWII?",
                        new List<string>{"Lenin","Stalin","Trotsky","Gorbachev"}, new List<int>{1},"History"),
                    new Question("Fall of the Berlin Wall happened in?",
                        new List<string>{"1989","1991","1980","1975"}, new List<int>{0},"History"),
                    new Question("Which war was fought between North and South Korea?",
                        new List<string>{"Korean War","Vietnam War","World War II","Gulf War"}, new List<int>{0},"History"),
                    new Question("Who was the British Prime Minister during WWII?",
                        new List<string>{"Winston Churchill","Neville Chamberlain","Tony Blair","Margaret Thatcher"}, new List<int>{0},"History"),
                    new Question("Which empire fell in 476 AD?",
                        new List<string>{"Roman Empire","Byzantine Empire","Ottoman Empire","Mongol Empire"}, new List<int>{0},"History"),

                    // Geography 
                    new Question("Capital of France?",
                        new List<string>{"Berlin","Madrid","Paris","Rome"}, new List<int>{2},"Geography"),
                    new Question("Largest ocean?",
                        new List<string>{"Atlantic","Indian","Pacific","Arctic"}, new List<int>{2},"Geography"),
                    new Question("Largest population country?",
                        new List<string>{"USA","India","China","Brazil"}, new List<int>{2},"Geography"),
                    new Question("Mount Everest range?",
                        new List<string>{"Alps","Andes","Himalayas","Rockies"}, new List<int>{2},"Geography"),
                    new Question("Longest river?",
                        new List<string>{"Amazon","Nile","Yangtze","Mississippi"}, new List<int>{1},"Geography"),
                    new Question("Which desert is the largest?",
                        new List<string>{"Sahara","Gobi","Kalahari","Arabian"}, new List<int>{0},"Geography"),
                    new Question("Which two countries share the longest border?",
                        new List<string>{"USA","Canada","Russia","China"}, new List<int>{0,1},"Geography"), // несколько правильных
                    new Question("Capital of Japan?",
                        new List<string>{"Tokyo","Kyoto","Osaka","Hiroshima"}, new List<int>{0},"Geography"),
                    new Question("Which continent is largest by area?",
                        new List<string>{"Africa","Asia","Europe","South America"}, new List<int>{1},"Geography"),
                    new Question("Which two countries are in Scandinavia?",
                        new List<string>{"Norway","Sweden","Poland","Finland"}, new List<int>{0,1},"Geography"), // несколько правильных
                    new Question("Which is the smallest country in the world?",
                        new List<string>{"Vatican City","Monaco","Nauru","San Marino"}, new List<int>{0},"Geography"),
                    new Question("Which sea is between Europe and Africa?",
                        new List<string>{"Black Sea","Mediterranean Sea","Red Sea","Caspian Sea"}, new List<int>{1},"Geography"),
                    new Question("Which river flows through Egypt?",
                        new List<string>{"Nile","Amazon","Yangtze","Mississippi"}, new List<int>{0},"Geography"),
                    new Question("Which mountain is highest in Africa?",
                        new List<string>{"Kilimanjaro","Atlas","Elgon","Ruwenzori"}, new List<int>{0},"Geography"),
                    new Question("Capital of Australia?",
                        new List<string>{"Sydney","Melbourne","Canberra","Perth"}, new List<int>{2},"Geography"),
                    new Question("Which two countries are in South America?",
                        new List<string>{"Brazil","Argentina","Spain","Mexico"}, new List<int>{0,1},"Geography"), // несколько правильных
                    new Question("Which country has the most time zones?",
                        new List<string>{"USA","Russia","France","China"}, new List<int>{1},"Geography"),
                    new Question("Which ocean is shrinking?",
                        new List<string>{"Pacific","Atlantic","Indian","Arctic"}, new List<int>{1},"Geography"),
                    new Question("Which desert is in China?",
                        new List<string>{"Gobi","Sahara","Kalahari","Mojave"}, new List<int>{0},"Geography"),
                    new Question("Which city is in Italy?",
                        new List<string>{"Rome","Madrid","Athens","Lisbon"}, new List<int>{0},"Geography"),

                    // Biology 
                    new Question("Basic unit of life?",
                        new List<string>{"Atom","Cell","Organ","Tissue"}, new List<int>{1},"Biology"),
                    new Question("Which organ pumps blood?",
                        new List<string>{"Liver","Brain","Heart","Lungs"}, new List<int>{2},"Biology"),
                    new Question("Plants absorb?",
                        new List<string>{"Oxygen","Carbon dioxide","Nitrogen","Hydrogen"}, new List<int>{1},"Biology"),
                    new Question("DNA stands for?",
                        new List<string>{"Deoxyribonucleic Acid","Dynamic Network Analysis","Digital Numeric Array","None"}, new List<int>{0},"Biology"),
                    new Question("Genetic material location?",
                        new List<string>{"Nucleus","Membrane","Cytoplasm","Ribosome"}, new List<int>{0},"Biology"),
                    new Question("Which two are types of nucleic acids?",
                        new List<string>{"DNA","RNA","ATP","Glucose"}, new List<int>{0,1},"Biology"), // несколько правильных
                    new Question("Which two are mammal characteristics?",
                        new List<string>{"Hair","Lungs","Egg-laying","Warm-blooded"}, new List<int>{0,3},"Biology"), // несколько правильных
                    new Question("Which gas do animals exhale?",
                        new List<string>{"Oxygen","Carbon dioxide","Nitrogen","Helium"}, new List<int>{1},"Biology"),
                    new Question("Which organ is part of the digestive system?",
                        new List<string>{"Stomach","Heart","Lungs","Kidney"}, new List<int>{0},"Biology"),
                    new Question("Which part of the cell contains DNA?",
                        new List<string>{"Nucleus","Ribosome","Mitochondria","Cytoplasm"}, new List<int>{0},"Biology"),
                    new Question("Photosynthesis produces?",
                        new List<string>{"Glucose","Oxygen","Carbon dioxide","Water"}, new List<int>{0,1},"Biology"), // несколько правильных
                    new Question("Which organ filters blood?",
                        new List<string>{"Kidney","Liver","Lung","Heart"}, new List<int>{0},"Biology"),
                    new Question("Which system controls the body?",
                        new List<string>{"Nervous","Circulatory","Digestive","Skeletal"}, new List<int>{0},"Biology"),
                    new Question("Which is a prokaryotic organism?",
                        new List<string>{"Bacteria","Fungi","Plant","Animal"}, new List<int>{0},"Biology"),
                    new Question("Which two are macronutrients?",
                        new List<string>{"Protein","Carbohydrate","Vitamin C","Iron"}, new List<int>{0,1},"Biology"), // несколько правильных
                    new Question("Which vitamin is produced by sunlight?",
                        new List<string>{"Vitamin D","Vitamin C","Vitamin B12","Vitamin A"}, new List<int>{0},"Biology"),
                    new Question("Which cells carry oxygen?",
                        new List<string>{"Red blood cells","White blood cells","Platelets","Neurons"}, new List<int>{0},"Biology"),
                    new Question("Which two are types of blood cells?",
                        new List<string>{"Red","White","Lymph","Neuron"}, new List<int>{0,1},"Biology"), // несколько правильных
                    new Question("Which is the largest organ in human body?",
                        new List<string>{"Skin","Heart","Liver","Lung"}, new List<int>{0},"Biology"),
                    new Question("Which is essential for vision?",
                        new List<string>{"Vitamin A","Vitamin D","Vitamin K","Vitamin C"}, new List<int>{0},"Biology"),

                    // Technology 
                    new Question("CPU stands for?",
                        new List<string>{"Central Processing Unit","Computer Personal Unit","Central Power Unit","Control Processing Unit"}, new List<int>{0},"Technology"),
                    new Question(".NET language?",
                        new List<string>{"Python","C#","JavaScript","C++"}, new List<int>{1},"Technology"),
                    new Question("HTML stands for?",
                        new List<string>{"HyperText Markup Language","HighText Machine","Hyper Transfer Mark","Home Tool"}, new List<int>{0},"Technology"),
                    new Question("Windows developer?",
                        new List<string>{"Apple","Google","Microsoft","IBM"}, new List<int>{2},"Technology"),
                    new Question("Brain of computer?",
                        new List<string>{"RAM","Hard Drive","CPU","GPU"}, new List<int>{2},"Technology"),
                    new Question("Which two are programming paradigms?",
                        new List<string>{"OOP","Functional","CSS","HTML"}, new List<int>{0,1},"Technology"), // несколько правильных
                    new Question("Which two are operating systems?",
                        new List<string>{"Windows","Linux","Python","C#"}, new List<int>{0,1},"Technology"), // несколько правильных
                    new Question("Which language is for web styling?",
                        new List<string>{"CSS","C++","Java","Python"}, new List<int>{0},"Technology"),
                    new Question("Which device stores data permanently?",
                        new List<string>{"SSD","RAM","CPU","GPU"}, new List<int>{0},"Technology"),
                    new Question("Which is a cloud platform?",
                        new List<string>{"AWS","Excel","Photoshop","GitHub"}, new List<int>{0},"Technology"),
                    new Question("Which is a markup language?",
                        new List<string>{"HTML","Python","C#","Java"}, new List<int>{0},"Technology"),
                    new Question("Which is a scripting language?",
                        new List<string>{"JavaScript","C++","Java","C#"}, new List<int>{0},"Technology"),
                    new Question("Which two are types of computer memory?",
                        new List<string>{"RAM","ROM","CPU","GPU"}, new List<int>{0,1},"Technology"), // несколько правильных
                    new Question("Which network is global?",
                        new List<string>{"Internet","LAN","PAN","MAN"}, new List<int>{0},"Technology"),
                    new Question("Which is a database system?",
                        new List<string>{"MySQL","Python","C++","HTML"}, new List<int>{0},"Technology"),
                    new Question("Which is for version control?",
                        new List<string>{"Git","Linux","Python","C#"}, new List<int>{0},"Technology"),
                    new Question("Which two are cloud storage services?",
                        new List<string>{"Google Drive","Dropbox","GitHub","Linux"}, new List<int>{0,1},"Technology"), // несколько правильных
                    new Question("Which device processes graphics?",
                        new List<string>{"GPU","CPU","RAM","SSD"}, new List<int>{0},"Technology"),
                    new Question("Which is a search engine?",
                        new List<string>{"Google","GitHub","Windows","Python"}, new List<int>{0},"Technology")
                };
            }
            

            bool logged = false;

            Console.WriteLine("=== Welcome to Quiz System ===");
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Login");
            Console.WriteLine("0 - Exit");

            if (!int.TryParse(Console.ReadLine(), out int option)) return;

            switch (option)
            {
                case 0: return;

                case 1:

                    Console.WriteLine("=== Registration ===");     

                    string login;
                    while (true)
                    {
                        Console.Write("Enter login: ");
                        login = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(login))
                        {
                            Console.WriteLine("Login cannot be empty!");
                            continue;
                        }

                        if (users.Any(u => u.Login == login))
                        {
                            Console.WriteLine("Login exists!");
                            continue;
                        }
                        break;
                    }

                    Console.Write("Password: ");
                    string pass = Console.ReadLine();

                    DateTime date;

                    while (true)
                    {
                        Console.Write("Birth date: ");
                        if (DateTime.TryParse(Console.ReadLine(), out date)) break;
                        Console.WriteLine("Invalid date!");
                    }
                    Console.Write("Are you admin? (y/n): ");
                    string adminInput = Console.ReadLine();
                    bool isAdmin = adminInput != null && adminInput.Trim().ToLower() == "y";

                    currentUser = new User(login, pass, date, isAdmin);
                    
                    users.Add(currentUser);

                    using (FileStream fs = new FileStream(user_path, FileMode.Create))
                        JsonSerializer.Serialize(fs, users, options);

                    logged = true;
                    break;

                case 2:

                    Console.Write("Login: ");
                    string log = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    var user = users.FirstOrDefault(u => u.Login == log && u.Password == password);

                    if (user == null)
                    {
                        Console.WriteLine("Wrong login!");
                        return;
                    }

                    currentUser = user;
                    logged = true;
                    break;
            }

            if (!logged) return;

            while (true)
            {
                Console.WriteLine("\n=== Quiz Menu ===");
                Console.WriteLine("1 - Start quiz");
                Console.WriteLine("2 - My results");
                Console.WriteLine("3 - Top 20");
                Console.WriteLine("4 - Settings");
                Console.WriteLine("5 - Quiz Editor (Admin)");
                Console.WriteLine("0 - Exit");

                int choice = int.Parse(Console.ReadLine());
                
                if (choice == 0) return;

                if (choice == 1)
                {
                    Console.WriteLine("1 History\n2 Geography\n3 Biology\n4 Technology\n5 Mixed");

                    int sub = int.Parse(Console.ReadLine());

                    Quiz quiz = null;

                    if (sub == 1)
                        quiz = new Quiz("History", allQuestions.Where(q => q.Category == "History").ToList());

                    if (sub == 2)
                        quiz = new Quiz("Geography", allQuestions.Where(q => q.Category == "Geography").ToList());

                    if (sub == 3)
                        quiz = new Quiz("Biology", allQuestions.Where(q => q.Category == "Biology").ToList());

                    if (sub == 4)
                        quiz = new Quiz("Technology", allQuestions.Where(q => q.Category == "Technology").ToList());

                    if (sub == 5)
                        quiz = new Quiz("Mixed", allQuestions.OrderBy(x => rnd.Next()).ToList());

                    if (quiz == null)
                    {
                        Console.WriteLine("Invalid category");
                        continue;
                    }

                    quiz.Run();

                    var result = new QuizResult(currentUser.Login, quiz.Name, quiz.Score, DateTime.Now);
                    Results.Add(result);

                    using FileStream fs = new FileStream(results_path, FileMode.Create);
                    JsonSerializer.Serialize(fs, Results, options);

                    var ranking = Results
                        .Where(r => r.QuizName == quiz.Name)
                        .OrderByDescending(r => r.Score)
                        .ToList();

                    var found = ranking
                         .Select((r, index) => new { r, index })
                         .FirstOrDefault(x => x.r.UserLogin == currentUser.Login && x.r.Score == quiz.Score);

                    int? place = found?.index + 1;

                    Console.WriteLine(place.HasValue? $"Your place in ranking: {place}": "Place not found");

                }

                if (choice == 2)
                {
                    var my = Results.Where(r => r.UserLogin == currentUser.Login).ToList();

                    if (!my.Any())
                    {
                        Console.WriteLine("No results yet.");
                        continue;
                    }

                    foreach (var r in my)
                        r.Print();
                }

                if (choice == 3)
                {
                    Console.Write("Quiz name: ");
                    string name = Console.ReadLine();

                    var top = Results
                        .Where(r => r.QuizName.ToUpper() == name.ToUpper())
                        .OrderByDescending(r => r.Score)
                        .Take(20)
                        .ToList();

                    if (!top.Any())
                    {
                        Console.WriteLine("No results.");
                        continue;
                    }

                    int pos = 1;
                    foreach (var r in top)
                    {
                        Console.WriteLine($"{pos}. {r.UserLogin} | {r.Score}");
                        pos++;
                    }
                }

                if (choice == 4)
                {
                    Console.WriteLine("1 Change password\n2 Change birth date");

                    int set = int.Parse(Console.ReadLine());

                    if (set == 1)
                    {
                        Console.Write("New password: ");
                        currentUser.Password = Console.ReadLine();
                    }

                    if (set == 2)
                    {
                        Console.Write("New birth date: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime d))
                            currentUser.DateOfBirth = d;
                    }

                    using FileStream fs = new FileStream(user_path, FileMode.Create);
                    JsonSerializer.Serialize(fs, users, options);

                    Console.WriteLine("Saved!");
                }

                if (choice == 5)
                {
                    if (!currentUser.IsAdmin)
                    {
                        Console.WriteLine("Access denied! Admins only.");
                        continue;
                    }

                    OpenEditor(allQuestions, questions_path, options);
                }
            }
        }
    }

    public class User
    {
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User() { }

        public User(string login, string password, DateTime date, bool isAdmin = false)
        {
            Login = login;
            Password = password;
            DateOfBirth = date;
            IsAdmin = isAdmin;
        }
    }

    

    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public List<int> CorrectIndexes { get; set; }
        public string Category { get; set; }

        public Question(string text, List<string> options, List<int> correctIndexes, string category)
        {
            Text = text;
            Options = options;
            CorrectIndexes = correctIndexes;
            Category = category;
        }
    }

    public class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public int Score { get; set; }

        public Quiz(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
        }

        public void Run()
        {
            Score = 0;

            foreach (var q in Questions)
            {
                Console.WriteLine(q.Text);
                for (int i = 0; i < q.Options.Count; i++)
                    Console.WriteLine($"{i + 1} - {q.Options[i]}");

                Console.WriteLine("Enter all correct answers separated by commas (e.g. 1,3):");
                string input = Console.ReadLine();
                var selected = input.Split(',').Select(x =>
                {
                    int.TryParse(x.Trim(), out int v);
                    return v - 1;
                }).ToList();

                var correct = q.CorrectIndexes.OrderBy(x => x);
                var selectedSorted = selected.OrderBy(x => x);

                if (selectedSorted.SequenceEqual(correct))
                {
                    Console.WriteLine("Correct!\n");
                    Score++;
                }
                else
                {
                    Console.WriteLine("Incorrect\n");
                }
            }

            Console.WriteLine($"Correct answers: {Score}\n");
        }
    }

    public class QuizResult
    {
        public string UserLogin { get; set; }
        public string QuizName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public QuizResult(string user, string quiz, int score, DateTime date)
        {
            UserLogin = user;
            QuizName = quiz;
            Score = score;
            Date = date;
        }

        public QuizResult() { }

        public void Print()
        {
            Console.WriteLine($"{QuizName} | {Score} | {Date}");
        }
    }

    public class QuizEditor
    {
        private List<Question> questions;

        public QuizEditor(List<Question> questions)
        {
            this.questions = questions;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== QUIZ EDITOR ===");
                Console.WriteLine("1 - Add question");
                Console.WriteLine("2 - Edit question");
                Console.WriteLine("3 - Delete question");
                Console.WriteLine("4 - Show all questions");
                Console.WriteLine("0 - Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddQuestion();
                        break;

                    case 2:
                        EditQuestion();
                        break;

                    case 3:
                        DeleteQuestion();
                        break;

                    case 4:
                        ShowAll();
                        break;

                    case 0:
                        return;
                }
            }
        }

        private void AddQuestion()
        {
            Console.Write("Text: ");
            string text = Console.ReadLine();

            Console.Write("Category: ");
            string cat = Console.ReadLine();

            List<string> options = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Option {i + 1}: ");
                options.Add(Console.ReadLine());
            }

            Console.Write("Correct indexes (e.g. 1,3): ");
            var correct = Console.ReadLine()
                .Split(',')
                .Select(x => int.Parse(x.Trim()) - 1)
                .ToList();

            questions.Add(new Question(text, options, correct, cat));

            Console.WriteLine("Added!");
        }

        private void EditQuestion()
        {
            ShowAll();

            Console.Write("Index: ");
            int i = int.Parse(Console.ReadLine());

            if (i < 0 || i >= questions.Count) return;

            Console.Write("New text: ");
            questions[i].Text = Console.ReadLine();

            Console.WriteLine("Updated!");
        }

        private void DeleteQuestion()
        {
            ShowAll();

            Console.Write("Index: ");
            int i = int.Parse(Console.ReadLine());

            if (i < 0 || i >= questions.Count) return;

            questions.RemoveAt(i);

            Console.WriteLine("Deleted!");
        }

        private void ShowAll()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i}. {questions[i].Text} ({questions[i].Category})");
            }
        }
    }
}