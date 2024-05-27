using utils;
using BookClass;
using BookService;

namespace BookRepos
{
    class BookCRUD
    {
        public static void AddBook(List<Book>books, ref int ids)
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
        public static void EditBookById(List<Book> books){
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
        public static void DeleteBook(List<Book> books)
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
                        bookID = BookServe.ChooseBookById(books);
                        break;
                    case 2:
                        bookID = BookServe.SearchForABook(books);
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
    }
}