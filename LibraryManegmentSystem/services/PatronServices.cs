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
                Console.WriteLine("2. Show all Patrons");
                Console.WriteLine("3. Edit Patron info.");
                Console.WriteLine("4. Show books borrowed by patron");
                Console.WriteLine("5. Back");
                int patronChoice = UtilsClass.EnterNotEmptyInt("");
                switch(patronChoice){
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
                
                foreach(var id in borrowed)
                {
                    var booki = from booka in books
                                where booka.id == id.First().id
                                select booka;
                    Console.WriteLine(booki.First().title);
                }
            }
            catch
            {

            }
        }
        
    }

}