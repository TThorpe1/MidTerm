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
                        library.DisplayBooks();
                      
                        break;
                    case '2':
                        Console.Write("Enter title keyword: ");
                        library.SearchTitle(Console.ReadLine().ToLowerInvariant());
                        break;
                    case '3':
                        Console.Write("Enter author: ");

                        library.SearchAuthor(Console.ReadLine().ToLowerInvariant());
                        break;
                    case '4':
                        library.DisplayBooks
                            ();
                        Console.Write("Enter book number to checkout: \n");
                        if (Int32.TryParse(Console.ReadLine(), out number))
                            library.CheckoutBook(number - 1);
                        else
                        {
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
                        break;
                    case '6':
                        Console.WriteLine("\nGOODBYE\nTHANK YOU FOR USING THE LIBRARY TERMINAL!\n");
                        library.Save();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
            }

        }
    }
}
