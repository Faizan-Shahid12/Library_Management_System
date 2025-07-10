using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();

            program.RealMain();
        }

        public void RealMain()
        {
            int choice = -1;

            Menu menu = new Menu();

            List<Book> ListBook = null;

            Intialize_Lib(ref ListBook);

            while (choice != 5)
            {
                menu.Main_Menu();

                bool parsed = int.TryParse(Console.ReadLine(),result: out choice);

                Console.Clear();

                if (parsed && (choice <= 5 && choice >= 1))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                menu.Choice_Menu();

                                int choice1;

                                bool parsed1 = int.TryParse(Console.ReadLine(), result: out choice1);

                                Console.Clear();


                                if (parsed1 && (choice1 <= 2 && choice1 >= 1))
                                {
                                    string Type1 = "";

                                    if (choice1 == 1)
                                    {
                                        Type1 = "PrintedBook";
                                    }
                                    else if (choice1 == 2)
                                    {
                                        Type1 = "EBook";
                                    }

                                    AddBooks(ref ListBook, Type1);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input of Choice, Redirecting to Main Menu");
                                }

                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                DeleteBook(ref ListBook);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                SearchBook(ListBook);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                menu.Choice_Menu1();

                                int choice1;

                                bool parsed1 = int.TryParse(Console.ReadLine(), result: out choice1);

                                Console.Clear();

                                if (parsed1 && (choice1 <= 3 && choice1 >= 1))
                                {
                                    string Type1 = "";

                                    if (choice1 == 1)
                                    {
                                        Type1 = "PrintedBook";
                                    }
                                    else if (choice1 == 2)
                                    {
                                        Type1 = "EBook";
                                    }
                                    else if (choice1 == 3)
                                    {
                                        Type1 = "None";
                                    }

                                    ViewBooks(ListBook, Type1);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input of Choice, Redirecting to Main Menu");
                                }

                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 5:
                            Console.WriteLine("Exiting Right Now");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input of Choice, Redirecting to Main Menu");
                }

            }
        }


        public bool CheckLetters(string name)
        {
            bool check = true;

            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || name[i] == ' ')
                {
                    check = false;
                }
                else
                {
                    check = true;
                    break;
                }

            }

            return check;

        }

        public bool CheckISBN(List<Book> ListBook, string ISBN)
        {
            bool check = false;

            if (ListBook != null)
            {

                foreach (Book book in ListBook)
                {
                    if (book.ISBN == ISBN)
                    {
                        check = true;
                        break;
                    }
                    check = false;

                }

            }
            return check;
        }

        public void AddBooks(ref List<Book> ListBook, string Type)
        {
            Book newbook = null;

            Console.WriteLine("Enter the Title of the Book");
            string Vald = Console.ReadLine();
            Console.WriteLine("Enter the Author of the Book");
            string Vald1 = Console.ReadLine();
            Console.WriteLine("Enter the ISBN of the Book");
            string Vald2 = Console.ReadLine();

            if (Vald == null || Vald.Length <= 0 || Vald.Trim().Length <= 0)
            {
                Console.WriteLine("Invalid Input of Title, Redirecting to Main Menu");
                return;
            }
            if (Vald1 == null || Vald1.Length <= 0 || Vald1.TrimStart().Length <=0 || CheckLetters(Vald1))
            {
                Console.WriteLine("Invalid Input of Author Name, Redirecting to Main Menu");
                return;
            }

            if (Vald2 == null || Vald2.Length != 13 || Vald2.Trim().Length <= 0)
            {
                Console.WriteLine("The ISBN should have to 13 digits");
                Console.WriteLine("Invalid Input of ISBN, Redirecting to Main Menu");
                return;
            }

            if (CheckISBN(ListBook, Vald2))
            {
                Console.WriteLine("The Book with this ISBN is already present.");
                Console.WriteLine("Invalid Input of ISBN, Redirecting to Main Menu");
                return;
            }

            if (Type == "PrintedBook")
            {
                Console.WriteLine("Enter the Number of Pages");
                
                int num = -1;

                bool parsed1 = int.TryParse(Console.ReadLine(), result: out num);

                if (!parsed1)
                {
                    Console.WriteLine("Invalid Number of Pages, Redirecting to Main Menu");

                    return;
                }

                newbook = new PrintedBook(num);
            }
            else if (Type == "EBook")
            {
                Console.WriteLine("Enter the File Size of the EBook");

                int num = -1;

                bool parsed1 = int.TryParse(Console.ReadLine(), result: out num);

                if (!parsed1 || num >= 50)
                {
                    Console.WriteLine("The File Size should be less than 50 GB");
                    Console.WriteLine("Invalid EBook, Redirecting to Main Menu");

                    return;
                }

                newbook = new EBook(num);
            }

            if (ListBook == null)
            {
                ListBook = new List<Book>();
            }


            newbook.Title = Vald;
            newbook.Author = Vald1;
            newbook.ISBN = Vald2;

            ListBook.Add(newbook);

            Console.WriteLine("The Book has been successfully inserted");
        }

        public void DeleteBook(ref List<Book> ListBook)
        {
            if (ListBook != null)
            {

                Console.WriteLine("Enter the ISBN of the Book");
                string ISBN = Console.ReadLine();

                if (ISBN == null || ISBN.Length != 13 || ISBN.Trim().Length <= 0)
                {
                    Console.WriteLine("The ISBN should have to 13 digits");
                    Console.WriteLine("Invalid Input of ISBN, Redirecting to Main Menu");
                    return;
                }

                bool check = false;

                foreach (Book book in ListBook.ToList())
                {
                    if (book.ISBN == ISBN)
                    {
                        ListBook.Remove(book);
                        check = true;
                    }
                }
                if (check)
                {
                    Console.WriteLine("The Book has been successfully deleted");
                }
                else
                {
                    Console.WriteLine("The Book was not found in the Library");
                }

            }
            else
            {
                Console.WriteLine("The Library do not have Books");
                return ;
            }
        }

        public void SearchBook(List<Book> ListBook)
        {
            if(ListBook != null)
            {
                Console.WriteLine("Enter the title of the Book");
                string title = Console.ReadLine();

                if (title == null || title.Length <= 0 || title.Trim().Length <= 0)
                {
                    Console.WriteLine("Invalid Input of Title, Redirecting to Main Menu");
                    return;
                }

                int i = 1;

                bool check = true;

                foreach (Book book in ListBook)
                {
                    if(book.Title.Contains(title))
                    {
                        Console.Write($"{i}.");
                        book.printBook();
                        check = false;
                        i++;
                    }
                }

                if (check == true)
                {
                    Console.WriteLine("The Specificed Book cannot be found");
                }

            }
            else
            {
                Console.WriteLine("The Library do not have Books");
            }
        }

        public void ViewBooks(List<Book> ListBook, string Type)
        {
            if (ListBook != null)
            {
                int i = 1;

                for (int j = 0;j <= 100;j++)
                {
                    Console.WriteLine();
                }

                foreach (Book book in ListBook)
                {
                    if (Type.Equals("None") || book.GetType().Name.Equals(Type))
                    {
                        Console.WriteLine($"{i}.");
                        book.printBook();
                        Console.WriteLine();
                        i++;
                    }

                }
            }
            else
            {
                Console.WriteLine("The Library Do not have books");
            }
        }

        public void Intialize_Lib(ref List<Book> ListBook)
        {
            if (ListBook == null)
            {
                ListBook = new List<Book>();
            }

            ListBook.Add(new PrintedBook("C# Basics", "John Doe", "9781234567890", 250));
            ListBook.Add(new PrintedBook("Advanced C#", "Jane Smith", "9780987654321", 400));
            ListBook.Add(new PrintedBook("OOP Concepts", "Emily Clark", "9781122334455", 300));
            ListBook.Add(new PrintedBook("Design Patterns", "Robert Martin", "9785566778899", 350));
            ListBook.Add(new PrintedBook("Data Structures", "Alan Turing", "9786677889900", 280));
            ListBook.Add(new EBook("Short Story", "Isaac Asimov", "9781234567001", 45));
            ListBook.Add(new EBook("Intro to AI", "Andrew Ng", "9781234567002", 38));
            ListBook.Add(new EBook("Python Cheatsheet", "Guido van Rossum", "9781234567003", 2));
            ListBook.Add(new EBook("Data Privacy", "Shoshana Zuboff", "9781234567004", 42));
            ListBook.Add(new EBook("Microservices Guide", "Sam Newman", "9781234567005", 37));
        }
    }
}
