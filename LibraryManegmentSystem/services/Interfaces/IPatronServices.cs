using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.services.Interfaces
{
    public interface IPatronServices
    {
        void ShowAllPatrons();
        void ShowPatronBooks();
        int SearchForAPatron();
        int ChoosePatronById();

    }
}

