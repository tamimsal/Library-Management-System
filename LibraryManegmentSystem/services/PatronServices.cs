using PatronClass;
using BookClass;
using utils;




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
                int patronChoice = Convert.ToInt32(Console.ReadLine());
                
                switch(patronChoice){
                    case 1:
                        AddPatron(ref patrons, ref phoneNumbers, patronId);
                        break;
                    case 2:
                        ShowAllPatrons(ref patrons);
                        break;

                    case 3:
                        EditPatronInfoById(ref patrons, ref phoneNumbers);
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
        public static void EditPatronInfoById(ref List<Patron>patrons, ref List<string>phoneNumbers)
        {
            try
            {
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.patId + ", " + patroni.name + ", " + patroni.email);
                }
                Console.WriteLine("Enter patron id to edit:");
                var patronIdtoEdit = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("1. Patron name");
                Console.WriteLine("2. Patron email");
                Console.WriteLine("3. Patron phone number");
                Console.WriteLine("What do you want to edit:");
                var editChoice = Convert.ToInt32(Console.ReadLine());

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
        public static void ShowPatronBooks(ref List<Patron>patrons, ref List<Book>books){
            try{
                Console.WriteLine("Patron Names:");
                foreach(Patron patroni in patrons)
                {
                    Console.WriteLine(patroni.patId + ", " + patroni.name + ", " + patroni.email);
                }
                Console.WriteLine("Enter patron id to show books:");
                var patronIdtoShow = Convert.ToInt32(Console.ReadLine());
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