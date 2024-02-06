using HomeTask_EFCore_26._01._2024.Data;
using HomeTask_EFCore_26._01._2024.Model;
using HomeTask_EFCore_26._01._2024.Repository;
using System.Reflection;

namespace HomeTask_EFCore_26._01._2024
{
    internal class Program
    {
        static void LoginMenu()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var bookService = new BookRepository(db);
                bookService.EnsurePopulate();

                while (true)
                {
                    Console.WriteLine("1. Show all Books\n2. Get Book by Id\n3. Log out");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            {
                                BookShow(bookService);
                                break;
                            }
                        case "2":
                            {
                                Console.Write("Enter book Id: ");
                                int bookId = int.Parse(Console.ReadLine());
                                var currentBook = new List<Book> { bookService.GetBook(bookId) };
                                DisplayTable(currentBook);
                                break;
                            }
                        case "3":
                            {
                                Main();
                                break;
                            }
                        default:
                            Console.WriteLine("Not valid input! ");
                            break;
                    }
                }
            }
        }

        static void Main()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                var userService = new UserRepository(db);
                bool a = true;
                while (a == true)
                {
                    Console.WriteLine("1. Register\n2. Login\n3. Exit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            {
                                Console.Write("Enter userName: ");
                                string userName = Console.ReadLine();
                                Console.WriteLine("Enter password: ");
                                string password = Console.ReadLine();

                                if (userService.RegisteredUser(userName, password))
                                    Console.WriteLine("The User has been successfully registered!");
                                else
                                    Console.WriteLine("Error!");
                                break;
                            }
                        case "2":
                            {
                                Console.Write("Enter userName: ");
                                string? userName = Console.ReadLine();
                                Console.WriteLine("Enter password: ");
                                string? password = Console.ReadLine();

                                if (userService.AuthorizeUser(userName, password))
                                    LoginMenu();
                                else
                                {
                                    var currentUser = db.Users.FirstOrDefault(e => e.UserName.Equals(userName));
                                    if (currentUser != null)
                                        if(currentUser.IsLocked)
                                            Console.WriteLine("The user has been blocked!");
                                        else 
                                            Console.WriteLine($"Wrong password! Remained attempts:{3 - currentUser.LoginAttempts}");
                                    else 
                                        Console.WriteLine("The userName does not exist!");
                                }

                                break;
                            }
                        case "3":
                            {
                                a = false;
                                break;
                            }
                        default:
                            Console.WriteLine("Not valid input");
                            break;
                    }
                }
            }
        }
        static void BookShow(BookRepository bookService, int page = 1)
        {
            Console.WriteLine($"Page number: {page}");
            var allBooks = bookService.GetBooks(page);
            DisplayTable(allBooks.ToList());
            Console.WriteLine("1. Next page");
            if (page > 1)
                Console.WriteLine("2. Previous page");
            Console.WriteLine("3. Back");
            int input = int.Parse(Console.ReadLine());
            if (input >= 3)
                return;
            BookShow(bookService, page += input == 1 ? 1 : -1);
        }

        static void DisplayTable<T>(List<T> collection, string[]? excludeProperties = null)
        {
            //Получаем информацию о свойствах класса Product
            PropertyInfo[] properties = excludeProperties is null ? typeof(T).GetProperties() :
                typeof(T).GetProperties().Where(e => !excludeProperties.Contains(e.Name)).ToArray();

            //Выводим заголовки колонок
            Console.WriteLine(new string('-', properties.Length * 19 + 1));
            foreach (var property in properties)
            {
                Console.Write($"|  {property.Name,-15} ");
            };
            Console.WriteLine("|");
            Console.WriteLine(new string('-', properties.Length * 19 + 1));

            //Выводим данные
            foreach (var product in collection)
            {
                foreach (var property in properties)
                {
                    Console.Write($"|  {property.GetValue(product),-15} ");
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(new string('-', properties.Length * 19 + 1));
        }
    }
}
