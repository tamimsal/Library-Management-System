using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.repositories.Interfaces
{
    public interface IPatronRepository
    {
        void DeletePatron(ref List<Patron> patrons, int id);
        void EditPatronInfoById(ref List<Patron> patrons, int patronIdtoEdit, string newVal, int editChoice);
        void AddPatron(ref Patron newPatron, ref List<Patron> patrons);

    }
}

