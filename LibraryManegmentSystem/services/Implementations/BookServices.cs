using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.services.Interfaces;
using LibraryManegmentSystem.Utilties;

namespace LibraryManegmentSystem.services.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;
        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        public void ShowAvaliableBooks()
        {
            try
            {
                List<Book> books = _bookRepository.GetAllBooks();
                if(books.Count == 0)
                {
                    Console.WriteLine("No books found");
                    return;
                }
                var avaliableBooks = from booki in books 
                    where booki.Avaliable == true
                    select booki;
                foreach (var booki in avaliableBooks)
                {
                    Console.WriteLine(booki.Number+ ", " + booki.Title + ", " + booki.Author);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public int ChooseBookById()
        {
            int bookId = 0;
            try{
                List<Book> books = _bookRepository.GetAllBooks();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("All Books");
                ShowAvaliableBooks();
                Console.WriteLine("Enter book id");
                bookId = UtilsClass.EnterNotEmptyInt("");
                var foundBook = books.FirstOrDefault(x => x.Number == bookId);
                if(foundBook.Number == bookId)
                {
                    Console.WriteLine("No books selected");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return bookId;
        }
        public int? SearchForABook()
        {
            int? idOfSearchedBook = 0;
            try
            {
                List<Book> books = _bookRepository.GetAllBooks();
                ShowAvaliableBooks();   
                Console.WriteLine("Search By:");
                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Book genre");
                var searchChoice = UtilsClass.EnterNotEmptyInt("");
                Console.WriteLine("Searh:");
                var searchWord = UtilsClass.EnterNotEmptyString("");
                var count = 0;
                switch(searchChoice)
                {
                    case 1:
                        var foundBooks = from book in books
                                         where book.Title.Contains(searchWord)
                                         select book;
                        if(idOfSearchedBook == 0)
                        {
                            idOfSearchedBook = (int)foundBooks?.FirstOrDefault()?.Number;
                        }
                        foreach(var book in foundBooks)
                        {
                            Console.WriteLine(book.Title + ", " + book.Author + ", " + book.Genre);
                            count++;
                        }
                        break;
                    case 2:
                        var foundBooksA = from book in books
                                         where book.Author.Contains(searchWord)
                                         select book;
                        
                        if(idOfSearchedBook == 0)
                        {
                            idOfSearchedBook = foundBooksA?.FirstOrDefault()?.Number;
                        }
                        foreach(var book in foundBooksA)
                        {
                            Console.WriteLine(book.Title + ", " + book.Author + ", " + book.Genre);
                            count++;
                        }                        
                        break;
                    case 3:
                        var foundBooksG = from book in books
                                         where book.Title.Contains(searchWord)
                                         select book;
                        
                        if(idOfSearchedBook == 0)
                        {
                            idOfSearchedBook = foundBooksG?.FirstOrDefault()?.Number;
                        }
                        foreach(var book in foundBooksG)
                        {
                            Console.WriteLine(book.Title + ", " + book.Author + ", " + book.Genre);
                            count++;
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
                if(count == 0)
                {
                    Console.WriteLine("No books found!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return idOfSearchedBook;
        }
    }
}