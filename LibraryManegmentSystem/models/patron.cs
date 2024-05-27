using BookClass;

namespace PatronClass
{
    class Patron
    {
        public int patId {set; get;}
        public string name {set; get;}
        public string phoneNumber {set; get;}
        public string email {set; get;}
        public List<Book> borrowedBooks {set; get;}
        public Patron(int newId, string newName, string newPhone, string newEmail, List<Book> borrowed){
            patId = newId;
            name = newName;
            phoneNumber = newPhone;
            email = newEmail;
            borrowedBooks = borrowed;
        }
    }
}