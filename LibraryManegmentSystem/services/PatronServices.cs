using PatronClass;
using BookClass;
using utils;
using PatronRepos;

namespace PatronServices
{
    class PatronServe 
    {
        public static void EnterPatronChoice(ref List<Patron>patrons, ref List<string>phoneNumbers, ref bool patronChoiceDo, int patronId, List<Book>books)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add Patron");
                Console.WriteLine("2. Show all patrons");
                Console.WriteLine("3. Edit Patron info.");
                Console.WriteLine("4. Show books borrowed by patron");
                Console.WriteLine("5. Search a patron");
                Console.WriteLine("6. Back");
                int patronChoice = UtilsClass.EnterNotEmptyInt("");
                switch(patronChoice)
                {
                    case 1:
                        PatronCRUD.AddPatron(ref patrons, ref phoneNumbers, patronId);
                        break;
                    case 2:
                        ShowAllPatrons(ref patrons);
                        break;

                    case 3:
                        PatronCRUD.EditPatronInfoById(ref patrons, ref phoneNumbers);
                        break;
                    case 4:
                        ShowPatronBooks(ref patrons, ref books);
                        break;
                    case 5:
                        SeatchForAPatron(patrons);
                        break;
                    case 6:
                        patronChoiceDo = false;
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
        public static void ShowAllPatrons( ref List<Patron> patrons)
        {
            try
            {
                if(patrons.Count == 0)
                {
                    Console.WriteLine("Not patrons found");
                    return;
                }
                Console.WriteLine("Patrons Names");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.name);
                }
            }
            catch
            {
            }
        }
        public static void ShowPatronBooks(ref List<Patron>patrons, ref List<Book>books){
            try{
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.patId + ", " + patroni.name + ", " + patroni.email);
                }
                Console.WriteLine("Enter patron id to show books:");
                var patronIdtoShow = UtilsClass.EnterNotEmptyInt("");
                var borrowed = from pat in patrons
                               where pat.patId == patronIdtoShow
                               select pat.borrowedBooks;
                
                foreach(var book in borrowed.First())
                {
                    Console.WriteLine(book.title);
                }
            }
            catch
            {
            }
        }
        public static int SeatchForAPatron(List<Patron> patrons)
        {
            int toReutrnId = 0;
            try
            {
                ShowAllPatrons(ref patrons);
                Console.WriteLine("Search by: ");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Phone Number");
                var patronSearchChoice = UtilsClass.EnterNotEmptyInt("Enter your choice from above: \n");
                Console.WriteLine("Search: ");
                var searchValue = UtilsClass.EnterNotEmptyString("");

                switch(patronSearchChoice)  
                {
                    case 1:
                        var searchName = from pat in patrons
                                         where pat.name.Contains(searchValue)
                                         select pat;
                        var count = 0;
                        foreach(var name in searchName)
                        {
                            Console.WriteLine("{0}, {1}, {2}", name.name, name.phoneNumber, name.email);
                            count++;
                        }
                        if(count == 0)
                        {
                            Console.WriteLine("No patrons found with the name: {0}", searchValue);
                        }
                        break;
                    
                    case 2:
                        var searchEmail = from pat in patrons
                                         where pat.email.Contains(searchValue)
                                         select pat;
                        var countE = 0;
                        foreach(var name in searchEmail)
                        {
                            Console.WriteLine("{0}, {1}, {2}", name.name, name.phoneNumber, name.email);
                            countE++;
                        }
                        if(countE == 0)
                        {
                            Console.WriteLine("No patrons found with the email: {0}", searchValue);
                        }
                        break;

                    case 3:
                        var searchPhone = from pat in patrons
                                         where pat.phoneNumber.Contains(searchValue)
                                         select pat;
                        var countP = 0;
                        foreach(var name in searchPhone)
                        {
                            Console.WriteLine("{0}, {1}, {2}", name.name, name.phoneNumber, name.email);
                            countP++;
                        }
                        if(countP == 0)
                        {
                            Console.WriteLine("No patrons found with the phone number: {0}", searchValue);
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
            return toReutrnId;
        }
    }

}