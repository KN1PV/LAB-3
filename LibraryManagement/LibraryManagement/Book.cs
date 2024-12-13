using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, bool isAvailable = true)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be empty.");

            Title = title;
            Author = author;
            IsAvailable = isAvailable;
        }
    }
}
