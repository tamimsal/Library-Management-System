using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.services.Interfaces;

public interface ITransactionsServices
{
    public void CheckOutBook(ref List<Book> books, ref List<Patron> patrons);
}