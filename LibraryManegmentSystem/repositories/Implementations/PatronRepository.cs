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
                switch (editChoice)
                {
                    case 1:
                        var patronToEdit = from patron in patrons
                            where patron.Id == patronIdtoEdit
                            select patron;
                        patronToEdit.First().Name = newVal;
                        break;
                    case 2:
                        var patronToEditEmail = from patron in patrons
                            where patron.Id == patronIdtoEdit
                            select patron;
                        patronToEditEmail.First().Email = newVal;
                        break;
                    case 3:
                        var patronToEditPhoneNumber = from patron in patrons
                            where patron.Id == patronIdtoEdit
                            select patron;
                        patronToEditPhoneNumber.First().PhoneNumber = newVal;
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