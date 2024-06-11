using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.repositories.Interfaces
{
    public interface IBookRepository
    {
        void EditBookById(ref List<Book> books, int editChoice, int bookIdToEdit, string newVal);
        void DeleteBook(ref List<Book> books, int id);
        void AddBook(Book newBook, ref List<Book> books);
        Book GetBook(int id, List<Book> books);

    }
}
