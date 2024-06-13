using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.services.Interfaces;

namespace LibraryManegmentSystem.services.Implementations
{
    class TransactionsServices : ITransactionsServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPatronRepository _patronRepository;
        private readonly IPatronServices _patronServices;
        private readonly IBookServices _bookServices;

        public TransactionsServices(IBookRepository bookRepository, IPatronRepository patronRepository,
            IPatronServices patronServices, IBookServices bookServices)
        {
            _bookRepository = bookRepository;
            _patronRepository = patronRepository;
            _patronServices = patronServices;
            _bookServices = bookServices;
        }
        public void CheckOutBook(ref List<Book> books,ref List<Patron> patrons)
        {   
            try
            {
                Console.WriteLine("All Books");
                _bookServices.ShowAvaliableBooks(ref books);
                Console.WriteLine("Choose one method:");
                Console.WriteLine("1. Checkout book by id");
                Console.WriteLine("2. Search for a book:");
                var checkOutChoice = Convert.ToInt32(Console.ReadLine());
                int idToCheckOut = 0;
                int patronIdToCheckOut = 0;
                switch(checkOutChoice)
                {
                    case 1: 
                        Console.WriteLine("--------------------------------");
                        foreach(Book Booki in books){
                            if(Booki.Avaliable == true){
                                Console.WriteLine(Booki.Number + ", " + Booki.Title + ", " + Booki.Author);
                            }
                        }
                        Console.WriteLine("Enter book id to checkout");
                        idToCheckOut = Convert.ToInt32(Console.ReadLine());
                        break;
                    
                    case 2:
                        idToCheckOut = (int)_bookServices.SearchForABook(ref books);
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.Id + ", " + patroni.Name + ", " + patroni.Email);
                }
                Console.WriteLine("Enter patron id to checkout:");
                patronIdToCheckOut = Convert.ToInt32(Console.ReadLine());
                
                Book bookToCheckOut = books.FirstOrDefault(book => book.Number == idToCheckOut);
                Patron patronToCheckOut = patrons.FirstOrDefault(patron => patron.Id == patronIdToCheckOut);

                if (bookToCheckOut == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }
                if (patronToCheckOut == null)
                {
                    Console.WriteLine("Patron not found.");
                    return;
                }

                if ((bool)bookToCheckOut.Avaliable)
                {
                    if (patronToCheckOut.BorrowedBooks == null)
                    {
                        patronToCheckOut.BorrowedBooks = new List<Book>();
                    }
                    bookToCheckOut.Avaliable = false;
                    bookToCheckOut.BorrowDate = DateTime.Now;
                    bookToCheckOut.ToBeRetaurnedDate = DateTime.Now.AddDays(14);
                    bookToCheckOut.BorrowById = patronIdToCheckOut;

                    patronToCheckOut.BorrowedBooks.Add(bookToCheckOut);

                    Console.WriteLine($"Book '{bookToCheckOut.Title}' checked out by {patronToCheckOut.Name}.");
                }
                else
                {
                    Console.WriteLine("Book is not available.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}