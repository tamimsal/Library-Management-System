using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.Utilties;

namespace LibraryManegmentSystem.repositories.Implementations
{
    public class BookRepository : IBookRepository
    {

        public void EditBookById(ref List<Book> books, int editChoice, int bookIdToEdit, string newVal)
        {
            try
            {
                var boo = from book in books
                    where book.Id == bookIdToEdit
                    select book;
                switch (editChoice)
                {
                    case 1:
                        boo.First().Title = newVal;
                        break;
                    case 2:
                        boo.First().Author = newVal;
                        break;
                    case 3:
                        boo.First().PublihedDate = newVal;
                        break;
                    case 4:
                        boo.First().Genre = newVal;
                        break;
                    case 5:
                        if (newVal == "1")
                        {
                            boo.First().Avaliable = true;
                        }
                        else
                        {
                            boo.First().Avaliable = false;
                        }
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