using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;

namespace LibraryManegmentSystem.repositories.Implementations
{
    public class PatronRepository : IPatronRepository
    {
        public void DeletePatron(ref List<Patron> patrons, int id)
        {
            var toDeletePatron = from patron in patrons
                where patron.Id == id
                select patron;
            patrons.Remove(toDeletePatron.First());
        }
        public void EditPatronInfoById(ref List<Patron> patrons, int patronIdtoEdit, Patron newPatron)
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
            catch
            {
            }
        }
        public void AddPatron(ref Patron newPatron, ref List<Patron> patrons)
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
    }
}