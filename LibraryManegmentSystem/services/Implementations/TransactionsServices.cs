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
                BookServices book1 = new BookServices();
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
                                Console.WriteLine(Booki.Id + ", " + Booki.Title + ", " + Booki.Author);
                            }
                        }
                        Console.WriteLine("Enter book id to checkout");
                        idToCheckOut = Convert.ToInt32(Console.ReadLine());
                        break;
                    
                    case 2:
                        idToCheckOut = _bookServices.SearchForABook(ref books);
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


                var ebook = from booki in books
                            where booki.Id == idToCheckOut
                            select booki;
                
                var patroned = from patroni in patrons
                               where patroni.Id == patronIdToCheckOut
                               select patroni;

                Book toAdd = ebook.First();
                patroned.First().BorrowedBooks.Add(toAdd);
                Console.WriteLine(patroned.First().BorrowedBooks.First().Title);

                ebook.First().Avaliable = false;
                ebook.First().BorrowDate = DateTime.Now;
                ebook.First().ToBeRetaurnedDate = DateTime.Now.AddDays(14);
                ebook.First().BorrowById = patronIdToCheckOut;
            }
            catch
            {
            }
        }
    }

}