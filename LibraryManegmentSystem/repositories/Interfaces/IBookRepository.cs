using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.repositories.Interfaces
{
    public interface IBookRepository
    {
        void EditBookById(int bookNumberToEdit, Book newBook);
        void DeleteBook(int number);
        void AddBook(Book newBook);
        Book GetBook(int number);
        List<Book> GetAllBooks();
    }
}
