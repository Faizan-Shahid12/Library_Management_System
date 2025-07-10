using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class EBook : Book
    {
        private string BType;
        private int fileSize;

        public int FileSize { get { return fileSize; } set { fileSize = value; } }

        public EBook(int filesize)
        {
            BType = "E Book";
            FileSize = filesize;
        }

        public EBook(string title, string author, string ISBN1, int FileSize1)
        {
            Title = title;
            Author = author;
            ISBN = ISBN1;
            FileSize = FileSize1;
            this.BType = "E Book";
        }
        public override void printBook()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Type: {this.BType}");
            Console.WriteLine($"FileSize: {FileSize} GB");
        }
    }
}
