using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;

namespace LibraryManegmentSystem.repositories.Implementations
{
    public class PatronRepository : IPatronRepository
    {
        List<Patron> patrons = new();
        public void DeletePatron(int id)
        {
            try
            {
                var toDeletePatron = patrons.FirstOrDefault(x => x.Id == id);
                patrons.Remove(toDeletePatron);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void EditPatronInfoById(int patronIdtoEdit, Patron newPatron)
        {
            try
            {
                var patronToEdit = patrons.FirstOrDefault(x => x.Id == patronIdtoEdit);
                if (newPatron.Name != null)
                {
                    patronToEdit.Name = newPatron.Name;
                }
                else if (newPatron.Email != null)
                {
                    patronToEdit.Email = newPatron.Email;
                }
                else if (newPatron.PhoneNumber != null)
                {
                    patronToEdit.PhoneNumber = newPatron.PhoneNumber;
                }
            }   
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void AddPatron(Patron newPatron)
        {
            try
            {
                patrons.Add(newPatron);   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public List<Patron> GetAllPatrons()
        {
            return patrons;
        }
    }
}