using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Midterm.App
{
    class Program
    {
        public static void PrintMenu()
        {
            Console.WriteLine("WELCOME TO THE LIBRARY TERMINAL!\n");
            Console.WriteLine("1.  Display all books");
            Console.WriteLine("2.  Search by title keyword");
            Console.WriteLine("3.  Search by author");
            Console.WriteLine("4.  Checkout book");
            Console.WriteLine("5.  Return book");
            Console.WriteLine("\n6.  QUIT");
        }
        static void Main(string[] args)
        {
            Library library = new Library();
            library.Load();
            char choice = ' ';
            int number;
            while (choice != '6')
            {
                PrintMenu();
                Console.Write("\nEnter number choice: ");
                choice = Console.ReadLine()[0];

                switch (choice)
                {
                    case '1':
                        Console.Clear();
                        library.DisplayBooks();
                      
                        break;
                    case '2':
                        Console.Clear();
                        Console.Write("Enter title keyword: ");
                        library.SearchTitle(Console.ReadLine().ToLowerInvariant());
                        break;
                    case '3':
                        Console.Clear();
                        Console.Write("Enter author: ");

                        library.SearchAuthor(Console.ReadLine().ToLowerInvariant());
                        break;
                    case '4':




                        library.DisplayBooks();

                        Console.Clear();
                        library.DisplayBooks
                            ();



                        Console.Write("Enter book number to checkout: \n");
                        if (Int32.TryParse(Console.ReadLine(), out number))
                            library.CheckoutBook(number - 1);
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                        }

                        break;
                    case '5':

                       

                        

                            Console.Write("Enter the book number to return: ");
                            if (Int32.TryParse(Console.ReadLine(), out number))
                                library.ReturnBook(number - 1);

                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                            




                        Console.Clear();
                        Console.Write("Enter the book number to return: ");
                        if (Int32.TryParse(Console.ReadLine(), out number))
                            library.ReturnBook(number - 1);
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                        }
                        break;
                       
                    case '6':
                        bool goAgain = true;
                        var DonatedList = new List<Book>();
                        Donate.ExitMessage();
                        Donate.AgainLoop(ref goAgain);
                        while (goAgain)
                        {
                            var userAuthor = Donate.GetAuthor();
                            var userTitle = Donate.GetTitle();
                            var donatedBook = Donate.DonatedBook(userTitle, userAuthor);
                            library.AddBook(donatedBook);
                            DonatedList.Add(donatedBook);
                            Console.Write("\n\tPress [Y] to donate another book or any other key to exit.  ");
                            Donate.AgainLoop(ref goAgain);
                        }
                        library.Save();
                        if (DonatedList.Count != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\tThank you for donating the following to our library:\n");
                            foreach (var item in DonatedList)
                            {
                                Console.WriteLine($"\tTitle: {item.Title}\tBy: {item.Author}");
                            }
                        }
                        Console.WriteLine("\n\n\tGood bye! Happy Reading!\a");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
            }

        }
    }
}
