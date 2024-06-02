using BookClass;
using PatronClass;
using BookService;



namespace Transactions
{
    class TransactionsServices
    {
        public static void CheckOutBook(ref List<Book> books,ref List<Patron> patrons)
        {   
            try
            {
                BookServe book1 = new BookServe();
                Console.WriteLine("All Books");
                book1.ShowAvaliableBooks(books);
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
                            if(Booki.avaliable == true){
                                Console.WriteLine(Booki.id + ", " + Booki.title + ", " + Booki.author);
                            }
                        }
                        Console.WriteLine("Enter book id to checkout");
                        idToCheckOut = Convert.ToInt32(Console.ReadLine());
                        break;
                    
                    case 2:
                        idToCheckOut = book1.SearchForABook(books);
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
                            where booki.id == idToCheckOut
                            select booki;
                
                var patroned = from patroni in patrons
                               where patroni.Id == patronIdToCheckOut
                               select patroni;

                Book toAdd = ebook.First();
                patroned.First().BorrowedBooks.Add(toAdd);
                Console.WriteLine(patroned.First().BorrowedBooks.First().title);

                ebook.First().avaliable = false;
                ebook.First().borrowDate = DateTime.Now;
                ebook.First().toBeRetaurnedDate = DateTime.Now.AddDays(14);
                ebook.First().borrowById = patronIdToCheckOut;
            }
            catch
            {

            }
        }
    }

}