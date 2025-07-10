using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Menu
    {
        public Menu()
        {

        }

        public void Main_Menu()
        {
                Console.WriteLine("Select One of the following options");
                Console.WriteLine("1. Add new Book");
                Console.WriteLine("2. Delete old Book by ISBN");
                Console.WriteLine("3. Search Book by BookName");
                Console.WriteLine("4. View all Books");
                Console.WriteLine("5. Exit");
            
        }

        public void Choice_Menu()
        {
            Console.WriteLine("Select One of the following options");
            Console.WriteLine("1. Printed Book");
            Console.WriteLine("2. E Book");
        }
        public void Choice_Menu1()
        {
            Console.WriteLine("Select One of the following options");
            Console.WriteLine("1. Printed Book");
            Console.WriteLine("2. E Book");
            Console.WriteLine("3. All Types");
        }

    }
}
