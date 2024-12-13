using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class User
    {
        public string Name { get; }
        public List<Book> BorrowedBooks { get; }

        public User(string name)
        {
            Name = name;
            BorrowedBooks = new List<Book>();
        }
    }
}
