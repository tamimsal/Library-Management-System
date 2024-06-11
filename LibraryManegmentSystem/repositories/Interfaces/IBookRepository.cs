using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.repositories.Interfaces
{
    public interface IBookRepository
    {
        void EditBookById(ref List<Book> books, int editChoice, int bookNumberToEdit, string newVal);
        void DeleteBook(ref List<Book> books, int number);
        void AddBook(Book newBook, ref List<Book> books);
        Book GetBook(int number, List<Book> books);

    }
}
