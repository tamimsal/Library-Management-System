using PatronClass;
using utils;
using BookClass;
using System.Security.Cryptography.X509Certificates;

namespace PatronRepos
{
    class PatronCRUD
    {
        public static void AddPatron(ref List<Patron>patrons, ref List<string>phoneNumbers, int patronId)
        {
            try{
                Console.WriteLine("--------------------------------");
                var patronName = UtilsClass.EnterNotEmptyString("Enter patron name: \n");
                var patronEmail = UtilsClass.EnterPatronEmail();
                var patronPhone = UtilsClass.EnterPatronPhoneNumber(phoneNumbers);
                patronId++;
                List<Book> borroweds = new List<Book>();
                Patron newPatron = new Patron(patronId,patronName, patronPhone, patronEmail, borroweds);
                patrons.Add(newPatron);
            }
            catch
            {
            }
        }
        public static void EditPatronInfoById(ref List<Patron>patrons, ref List<string>phoneNumbers)
        {
            try
            {
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.patId + ", " + patroni.name + ", " + patroni.email);
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
                            if(patronIdtoEdit == patroni.patId)
                            {
                                patroni.name = newName;
                            }
                        } 
                        break;
                    case 2:
                        var newEmail = UtilsClass.EnterPatronEmail();
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.patId)
                            {
                                patroni.email = newEmail;
                            }
                        } 
                        break;
                    case 3:
                        var newPhone = UtilsClass.EnterPatronPhoneNumber(phoneNumbers);
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.patId)
                            {
                                patroni.phoneNumber = newPhone;
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
        public static void DeletePatron(List<Patron> patrons)
        {
            try
            {
                
            }
            catch
            {
            }
        }
    }
}