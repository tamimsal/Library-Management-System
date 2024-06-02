using System.Linq;
using BookClass;
using PatronClass;
using BookService;
using Transactions;
using PatronServices;
using utils;
using Microsoft.Extensions.DependencyInjection;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Repositories;

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
                    case 0:
                        Console.WriteLine("Please enter one of the following choices");
                        break;
    
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

                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
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
                
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Show my books");
                Console.WriteLine("2. Show all books");
                Console.WriteLine("3. exit");
                var patronScreenChoice = UtilsClass.EnterNotEmptyInt("Enter your choice: \n");
                BookServe book1 = new BookServe();
                switch(patronScreenChoice)
                {
                    case 1:
                        PatronServe.ShowPatronBooks(ref patrons, ref books);
                        break;
                    
                    case 2:
                        book1.ShowAvaliableBooks(books);
                        break;

                    case 3:
                        patronDo = false;  
                        break;
                    
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }

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
                BookServe book2 = new BookServe();
                switch(libChoice)
                {
                    case 1:
                        bookDo = true;
                        while(bookDo)
                        {
                            book2.EnterBookChoice(books,ref bookDo,ref ids);
                        }
                        break;
                    
                    case 2:
                        patronChoiceDo = true;
                        while(patronChoiceDo)
                        {
                            PatronServe.EnterPatronChoice(ref patrons, ref phoneNumbers, ref patronChoiceDo, patronId, books);
                        }
                        break;
                    case 3:
                        TransactionsServices.CheckOutBook(ref books,ref patrons);
                        break;
                    case 4:
                        libDo = false;
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
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
// id system
// N-tier 
// agile vs waterfall, scrum master
// ragex ?
// dependancy injection