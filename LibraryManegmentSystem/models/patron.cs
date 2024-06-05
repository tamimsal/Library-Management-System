using BookClass;

namespace PatronClass
{
    public class Patron
    {
        public int Id {set; get;}
        public string? Name {set; get;}
        public string? PhoneNumber {set; get;}
        public string? Email {set; get;}
        public List<Book>? BorrowedBooks {set; get;}
    }
}