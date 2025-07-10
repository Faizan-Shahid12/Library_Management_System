using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class PrintedBook : Book
    {
        private string BType;
        private int numberofPages;

        public int NumberofPages { get { return numberofPages; } set { numberofPages = value; } }

        public PrintedBook(int num)
        {
            this.BType = "Printed Book";
            NumberofPages = num;
        }

        public PrintedBook(string title, string author, string ISBN1, int num)
        {
            Title = title;
            Author = author;
            ISBN = ISBN1;
            this.BType = "Printed Book"; 
            NumberofPages = num;
        }
        public override void printBook()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Number of Pages: {this.numberofPages}");
            Console.WriteLine($"Type: {this.BType}");

        }
    }
}
