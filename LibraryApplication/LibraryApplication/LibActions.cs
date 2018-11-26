using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryApplication
{
    class LibActions : LibApp
    {
        public static void UpdateFileList(List<Book> entries)
        {
            var filepath = BookList.GetFilePath();
            List<string> output = new List<string>();
            foreach (var bookItem in entries)
            {
                output.Add($"{bookItem.Title}," +
                    $"{bookItem.Author},{bookItem.Status}," +
                    $"{bookItem.DueDate}");
            }
            File.WriteAllLines(filepath, output);
        }

        public static DateTime ReturnDate()
        {
            var dueDate = DateTime.Now;
            var returnDate = dueDate.AddDays(14);
            return returnDate;
        }

        public static string CheckOutBook(Book book)
        {
            book.Status = "Unavailable";
            return book.Status;
        }

        public static List<Book> CheckedInBooks(List<Book> entries)
        {
            List<Book> checkedInBooks = entries.Where(x => x.Status == "Available").ToList();
            return checkedInBooks;
        }

        public List<Book> CheckedOutBooks(List<Book> entries)
        {
            List<Book> checkedOutBooks = entries.Where(x => x.Status == "Unavailable").ToList();
            return checkedOutBooks;
        }

        public static List<Book> Entries()
        {
            var filepath = BookList.GetFilePath();
            var getEntries = new BookList();
            var entries = getEntries.Entries(filepath);
            return entries;
        }

        public static List<Book> WriteCatalog(List<Book> entries)
        {
            Entries();
            var i = 1;
            Console.WriteLine("We have the following books: ");
            foreach (var bookItem in entries)
            {
                Console.Write($"{i}.  Title: {bookItem.Title.PadRight(25)} Author Name: " +
                    $"{ bookItem.Author.PadRight(25)} Status: {bookItem.Status}\n");
                i++;
            }
            return entries;
        }
        
    }
}
