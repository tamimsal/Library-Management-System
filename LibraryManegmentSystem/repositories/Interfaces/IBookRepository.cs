using BookClass;

namespace LibraryManagementSystem.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(List<Book> books, ref int ids);
        
        void EditBookById(List<Book> books);
        void DeleteBook(List<Book> books);
        void AddBook(Book newBook);
    }
}
