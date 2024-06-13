using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.services.Interfaces
{
    public interface IBookServices
    {
        public void ShowAvaliableBooks(ref List<Book> books);
        public int ChooseBookById(ref List<Book> books);
        public int? SearchForABook(ref List<Book> books);

    }
}