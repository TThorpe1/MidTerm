using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Midterm.App
{
    class Book
    {
        public enum BookStatus
        {
            OnShelf,
            CheckedOut
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStatus Status { get; set; }
        public DateTime DueDate { get; set; }

        public Book()
        {
            Title = "";
            Author = "";
            Status = BookStatus.OnShelf;
            DueDate = new DateTime();
        }
        public void Display()
        {
            Console.Write("Title:  " + Title.PadRight(25) + "By: " + Author.PadRight(25));

            Console.Write(Status == BookStatus.OnShelf ? "On Shelf".PadRight(20) : "Checked Out".PadRight(20));
            if (Status == BookStatus.CheckedOut)
                Console.Write("Due on: " + DueDate.ToString("d"));
            Console.WriteLine();
        }
    }
}
