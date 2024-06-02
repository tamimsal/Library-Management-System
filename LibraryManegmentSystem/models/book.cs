namespace BookClass
{
    public class Book
    {
        public int id {get; set;}
        public string title {set;get;}
        public string author {get; set;}
        public string publihedDate {set; get;}
        public string genre {set; get;}

        public bool avaliable {get;set;}
        public DateTime borrowDate {set; get;}
        public DateTime toBeRetaurnedDate {set; get;}

        public int borrowById {set; get;}

        // public Book(int newId, string newTitle, string newAuthor, string newPD, string newGenre, bool newava, DateTime dateBorrowed, DateTime beReturedDate, int IdBorrowed){
        //     id = newId;
        //     title = newTitle;
        //     author = newAuthor;
        //     publihedDate = newPD;
        //     genre = newGenre;
        //     avaliable = newava;
        //     borrowDate = dateBorrowed;
        //     toBeRetaurnedDate = beReturedDate;
        //     borrowById = IdBorrowed;
        // }
        //
        // public Book(){
        //
        // }
    }

}