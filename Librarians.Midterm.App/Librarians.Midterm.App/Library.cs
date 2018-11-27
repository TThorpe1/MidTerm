using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Midterm.App
{
    class Library
    {
        const string FILENAME = "books.txt";

        public List<Book> Books { get; private set; }

        public Library()
        {
            Books = new List<Book>();
        }
        public void Save()
        {
            StreamWriter fout = new StreamWriter(FILENAME);

            foreach(Book book in Books)
            {
                string status = book.Status == Book.BookStatus.OnShelf ? "On Shelf" : "Checked Out";
                fout.WriteLine(book.Title + "," + book.Author + "," + status + "," + book.DueDate.ToString("d"));
            }
            fout.Close();
        }
        public void Load()
        {
            Books.Clear();
            StreamReader fin = new StreamReader(FILENAME);

            while (!fin.EndOfStream)
            {
                string line = fin.ReadLine();

                string[] words = line.Split(',');

                Book book = new Book()
                {
                    Title = words[0],
                    Author = words[1],
                    Status = words[2] == "On Shelf" ? Book.BookStatus.OnShelf : Book.BookStatus.CheckedOut,
                    DueDate = DateTime.Parse(words[3])
                };

                AddBook(book);
                
            }
            fin.Close();
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void DisplayBooks()
        {
            int index = 1;
            foreach (Book book in Books)
            {
                Console.Write(index + ".  ");
                book.Display();

                index++;
            }
            Console.WriteLine();
        }
        public void SearchTitle(string keyword)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Title.Contains(keyword))
                    results.Add(book);
            }
            foreach (Book book in results)
            {
                book.Display();
                Console.WriteLine();
            }
        }
        public void SearchAuthor(string author)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Author.Contains(author))
                    results.Add(book);
            }
            foreach (Book book in results)
            {
                book.Display();
                Console.WriteLine();
            }
        }
        public void CheckoutBook(int index)
        {
            if (index < 0 || index >= Books.Count)
            {
                Console.WriteLine("Invalid book number");
                return;
            }
            Book target = Books[index];

            if (target.Status ==  Book.BookStatus.CheckedOut)
            {
                Console.WriteLine("Sorry!  The Book is already checked out.  Due date: " + target.DueDate.ToString("d"));
            }
            else
            {
                target.Status = Book.BookStatus.CheckedOut;
                target.DueDate = DateTime.Today.AddDays(14);
                Console.WriteLine("You checked out the book.  Due date: " + target.DueDate.ToString("d"));

            }

        }
        public void ReturnBook(int index)
        {
            if (index < 0 || index >= Books.Count)
            {
                Console.WriteLine("Invalid book numbetr");
            }
            Book target = Books[index];

            if (target.Status == Book.BookStatus.OnShelf)
            {
                Console.WriteLine("The book was already returned");
            }
            else
            {
                target.Status = Book.BookStatus.OnShelf;

                if (target.DueDate.CompareTo(DateTime.Today) ==  -1)
                {
                    Console.WriteLine("You returned the book late.  Please pay the fee of $50");
                }
                else
                {
                    Console.WriteLine("You returned the book.  Thanks for returning it on time");
                }
            }
        }
        
    }
}
