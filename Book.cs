using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    abstract public class Book
    {
        private string title;
        private string author;
        private string iSBN;

        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }

        public string ISBN {  get { return iSBN; } set { iSBN = value; } }

        public Book()
        {

        }

        public Book(string title,string author,string ISBN1)
        {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN1;
        }

        public virtual void printBook()
        {
            
        }
    }
}
