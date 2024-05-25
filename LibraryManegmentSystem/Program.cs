﻿using System.Linq;
using PatronManegment;
using bookManegment;
using BookClass;
using PatronClass;
namespace MainProgram{
class MainClass
{
    static void Main(string[] args)
    {
        var books = new List<Book>();
        var patrons = new List<Patron>();
        var phoneNumbers = new List<string>();
        int patronId = 0;
        bool doComplete = true;
        bool bookDo = true;
        int ids = 0;
        bool patronDo = true;
        bool libDo = true;  
        bool patronChoiceDo = true; 

        while(doComplete)
        {
            MainScreen();
        }

        void MainScreen()
        {
            try
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Welcome to the best library EVER!");
                Console.WriteLine("Sign in as:");
                Console.WriteLine("1. Patron");
                Console.WriteLine("2. Librarian");
                Console.WriteLine("3. Exit");
                var signInChoice = 0;
                signInChoice = Convert.ToInt32(Console.ReadLine());
                switch(signInChoice)
                {
                    case 1:
                        patronDo = true;
                        while(patronDo)
                        {
                            PatronScreen();
                        }
                        break;
                    
                    case 2:
                        libDo = true;
                        while(libDo)
                        {
                            LibrarianScreen();
                        }
                        break;
                    
                    case 3:
                        doComplete = false;
                        break;
                }
            }
            catch
            {

            }
        }
        void PatronScreen()
        {
            try
            {
                
            }
            catch
            {

            }
        }

        void LibrarianScreen()
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Book Magegment");
                Console.WriteLine("2. Patron Magegment");   
                Console.WriteLine("3. Checkout a book");
                Console.WriteLine("4. Back");
                var libChoice = Convert.ToInt32(Console.ReadLine());

                switch(libChoice)
                {
                    case 1:
                        bookDo = true;
                        while(bookDo)
                        {
                            MainMan.EnterBookChoice(books,ref bookDo,ids);
                        }
                        break;
                    
                    case 2:
                        patronChoiceDo = true;
                        while(patronChoiceDo)
                        {
                            MainPat.EnterPatronChoice(ref patrons, ref phoneNumbers, ref patronChoiceDo, patronId, books);
                        }
                        break;
                    case 3:
                        MainMan.CheckOutBook(ref books,ref patrons);
                        break;
                    case 4:
                        libDo = false;
                        break;
                }

            }
            catch{

            }
        }
}
}
}
//to do: 
// empty inputs
// out of range inputs
// id system
// sign up system and login system
// Patron screen and system
// N-tier 
// agile vs waterfall, scrum master
// ragex ?
// dependancy injection