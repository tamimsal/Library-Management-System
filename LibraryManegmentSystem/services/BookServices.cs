using BookClass;
using MainProgram;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using PatronClass;
using Transactions;
using utils;
namespace BookService
{
    class BookServe 
    {
        public static void EnterBookChoice(List<Book> books,ref bool bookDo, int ids)
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
                        AddBook(books, ids);
                        break;
                    
                    case 2:
                        ShowAvaliableBooks(books);
                        break;

                    case 3:
                        EditBookById(books);
                        break;
                    
                    case 4:
                        DeleteBook(books);
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
        static void AddBook(List<Book>books, int ids)
        {
            try{
                string bookTitle = UtilsClass.EnterNotEmptyString("Enter book title: \n");
                string bookAuthor = UtilsClass.EnterNotEmptyString("Enter book author: \n");
                string publihedDate = UtilsClass.EnterNotEmptyString("Enter book published date in dd/mm/yyyy : \n");
                string? bookGenre = UtilsClass.EnterNotEmptyString("Enter book genre: \n");
                ids++;
                DateTime borrowedDate = DateTime.Now ,dateToBeRet = DateTime.Now;
                int PatId = 0;
                Book newBook = new Book(ids,bookTitle,bookAuthor,publihedDate,bookGenre, true,borrowedDate,dateToBeRet,PatId);
                books.Add(newBook);
            }
            catch{
                Console.WriteLine("Error, be careful");
            }   
        }
        public static void ShowAvaliableBooks(List<Book> books)
        {
            try{
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
        static void EditBookById(List<Book> books){
            try{
                Console.WriteLine("--------------------------------");
                foreach(Book Booki in books){
                    if(Booki.avaliable == true){
                        Console.WriteLine(Booki.id + ", " + Booki.title + ", " + Booki.author);
                    }
                }
                Console.WriteLine("Enter book id to edit");
                var bookId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Published Date");
                Console.WriteLine("4. Book genre");
                Console.WriteLine("5. Book avaliability");
                Console.WriteLine("What do you want to edit:");
                var editChoice = UtilsClass.EnterNotEmptyInt("");
                var boo = from book in books
                                  where book.id == bookId
                                  select book;
                switch(editChoice)
                {
                    case 1:
                        var newTitle = UtilsClass.EnterNotEmptyString("Enter new title:");
                        boo.First().title = newTitle;
                        break;
                    case 2:
                        var newAuthor = UtilsClass.EnterNotEmptyString("Enter new author:");
                        boo.First().author = newAuthor;
                        break;
                    case 3:
                        var newPd = UtilsClass.EnterNotEmptyString("Enter new Published date vy dd/mm/yyyy:");
                        boo.First().publihedDate = newPd;
                        break;
                    case 4:
                        var newGenre = UtilsClass.EnterNotEmptyString("Enter new genre:");
                        boo.First().genre = newGenre;
                        break;
                    case 5:
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Not Avaliable");
                        Console.WriteLine("Enter new avaliability:");
                        var newAva = UtilsClass.EnterNotEmptyInt("");
                        if(newAva == 1)
                        {
                            boo.First().avaliable = true;
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else if(newAva == 0)
                        {
                            boo.First().avaliable = false;
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else{
                            Console.WriteLine("Choose only 1 or 2 \n status not changed");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
            }
            catch{
            }
        }
        static void DeleteBook(List<Book> books)
        {
            try
            {
                int searchChoice;
                Console.WriteLine("Delete By: ");
                Console.WriteLine("1. Book Id");
                Console.WriteLine("2. Search for a book");
                searchChoice = UtilsClass.EnterNotEmptyInt("");
                int bookID = 0;
                switch(searchChoice)
                {
                    case 1:
                        bookID = ChooseBookById(books);
                        break;
                    case 2:
                        bookID = SearchForABook(books);
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
                var toDeleteBook = from bookq in books
                                   where bookq.id == bookID
                                   select bookq;
                books.Remove(toDeleteBook.First());
                Console.WriteLine("Book deleted Successfully");
            }   
            catch
            {
            }
        }
        public static int SearchForABook(List<Book> books){
            var idOfSearchedBook = 0;
            try
            {
                Console.WriteLine("Search By:");
                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Book genre");
                var searchChoice = UtilsClass.EnterNotEmptyInt("");

                Console.WriteLine("All books");
                foreach (Book booki in books)
                {
                    if(booki.avaliable == true){
                        Console.WriteLine(booki.title + ", " + booki.author + ", " + booki.genre);
                    }
                }
                Console.WriteLine("Searh:");
                var searchWord = UtilsClass.EnterNotEmptyString("");

                switch(searchChoice)
                {
                    case 1:
                        foreach(Book booki in books)
                        {
                            if(booki.title.Contains(searchWord))
                            {   
                                if(idOfSearchedBook == 0)
                                {
                                    idOfSearchedBook = booki.id;
                                }
                                Console.WriteLine(booki.title + ", " + booki.author + ", " + booki.genre);
                            }
                        }
                        break;

                    case 2:
                        foreach(Book booki in books)
                        {
                            if(booki.author.Contains(searchWord))
                            {
                                if(idOfSearchedBook == 0)
                                {
                                    idOfSearchedBook = booki.id;
                                }
                                Console.WriteLine(booki.title + ", " + booki.author + ", " + booki.genre);
                            }
                        }
                        break;
                    
                    case 3:
                        foreach(Book booki in books)
                        {
                            if(booki.genre.Contains(searchWord))
                            {
                                if(idOfSearchedBook == 0)
                                {
                                    idOfSearchedBook = booki.id;
                                }
                                Console.WriteLine(booki.title + ", " + booki.author + ", " + booki.genre);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
            }
            catch
            {

            }
            return idOfSearchedBook;
        }

        static int ChooseBookById(List<Book> books)
        {
            int bookId = 0;
            try{
                Console.WriteLine("--------------------------------");
                Console.WriteLine("All Books");
                foreach(Book Booki in books){
                    if(Booki.avaliable == true){
                        Console.WriteLine(Booki.id + ", " + Booki.title + ", " + Booki.author);
                    }
                }
                Console.WriteLine("Enter book id to edit");
                bookId = UtilsClass.EnterNotEmptyInt("");
            }
            catch
            {
            }
            return bookId;
        }
    }
}