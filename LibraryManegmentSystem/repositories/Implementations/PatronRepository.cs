using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.Utilties;

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

        public void EditPatronInfoById(ref List<Patron>patrons, ref List<string>phoneNumbers)
        {
            try
            {
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.Id + ", " + patroni.Name + ", " + patroni.Email);
                }
                var patronIdtoEdit = UtilsClass.EnterNotEmptyInt("Enter patron id to edit:");
                Console.WriteLine("1. Patron name");
                Console.WriteLine("2. Patron email");
                Console.WriteLine("3. Patron phone number");
                Console.WriteLine("What do you want to edit:");
                var editChoice = UtilsClass.EnterNotEmptyInt("");
                switch(editChoice)
                {
                    case 1:
                        var newName = UtilsClass.EnterNotEmptyString("Enter new patron name: \n");
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.Id)
                            {
                                patroni.Name = newName;
                            }
                        } 
                        break;
                    case 2:
                        var newEmail = UtilsClass.EnterPatronEmail();
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.Id)
                            {
                                patroni.Email = newEmail;
                            }
                        } 
                        break;
                    case 3:
                        var newPhone = UtilsClass.EnterPatronPhoneNumber(phoneNumbers);
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.Id)
                            {
                                patroni.PhoneNumber = newPhone;
                            }
                        } 
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
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