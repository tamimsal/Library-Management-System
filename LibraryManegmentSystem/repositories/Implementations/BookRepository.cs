using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.Utilties;

namespace LibraryManegmentSystem.repositories.Implementations
{
    public class BookRepository : IBookRepository
    {

        public void EditBookById(ref List<Book> books)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                foreach (Book Booki in books)
                {
                    if (Booki.Avaliable == true)
                    {
                        Console.WriteLine(Booki.Id + ", " + Booki.Title + ", " + Booki.Author);
                    }
                }
                var bookId = UtilsClass.EnterNotEmptyInt("Enter book id to edit");
                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Published Date");
                Console.WriteLine("4. Book genre");
                Console.WriteLine("5. Book avaliability");
                Console.WriteLine("What do you want to edit:");
                var editChoice = UtilsClass.EnterNotEmptyInt("");
                var boo = from book in books
                    where book.Id == bookId
                    select book;
                switch (editChoice)
                {
                    case 1:
                        var newTitle = UtilsClass.EnterNotEmptyString("Enter new title:");
                        boo.First().Title = newTitle;
                        break;
                    case 2:
                        var newAuthor = UtilsClass.EnterNotEmptyString("Enter new author:");
                        boo.First().Author = newAuthor;
                        break;
                    case 3:
                        var newPd = UtilsClass.EnterNotEmptyString("Enter new Published date vy dd/mm/yyyy:");
                        boo.First().PublihedDate = newPd;
                        break;
                    case 4:
                        var newGenre = UtilsClass.EnterNotEmptyString("Enter new genre:");
                        boo.First().Genre = newGenre;
                        break;
                    case 5:
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Not Avaliable");
                        Console.WriteLine("Enter new avaliability:");
                        var newAva = UtilsClass.EnterNotEmptyInt("");
                        if (newAva == 1)
                        {
                            boo.First().Avaliable = true;
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else if (newAva == 0)
                        {
                            boo.First().Avaliable = false;
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else
                        {
                            Console.WriteLine("Choose only 1 or 2 \n status not changed");
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
        }

        public void DeleteBook(ref List<Book> books, int id)
        {
            var toDeleteBook = from bookq in books
                where bookq.Id == id
                select bookq;
            books.Remove(toDeleteBook.First());
        }

        public void AddBook(Book book, ref List<Book> books)
        {
            // return guid id
            books.Add(book);
        }

        public Book GetBook(int id, List<Book> books)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }
    }
}