using BookClass;
using PatronManegment;
using MainProgram;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using PatronClass;
using Transactions;

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

                int choice = Convert.ToInt32(Console.ReadLine());
                
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
                        DeleteBook();
                        break;
                    case 5:
                        SearchForABook(books);
                        break;
                    case 6:
                        bookDo = false;
                        break;
                        
                }
            }
            catch{

            }
        }
        static void AddBook(List<Book>books, int ids)
        {
            try{
                Console.WriteLine("Enter book title");
                string? bookTitle = Console.ReadLine();
                Console.WriteLine("Enter book author");
                string? bookAuthor = Console.ReadLine();
                Console.WriteLine("Enter book published date in dd/mm/yyyy");
                string? publihedDate = Console.ReadLine();
                Console.WriteLine("Enter book genre");
                string? bookGenre = Console.ReadLine();
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
                var editChoice = Convert.ToInt32(Console.ReadLine());
                var boo = from book in books
                                  where book.id == bookId
                                  select book;
                switch(editChoice)
                {
                    case 1:
                        Console.WriteLine("Enter new title:");
                        var newTitle = Console.ReadLine();
                        boo.First().title = newTitle;

                        break;
                    case 2:
                        Console.WriteLine("Enter new author:");
                        var newAuthor = Console.ReadLine();
                        boo.First().author = newAuthor;
                        break;
                    case 3:
                        Console.WriteLine("Enter new Published date vy dd/mm/yyyy:");
                        var newPd = Console.ReadLine();
                        boo.First().publihedDate = newPd;
                        break;
                    case 4:
                        Console.WriteLine("Enter new genre:");
                        var newGenre = Console.ReadLine();
                        boo.First().genre = newGenre;
                        break;
                    case 5:
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Not Avaliable");
                        Console.WriteLine("Enter new avaliability:");
                        var newAva = Convert.ToInt32(Console.ReadLine());
                        if(newAva == 1)
                        {
                            boo.First().avaliable = true;
                        }
                        else
                        {
                            boo.First().avaliable = false;
                        }
                       
                        break;
                }
            }
            catch{
            }
        }
        static void DeleteBook()
        {
            try
            {

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
                var searchChoice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("All books");
                foreach (Book booki in books)
                {
                    if(booki.avaliable == true){
                        Console.WriteLine(booki.title + ", " + booki.author + ", " + booki.genre);
                    }
                }
                Console.WriteLine("Searh:");
                var searchWord = Console.ReadLine();

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
                }
            }
            catch
            {

            }
            return idOfSearchedBook;
        }


    }
}