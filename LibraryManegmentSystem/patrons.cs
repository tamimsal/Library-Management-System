using System.Threading.Tasks.Dataflow;
using MainProgram;
using PatronClass;
using BookClass;

namespace PatronManegment
{
    class MainPat
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
                        Console.WriteLine("Enter new patron name");
                        var newName = Console.ReadLine();
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.patId)
                            {
                                patroni.name = newName;
                            }
                        } 
                        break;
                    case 2:
                        var newEmail = EnterPatronEmail();
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.patId)
                            {
                                patroni.email = newEmail;
                            }
                        } 
                        break;
                    case 3:
                        var newPhone = EnterPatronPhoneNumber(phoneNumbers);
                        foreach(Patron patroni in patrons)
                        {
                            if(patronIdtoEdit == patroni.patId)
                            {
                                patroni.phoneNumber = newPhone;
                            }
                        } 
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

        public static void AddPatron(ref List<Patron>patrons, ref List<string>phoneNumbers, int patronId)
        {
            try{
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter patron name:");
                var patronName = Console.ReadLine();

                var patronEmail = EnterPatronEmail();

                var patronPhone = EnterPatronPhoneNumber(phoneNumbers);
                patronId++;
                List<Book> borroweds = new List<Book>();
                Patron newPatron = new Patron(patronId,patronName, patronPhone, patronEmail, borroweds);
                patrons.Add(newPatron);
            }
            catch
            {

            }
        }

        public static string EnterPatronEmail()
        {
            string patronEmail = "";
            try
            {
                bool isOk = false;
                while(!isOk){
                    Console.WriteLine("Enter patron email:");
                    patronEmail = Console.ReadLine();
                    int firstCheckAt = patronEmail.IndexOf('@');
                    int secondCheckDot = patronEmail.IndexOf('.');
                    if(firstCheckAt < secondCheckDot && firstCheckAt > 0 && secondCheckDot < patronEmail.Length-1 && secondCheckDot - firstCheckAt > 1){
                        isOk = true;
                    }
                    else{
                        Console.WriteLine("Please enter valid email: name@exmaple.com");
                    }
                }
            }
            catch
            {
                
            }
            return patronEmail;
        }   

        public static string EnterPatronPhoneNumber(List<string> phoneNumbers)
        {
            string phoneNumber = "";
            bool isOk = false;
            try
            {
                while(!isOk)
                {
                    Console.WriteLine("Enter patron phone number:");
                    phoneNumber = Console.ReadLine();
                    int numric;
                    bool isNumeric = int.TryParse(phoneNumber, out numric);
                    if(isNumeric && phoneNumber.Length == 10 && !phoneNumbers.Contains(phoneNumber))
                    {
                        isOk = true;
                        phoneNumbers.Add(phoneNumber);
                    }
                    else{
                        Console.WriteLine("Please enter correct phone number: only numbers, not duplicated and 10 digits");
                    }
                }
            }
            catch
            {

            }
            return phoneNumber;
        }

        
}
    }
    


