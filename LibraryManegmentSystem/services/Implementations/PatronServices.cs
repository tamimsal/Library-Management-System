using PatronClass;
using BookClass;
using utils;
using PatronRepos;
using LibraryManagementSystem.Interfaces;
namespace PatronServices
{
    class PatronServe : IPatronServices
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
                Console.WriteLine("6. Delete patron");
                Console.WriteLine("7. Back");
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
                        PatronCRUD.DeletePatron(patrons);
                        break;
                    case 7:
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
                    Console.WriteLine(patroni.Name);
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
                    Console.WriteLine(patroni.Id + ", " + patroni.Name + ", " + patroni.Email);
                }
                Console.WriteLine("Enter patron id to show books:");
                var patronIdtoShow = UtilsClass.EnterNotEmptyInt("");
                var borrowed = from pat in patrons
                               where pat.Id == patronIdtoShow
                               select pat.BorrowedBooks;
                
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

                switch (patronSearchChoice)
                {
                    case 1:
                        var searchName = from pat in patrons
                            where pat.Name.Contains(searchValue)
                            select pat;
                        var count = 0;
                        toReutrnId = searchName.First().Id;
                        foreach (var name in searchName)
                        {
                            Console.WriteLine("{0}, {1}, {2}", name.Name, name.PhoneNumber, name.Email);
                            count++;
                        }

                        if (count == 0)
                        {
                            Console.WriteLine("No patrons found with the name: {0}", searchValue);
                        }

                        break;

                    case 2:
                        var searchEmail = from pat in patrons
                            where pat.Email.Contains(searchValue)
                            select pat;
                        var countE = 0;
                        toReutrnId = searchEmail.First().Id;
                        foreach (var name in searchEmail)
                        {
                            Console.WriteLine("{0}, {1}, {2}", name.Name, name.PhoneNumber, name.Email);
                        }

                        countE++;
                        
                        if(countE == 0)
                        {
                            Console.WriteLine("No patrons found with the email: {0}", searchValue);
                        }
                        break;

                    case 3:
                        var searchPhone = from pat in patrons
                                         where pat.PhoneNumber.Contains(searchValue)
                                         select pat;
                        var countP = 0;
                        toReutrnId = searchPhone.First().Id;
                        foreach(var name in searchPhone)
                        {
                            Console.WriteLine("{0}, {1}, {2}", name.Name, name.PhoneNumber, name.Email);
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