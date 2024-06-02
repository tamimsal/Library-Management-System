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
    public interface IBookService
    {
        void EnterBookChoice(List<Book> books, ref bool bookDo, ref int ids);
        void ShowAvaliableBooks(List<Book> books);
        int SearchForABook(List<Book> books);
        int ChooseBookById(List<Book> books);
    }

}