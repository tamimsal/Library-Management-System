using bookManegment;
using MainProgram;


namespace PatronManegment
{
    class MainPat
    {

        public static void EnterPatronChoice(List<Patron>patrons, List<string>phoneNumbers, bool patronChoiceDo, int patronId)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add Patron");
                Console.WriteLine("2. Show all Patrons");
                Console.WriteLine("3. Edit Patron info.");
                Console.WriteLine("4. Back");
                int patronChoice = Convert.ToInt32(Console.ReadLine());
                
                switch(patronChoice){
                    case 1:
                        AddPatron(patrons, phoneNumbers, patronId);
                        break;
                    case 2:
                        ShowAllPatrons(patrons);
                        break;

                    case 3:
                        EditPatronInfoById(patrons, phoneNumbers);
                        break;
                    
                    case 4:
                        patronChoiceDo = false;
                        break;
                }
            }
            catch
            {

            }
        }
        public static void EditPatronInfoById(List<Patron>patrons, List<string>phoneNumbers)
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
        public static void ShowAllPatrons(List<Patron> patrons)
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

        public static void AddPatron(List<Patron>patrons, List<string>phoneNumbers, int patronId)
        {
            try{
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter patron name:");
                var patronName = Console.ReadLine();

                var patronEmail = EnterPatronEmail();

                var patronPhone = EnterPatronPhoneNumber(phoneNumbers);
                patronId++;
                Patron newPatron = new Patron(patronId,patronName, patronPhone, patronEmail);
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
    class Patron
    {
        public int patId {set; get;}
        public string name {set; get;}
        public string phoneNumber {set; get;}
        public string email {set; get;}
        public List<int> borrowedBooks {set; get;}
        public Patron(int newId, string newName, string newPhone, string newEmail){
            patId = newId;
            name = newName;
            phoneNumber = newPhone;
            email = newEmail;
        }
        public Patron(){

        }
    }


