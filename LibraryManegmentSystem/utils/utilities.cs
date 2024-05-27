namespace utils
{   
    class UtilsClass
    {
        public static string EnterNotEmptyString(string inputPrompt)
        {
            string? notEmptyString = "";
            try{
                do {
                    Console.Write(inputPrompt);
                    notEmptyString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(notEmptyString)) {
                        Console.WriteLine("OK");
                    } else {
                        Console.WriteLine("Empty input, please try again");
                    }
                } while (string.IsNullOrEmpty(notEmptyString));            
            }
            catch
            {
            }
            return notEmptyString;
        }
        public static string EnterPatronPhoneNumber(List<string> phoneNumbers)
        {
            string phoneNumber = "";
            bool isOk = false;
            try
            {
                while(!isOk)
                {
                    phoneNumber = EnterNotEmptyString("Enter patron phone number:");
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
        public static string EnterPatronEmail()
        {
            string patronEmail = "";
            try
            {
                bool isOk = false;
                while(!isOk){
                    patronEmail = EnterNotEmptyString("Enter patron email:");
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
        public static int EnterNotEmptyInt(string EnterPrompt)
        {
            int num = 0;
            try{
                Console.WriteLine(EnterPrompt);
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("You didn't enter a proper number!");
                }
            }
            catch
            {
            }
            return num;
        }
    }
}