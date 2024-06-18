using LibraryManegmentSystem.models;

namespace LibraryManegmentSystem.repositories.Interfaces
{
    public interface IPatronRepository
    {
        void DeletePatron(int id);
        void EditPatronInfoById(int patronIdtoEdit, Patron newPatron);
        void AddPatron(Patron newPatron);
        List<Patron> GetAllPatrons();

    }
}

