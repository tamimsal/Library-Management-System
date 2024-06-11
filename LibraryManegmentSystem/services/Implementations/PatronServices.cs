using LibraryManegmentSystem.models;
using LibraryManegmentSystem.services.Interfaces;
using LibraryManegmentSystem.Utilties;

namespace LibraryManegmentSystem.services.Implementations
{
    class PatronServices : IPatronServices
    {
        public void ShowAllPatrons(ref List<Patron> patrons)
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
        public void ShowPatronBooks(ref List<Patron>patrons, ref List<Book>books){
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
                    Console.WriteLine(book.Title);
                }
            }
            catch
            {
            }
        }
        public int SearchForAPatron(ref List<Patron> patrons)
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
    
        public int ChoosePatronById(List<Patron> patrons)
        {
            int patronId = 0;
            try
            {
                Console.WriteLine("Patron Names:");
                foreach (Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.Id + ", " + patroni.Name + ", " + patroni.Email);
                }

                patronId = UtilsClass.EnterNotEmptyInt("Enter patron id to edit:");
                var found = from patron in patrons
                    where patron.Id == patronId
                    select patron.Id;
                if (!found.Contains(patronId))
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