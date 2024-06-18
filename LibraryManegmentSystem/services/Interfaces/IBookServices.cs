using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.services.Interfaces
{
    public interface IBookServices
    {
        public void ShowAvaliableBooks();
        public int ChooseBookById();
        public int? SearchForABook();

    }
}