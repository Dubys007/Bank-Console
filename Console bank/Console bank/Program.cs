namespace Console_bank
{
    using System;
    using System.Collections.Generic;

    class User
    {
        public string Username { get; }
        public string Password { get; }
        public decimal Balance { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Balance = 0;
        }
    }

    class ATM
    {
        private List<User> users;
        private User currentUser;

        public ATM()
        {
            users = new List<User>();
            currentUser = null;
        }

        public void DisplayStartupMenu()
        {
            Console.WriteLine("========== ATM Menu ==========");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("==============================");
        }

        public void LogIn(string username, string password)
        {
            User user = users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                currentUser = user;
                Console.WriteLine($"Logged in as {currentUser.Username}");
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }

        public void CreateUser(string username, string password)
        {
            User existingUser = users.Find(u => u.Username == username);
            if (existingUser != null)
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
            }
            else
            {
                User newUser = new User(username, password);
                users.Add(newUser);
                Console.WriteLine("Account created successfully. Please log in.");
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("========== ATM Menu ==========");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Log Out");
            Console.WriteLine("==============================");
        }

        public void CheckBalance()
        {
            if (currentUser != null)
            {
                Console.WriteLine($"Your current balance is: {currentUser.Balance}");
            }
            else
            {
                Console.WriteLine("Please log in to check your balance.");
            }
        }

        public void Deposit(decimal amount)
        {
            if (currentUser != null)
            {
                currentUser.Balance += amount;
                Console.WriteLine($"Successfully deposited {amount}");
                Console.WriteLine($"New balance: {currentUser.Balance}");
            }
            else
            {
                Console.WriteLine("Please log in to deposit funds.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (currentUser != null)
            {
                if (amount > currentUser.Balance)
                {
                    Console.WriteLine("Insufficient funds");
                }
                else
                {
                    currentUser.Balance -= amount;
                    Console.WriteLine($"Successfully withdrew {amount}");
                    Console.WriteLine($"New balance: {currentUser.Balance}");
                }
            }
            else
            {
                Console.WriteLine("Please log in to withdraw funds.");
            }
        }

        public void LogOut()
        {
            if (currentUser != null)
            {
                Console.WriteLine($"Logged out from {currentUser.Username}");
                currentUser = null;
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            while (true)
            {
                atm.DisplayStartupMenu();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your username: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string loginPassword = Console.ReadLine();
                        atm.LogIn(loginUsername, loginPassword);
                        break;
                    case "2":
                        Console.Write("Enter a username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter a password: ");
                        string password = Console.ReadLine();
                        atm.CreateUser(username, password);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }


}