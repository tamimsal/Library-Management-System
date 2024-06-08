using System.Net.Mail;
using System.Text.RegularExpressions;

namespace LibraryManegmentSystem.Utilties
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
            string pattern = @"0\d{9}";
            Regex isCorrectPhoneNumber = new Regex(pattern);
            
            bool isOk = false;
            try
            {
                while(!isOk)
                {
                    phoneNumber = EnterNotEmptyString("Enter patron phone number:");
                    int numric;
                    if(isCorrectPhoneNumber.IsMatch(phoneNumber))
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
                string pattern = @"\w{1,50}@\w{1,50}.\w{1.50}";
                Regex isEmailOk = new Regex(pattern);
                while(!isOk){
                    patronEmail = EnterNotEmptyString("Enter patron email:");
                    try
                    {
                        MailAddress isMail = new MailAddress(patronEmail);
                        isOk = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter valid email: name@exmaple.com");
                        isOk = false;
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