using System;
using System;

using System.Collections.Generic;

using System.Globalization;

using System.IO;

using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using System.Threading.Tasks;

namespace Database4
{
    class Program
    {
        public static string path = @"C:\Users\91970\Desktop\Book\Books.txt";
        public static List<string> Books = new List<string>();
        static void Main(string[] args)
        {

            DisplayMenu();

        }
        
          public static void userInput()
        {
            string choice = Console.ReadLine();
            if (choice == "1")
            {

                DisplayBooks();
                DisplayMenu();
            }
            else if (choice == "2")
            {
                AddBooks();

                DisplayMenu();
            }
            else if (choice =="3")
            {

                Searchbooks();
                DisplayMenu();

            }
            else if(choice=="4")
            {
                Deletebooks();
                DisplayMenu();
            }

            Console.ReadLine();
        }
       


        
            public static void DisplayMenu()
            {
               
                Console.WriteLine();
                Console.WriteLine("1. Add new book entry to the file: ");
                Console.WriteLine("2. Display the data in the file: ");
                Console.WriteLine("3. Search for a book in the file :");
                Console.WriteLine("4. Delete the book from the file :");
                Console.WriteLine("5: Quit the program");
                Console.WriteLine();



                Console.WriteLine("Enter your choice");
            userInput();
            }

            public static void GetBooks()
            {

                Books = File.ReadAllLines(path).ToList();

            }
            public static void DisplayBooks()
            {
                GetBooks();
                Console.WriteLine("\n Contents of Textfile :");
                foreach (string line in Books)
                {
                    Console.WriteLine(line);
                }
                
            }
            public static void AddBooks()
            {
                String Title, Author;
                Console.WriteLine(" \n Enter Title");
                Title = Console.ReadLine();
                Console.WriteLine("Enter Author");
                Author = Console.ReadLine();
                Books.Add(Title + " " + Author);
                File.WriteAllLines(@"C:\Users\91970\Desktop\Book\Books.txt", Books);
                Console.WriteLine(Title + " by " + Author + "  added to library");
            }
            public static void Searchbooks()
            {

                Console.WriteLine("Enter Title  or Author of book");
                string search = Console.ReadLine();
                search = search.ToLower();
                foreach (string line in Books)
                {
                    if (line.Contains(search))
                    {
                        Console.WriteLine("Books with given title or author: " + line);
                    }
                else
                {
                    Console.WriteLine("No book with title");
                }
                    
                }
            }
            public static void Deletebooks()
            {
                Console.WriteLine("enter row no to delete :");

                int num;
                num = Convert.ToInt32(Console.ReadLine());
                if (num > Books.Count())

                {

                    Console.WriteLine("No Book Exits At that position Try again");

                }
                else
                {

                    Console.WriteLine("Deleted  " + Books[num - 1] + " from no " + num);
                    Books.RemoveAt(num - 1);
                    File.WriteAllLines(@"C:\Users\91970\Desktop\Book\Books.txt", Books);
                    int i = Books.Count();

                    Console.WriteLine("no of books in text file  :" + i--);


                }
            }
        }

    }



