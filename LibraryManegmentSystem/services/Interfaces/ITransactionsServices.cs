using PatronClass;
using BookClass;

namespace LibraryManagementSystem.Interfaces;

public interface ITransactionsServices
{
    public void CheckOutBook(ref List<Book> books, ref List<Patron> patrons);
}