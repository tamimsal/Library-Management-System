using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.Utilties;

namespace LibraryManegmentSystem.repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        // move books/ patrons here 
        //public List<Book> books = new();

        public void EditBookById(ref List<Book> books, int bookNumberToEdit, Book newBook)
        {
            try
            {
                var bookToEdit = books.FirstOrDefault(x => x.Number == bookNumberToEdit);
                
                if (newBook.Avaliable != null)
                {
                    bookToEdit.Avaliable = newBook.Avaliable;
                }
                else if (newBook.Author != null)
                {
                    bookToEdit.Author = newBook.Author;
                }
                else if (newBook.Title != null)
                {
                    bookToEdit.Title = newBook.Title;
                }
                else if (newBook.PublihedDate != null)
                {
                    bookToEdit.PublihedDate = newBook.PublihedDate;
                }
                else if (newBook.Genre != null)
                {
                    bookToEdit.Genre = newBook.Genre;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public void DeleteBook(ref List<Book> books, int number)
        {
            try
            {
                var toDeleteBook = books.FirstOrDefault(x => x.Number == number);
                books.Remove(toDeleteBook);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddBook(Book book, ref List<Book> books)
        {
            try
            {
                books.Add(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // return guid id
        }

        public Book GetBook(int number, List<Book> books)
        {
            try
            {
                return books.FirstOrDefault(x => x.Number == number); // use this
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}