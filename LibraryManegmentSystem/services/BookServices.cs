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
                        BookCRUD.AddBook(books, ids);
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

        public static int ChooseBookById(List<Book> books)
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