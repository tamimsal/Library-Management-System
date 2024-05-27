using BookClass;
using MainProgram;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using PatronClass;
using Transactions;
using utils;
using BookRepos;

namespace BookService
{
    class BookServe 
    {
        public static void EnterBookChoice(List<Book> books,ref bool bookDo,ref int ids)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add Books");
                Console.WriteLine("2. Show avaliable books");
                Console.WriteLine("3. Edit books info.");
                Console.WriteLine("4. Delete book");
                Console.WriteLine("5. Search for a book");
                Console.WriteLine("6. Back");
                int choice = UtilsClass.EnterNotEmptyInt("");
                switch(choice){
                    case 1:
                        BookCRUD.AddBook(books,ref ids);
                        break;
                    
                    case 2:
                        ShowAvaliableBooks(books);
                        break;

                    case 3:
                        BookCRUD.EditBookById(books);
                        break;
                    
                    case 4:
                        BookCRUD.DeleteBook(books);
                        break;
                    case 5:
                        SearchForABook(books);
                        break;
                    case 6:
                        bookDo = false;
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                        
                }
            }
            catch{
            }
        }
        public static void ShowAvaliableBooks(List<Book> books)
        {
            try{
                if(books.Count == 0)
                {
                    Console.WriteLine("No books found");
                    return;
                }
                var avaliableBooks = from booki in books 
                                     where booki.avaliable == true
                                     select booki;
                foreach (var booki in avaliableBooks)
                {
                    Console.WriteLine(booki.title);
                }
            }
            catch{}
        }
        public static int SearchForABook(List<Book> books)
        {
            var idOfSearchedBook = 0;
            try
            {
                ShowAvaliableBooks(books);   
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
                                         where book.title.Contains(searchWord)
                                         select book;
                        
                        if(idOfSearchedBook == 0)
                        {
                            idOfSearchedBook = foundBooks.First().id;
                        }
                        foreach(var book in foundBooks)
                        {
                            Console.WriteLine(book.title + ", " + book.author + ", " + book.genre);
                            count++;
                        }
                        break;

                    case 2:
                        var foundBooksA = from book in books
                                         where book.author.Contains(searchWord)
                                         select book;
                        
                        if(idOfSearchedBook == 0)
                        {
                            idOfSearchedBook = foundBooksA.First().id;
                        }
                        foreach(var book in foundBooksA)
                        {
                            Console.WriteLine(book.title + ", " + book.author + ", " + book.genre);
                            count++;
                        }                        
                        break;
                    
                    case 3:
                        var foundBooksG = from book in books
                                         where book.title.Contains(searchWord)
                                         select book;
                        
                        if(idOfSearchedBook == 0)
                        {
                            idOfSearchedBook = foundBooksG.First().id;
                        }
                        foreach(var book in foundBooksG)
                        {
                            Console.WriteLine(book.title + ", " + book.author + ", " + book.genre);
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
            catch
            {

            }
            return idOfSearchedBook;
        }

        public static int ChooseBookById(List<Book> books)
        {
            int bookId = 0;
            try{
                Console.WriteLine("--------------------------------");
                Console.WriteLine("All Books");
                foreach(Book Booki in books)
                {
                    if(Booki.avaliable == true)
                    {
                        Console.WriteLine(Booki.id + ", " + Booki.title + ", " + Booki.author);
                    }
                }
                Console.WriteLine("Enter book id");
                bookId = UtilsClass.EnterNotEmptyInt("");
                var foundBook = from book in books
                                where book.id == bookId
                                select book;
                if(foundBook.First().id == bookId)
                {
                    Console.WriteLine("No books selected");
                }
            }
            catch
            {
            }
            return bookId;
        }
    }
}