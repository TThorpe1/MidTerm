using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryApplication
{
    class BookList : Book
    {
        public static string GetFilePath()
        {
            var filepath = @"C:\Users\zacke\source\repos\MidTerm\LibraryData.txt";
            return filepath;
        }

        public List<Book> Entries(string filepath)
        {
            List<Book> books = new List<Book>();

            List<string> items = File.ReadAllLines(filepath).ToList();
            foreach (var item in items)
            {
                string[] entries = item.Split(',');
                Book newBook = new Book();
                newBook.Title = entries[0];
                newBook.Author = entries[1];
                newBook.Status = entries[2];
                
                books.Add(newBook);
            }
            return books;
        }
    }
}
