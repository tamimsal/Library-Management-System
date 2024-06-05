using BookClass;

namespace LibraryManagementSystem.Interfaces
{
    public interface IBookRepository
    {
        void EditBookById(ref List<Book> books);
        void DeleteBook(ref List<Book> books, int id);
        void AddBook(Book newBook, ref List<Book> books);
        Book GetBook(int id, List<Book> books);

    }
}
