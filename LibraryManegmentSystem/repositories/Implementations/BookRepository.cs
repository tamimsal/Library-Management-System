using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.Utilties;


namespace LibraryManegmentSystem.repositories.Implementations
{

    public class BookRepository : IBookRepository
    {
        // move books/ patrons here 
        List<Book> _books = new();

        public void EditBookById(int bookNumberToEdit, Book newBook)
        {
            try
            {
                
                var bookToEdit = _books.FirstOrDefault(x => x.Number == bookNumberToEdit);
                
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

        public void DeleteBook(int number)
        {
            try
            {
                var toDeleteBook = _books.FirstOrDefault(x => x.Number == number);
                _books.Remove(toDeleteBook);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddBook(Book book)
        {
            try
            {
                _books.Add(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // return guid id
        }

        public Book GetBook(int number)
        {
            try
            {
                return _books.FirstOrDefault(x => x.Number == number); // use this
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Book> GetAllBooks()
        {
            Console.WriteLine(_books.FirstOrDefault().Title);
            return _books;
        }
    }
}