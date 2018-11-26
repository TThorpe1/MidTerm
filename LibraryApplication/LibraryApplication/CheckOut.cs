using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication
{
    class CheckOut : BookList
    {
        public static List<Book> DisplayAuthors()
        {
            var entriesIn = LibActions.Entries();
            var i = 1;
            Console.WriteLine("We have the following authors: ");
            foreach (var bookItem in entriesIn)
            {
                Console.Write($"{i}.  Author: {bookItem.Author.PadRight(25)} " +
                    $"Title: {bookItem.Title.PadRight(25)} Status: {bookItem.Status}\n");
                i++;
            }
            return entriesIn;
        }

        public static int ByAuthor()
        {
            bool goAgain = true;
            int userInput = 0;
            var userCheckOuts = new List<Book>();
            var byAuthor = new List<Book>();
            while (goAgain)
            {
                Console.Clear();
                var subEntries = DisplayAuthors();
                Console.Write("Enter the number of the item you would like to check out: ");
                var userInputGet = Console.ReadLine();
                int listSize = subEntries.Count();
                foreach (var bookItem in subEntries)
                {
                    byAuthor.Add(bookItem);
                }
                while (!int.TryParse(userInputGet, out userInput) ||
                    userInput < 1 || userInput > listSize || byAuthor[userInput-1].Status == "Unavailable")
                {
                    Console.WriteLine("Sorry, that is not a valid input.");
                    Console.Write($"Please enter a number between 1 and {listSize} for a book that is Available: ");
                    userInputGet = Console.ReadLine();
                }

                userInput = userInput - 1;
               
                var dueDate = LibActions.ReturnDate();
                byAuthor[userInput].Status = "Unavailable";
                byAuthor[userInput].DueDate = dueDate;

                userCheckOuts.Add(byAuthor[userInput]);

                foreach (var bookItem in userCheckOuts)
                {
                    Console.WriteLine($"You checked out: {bookItem.Title}, " +
                        $"by {bookItem.Author}. It is due on {dueDate:MMM d, yyyy}");
                }

                LibActions.UpdateFileList(subEntries);

                Console.WriteLine();
                Console.Write("Would you like to check out another book?\n " +
                    "Press [Y] to go again or any key to go back to the main menu : ");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    goAgain = true;
                }
                else
                {
                    goAgain = false;
                }
            }
            return userInput;
        } 


    }
}

