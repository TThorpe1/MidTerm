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
        public List<Book> Checkout { get; set; }

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
        public void DisplayCheckedout()
        {
            foreach (Book book in Checkout)
            {
                Console.WriteLine($"You have checked out {book.Title}. It is dueback by {book.DueDate} ");

            }
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

                if (book.Title.ToLowerInvariant().Contains(keyword))
                    results.Add(book);
            }

                if (results.Count != 0)
                {

                    foreach (Book books in results)
                    {

                        books.Display();
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("\n*****No keyword by that name found in Library*****\n");
                }
            
        }
        public void SearchAuthor(string author)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in Books)
            {

                if (book.Author.ToLowerInvariant().Contains(author))
                    results.Add(book);

            }
            if (results.Count != 0)
            {
                foreach (Book book in results)
                {
                    book.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\n*****No author by that name found in Library*****\n");
            }
        }
        public void CheckoutBook(int index)
        {
            List<Book> Checkout = new List<Book>();
            
                if (index < 0 || index >= Books.Count)
                {
                    Console.WriteLine("Invalid book number");
                    return;
                }
                Book target = Books[index];

                if (target.Status == Book.BookStatus.CheckedOut)
                {
                    Console.WriteLine("Sorry!  The Book is already checked out.  Due date: " + target.DueDate.ToString("d"));
                }
                else
                {
                    target.Status = Book.BookStatus.CheckedOut;
                    target.DueDate = DateTime.Today.AddDays(14);
                    Console.WriteLine($"\nYou checked out {target.Title}.  It is due back on or before: " + target.DueDate.ToString("d"));
                    Checkout.Add(target);
                   
                }
            
           
            
        }
        public static void OverDueBookCalc(DateTime duedateInpute)
        {
            double dailyfee = .30;
            DateTime dueDate = duedateInpute;

            if (DateTime.Compare(dueDate, DateTime.Now) <= -1)
            {
                DateTime startdate = dueDate;
                DateTime returnDate = DateTime.Now;
                TimeSpan daysOutStanding = returnDate.Subtract(startdate);
                var totalFee = (daysOutStanding.TotalDays * dailyfee);
                Console.WriteLine($"Thank you for returning the book!\n"+
                $"Unfortunately your book is {Math.Round(daysOutStanding.TotalDays, 0)} days overdue,\n"+
                $"and it had a daily fee of {dailyfee}0 cents, your total fee is {Math.Round(totalFee, 2)} dollars");
            }
            else
            {
                Console.WriteLine("You returned the book.  Thanks for returning it on time");
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
                OverDueBookCalc(target.DueDate);

            }
        }
        
    }
}
