using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.services.Interfaces
{
    public interface IPatronServices
    {
        void ShowAllPatrons(ref List<Patron> patrons);
        void ShowPatronBooks(ref List<Patron> patrons, ref List<Book> books);
        int SearchForAPatron(ref List<Patron> patrons);
        int ChoosePatronById(List<Patron> patrons);

    }
}

