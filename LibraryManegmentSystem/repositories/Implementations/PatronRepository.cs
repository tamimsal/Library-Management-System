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
        public void EditPatronInfoById(ref List<Patron>patrons, int patronIdtoEdit, string newVal, int editChoice)
        {
            try
            {
                var patronToEdit = from patron in patrons
                    where patron.Id == patronIdtoEdit
                    select patron;
                switch (editChoice)
                {
                    case 1:
                        patronToEdit.First().Name = newVal;
                        break;
                    case 2:
                        patronToEdit.First().Email = newVal;
                        break;
                    case 3:
                        patronToEdit.First().PhoneNumber = newVal;
                        break;
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