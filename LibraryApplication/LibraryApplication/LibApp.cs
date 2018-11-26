using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication
{
    class LibApp
    {

        public static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Grand Circus Public Library\n");
            Console.Write("What would you like to do today?\n\n" +
                "   Press [1] to view our catalog\n" +
                "   Press [2] to checkout a book by Author\n" +
                "   Press [3] to checkout a book by Title keyword\n" +
                "   Press [4] to return a book\n\n" +
                "Your Selection: ");
        }
        public static void UserInput()
        {
            bool goAgain = true;
            while (goAgain)
            {
                var entries = LibActions.Entries();

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        LibActions.WriteCatalog(entries);
                        goAgain = false;
                        break;
                    case "2":
                        CheckOut.ByAuthor();
                        goAgain = false;
                        break;
                    case "3":
                        //LibActions.CheckoutByTitle();
                        goAgain = false;
                        break;
                    case "4":
                        //LibActions.ReturnUserBook();
                        goAgain = false;
                        break;
                    default:
                        Console.Write("Sorry, that is not a valid entry.\n" +
                            "Please enter [1], [2], [3] or [4]: ");
                            break;
                }
            }
        }


    }

}
