namespace LibraryManegmentSystem.models
{
    public class Book
    {
        public Guid Id { set; get; }
        public int? Number {get; set;}
        public string? Title {set;get;}
        public string? Author {get; set;}
        public string? PublihedDate {set; get;}
        public string? Genre {set; get;}
        public bool? Avaliable {get;set;}
        public DateTime? BorrowDate {set; get;}
        public DateTime? ToBeRetaurnedDate {set; get;}
        public int? BorrowById {set; get;}
        
    }

}