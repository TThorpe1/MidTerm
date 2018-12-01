using System;
using System.Collections.Generic;
using System.IO;


namespace Librarians.Midterm.App
{
    class Donate : Book
    {

        public static void ExitMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\tThank you for visiting the Library Terminal!\n");
            Console.WriteLine("\tBefore you go, would you consider donating a book to help our library grow??");
            Console.Write("\tPress [Y] to donate a book or any other key to exit.");
        }
        public static bool AgainLoop(ref bool goAgain)
        {

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                goAgain = true;
            }
            else
            {
                goAgain = false;
            }

            return goAgain;
        }
        public static string GetTitle()
        {
            Console.Write("\tBook title: ");
            var userTitle = Console.ReadLine();
            while (userTitle == "")
            {
                Console.Write("\tSorry, I didn't catch that. Please enter the title: ");
                userTitle = Console.ReadLine();
                Console.WriteLine();
            }
            return userTitle;
        }
        public static string GetAuthor()
        {
            Console.Clear();
            Console.WriteLine("\n\tThanks! Please provide the following information: ");
            Console.Write("\tAuthor's name: ");
            var userAuthor = Console.ReadLine();
            while (userAuthor == "")
            {
                Console.Write("\tSorry, I didn't catch that. Please enter the author's name: ");
                userAuthor = Console.ReadLine();
            }
            return userAuthor;
        }
        public static Book DonatedBook(string userTitle, string userAuthor)
        {
            var donatedBook = new Book()
            {
                Title = userTitle,
                Author = userAuthor
            };
            return donatedBook;
        }

    }
}
