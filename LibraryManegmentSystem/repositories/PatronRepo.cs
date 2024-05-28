using PatronClass;
using utils;
using BookClass;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using PatronServices;

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
                if(patrons.Count == 0)
                {
                    Console.WriteLine("No patrons found!");
                    return;
                }
                int deleteChoice = 0;
                Console.WriteLine("Delete by:");
                Console.WriteLine("1. Search for patron");
                Console.WriteLine("2. By patron id");
                deleteChoice = UtilsClass.EnterNotEmptyInt("Enter your choice");
                int deleteId = 0;
                switch(deleteChoice)
                {
                    case 1:
                        deleteId = PatronServe.SeatchForAPatron(patrons);
                        break;
                    
                    case 2:
                        deleteId = ChoosePatronById(patrons);
                        break;
                    
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        DeletePatron(patrons);
                        break;
                }
                var toDeletePatron = from patron in patrons
                                     where patron.patId == deleteId
                                     select patron;
                patrons.Remove(toDeletePatron.First());
            }
            catch
            {
            }
        }
        static int ChoosePatronById(List<Patron> patrons)
        {
            int patronId = 0;
            try
            {
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.patId + ", " + patroni.name + ", " + patroni.email);
                }
                patronId = UtilsClass.EnterNotEmptyInt("Enter patron id to edit:");
                var found = from patron in patrons 
                            where patron.patId == patronId
                            select patron.patId;
                if(!found.Contains(patronId))
                {
                    Console.WriteLine("Please enter one of the following choices only.");
                    patronId = ChoosePatronById(patrons);
                }
            }
            catch
            {
            }
            return patronId;
        }
    }
}