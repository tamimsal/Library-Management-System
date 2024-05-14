class MainClass
{
    static void Main(string[] args)
    {
        var books = new List<Book>();
        var patrons = new List<Patron>();
        int ids = 0;
        int patronId = 0;
        bool doComplete = true;
        bool patronDo = true;
        bool libDo = true;  
        bool bookDo = true;
        bool patronChoiceDo = true; 
        while(doComplete)
        {
            MainScreen();
        }

        void MainScreen()
        {
            try
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Welcome to the best library EVER!");
                Console.WriteLine("Sign in as:");
                Console.WriteLine("1. Patron");
                Console.WriteLine("2. Librarian");
                Console.WriteLine("3. Exit");
                var signInChoice = 0;
                signInChoice = Convert.ToInt32(Console.ReadLine());
                libDo = true;
                switch(signInChoice)
                {
                    case 1:
                        while(patronDo)
                        {
                            PatronScreen();
                        }
                        break;
                    
                    case 2:
                        while(libDo)
                        {
                            LibrarianScreen();
                        }
                        break;
                    
                    case 3:
                        doComplete = false;
                        break;
                }

            }
            catch
            {

            }
        }
        void PatronScreen()
        {
            try
            {

            }
            catch
            {

            }
        }

        void LibrarianScreen()
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Book Magegment");
                Console.WriteLine("2. Patron Magegment");   
                Console.WriteLine("3. Back");
                var libChoice = Convert.ToInt32(Console.ReadLine());

                switch(libChoice)
                {
                    case 1:
                        bookDo = true;
                        while(bookDo)
                        {
                            EnterBookChoice();
                        }
                        break;
                    
                    case 2:
                        while(patronChoiceDo)
                        {
                            EnterPatronChoice();
                        }
                        break;
                    case 3:
                        libDo = false;
                        break;
                }

            }
            catch{

            }
        }

        void EnterPatronChoice()
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
                        AddPatron();
                        break;
                    case 2:
                        break;

                    case 3:
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

        void AddPatron()
        {
            try{
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter patron name:");
                var patronName = Console.ReadLine();

                var patronEmail = EnterPatronEmail();

                Console.WriteLine("Enter patron phone number:");
                var patronPhone = Console.ReadLine();
                patronId++;
                Patron newPatron = new Patron(patronId,patronName, patronPhone, patronEmail);
                patrons.Add(newPatron);

            }
            catch
            {

            }
        }

        string EnterPatronEmail()
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
            catch{
                
            }
            return patronEmail;
        }   

        void EnterBookChoice()
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add Books");
                Console.WriteLine("2. Show avaliable books");
                Console.WriteLine("3. Edit books info.");
                Console.WriteLine("4. Back");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch(choice){
                    case 1:
                        AddBook();
                        break;
                    
                    case 2:
                        ShowAvaliableBooks();
                        break;

                    case 3:
                        EditBookById();
                        break;
                    
                    case 4:
                        bookDo = false;
                        break;
                }
            }
            catch{

            }
        }

        void AddBook()
        {
            try{
                Console.WriteLine("Enter book title");
                string? bookTitle = Console.ReadLine();
                Console.WriteLine("Enter book author");
                string? bookAuthor = Console.ReadLine();
                Console.WriteLine("Enter book published date in dd/mm/yyyy");
                string? publihedDate = Console.ReadLine();
                Console.WriteLine("Enter book genre");
                string? bookGenre = Console.ReadLine();
                ids++;
                Book newBook = new Book(ids,bookTitle,bookAuthor,publihedDate,bookGenre, true);
                books.Add(newBook);
            }
            catch{
                Console.WriteLine("Error, be careful");
            }   
        }

        void ShowAvaliableBooks()
        {
            try{
                foreach (Book booki in books)
                {
                    if(booki.avaliable == true){
                        Console.WriteLine(booki.title);
                    }
                }
            }
            catch{}
        }

        void EditBookById(){
            try{
                Console.WriteLine("--------------------------------");
                foreach(Book Booki in books){
                    if(Booki.avaliable == true){
                        Console.WriteLine(Booki.id + ", " + Booki.title + ", " + Booki.author);
                    }
                }
                Console.WriteLine("Enter book id to edit");
                var bookId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Published Date");
                Console.WriteLine("4. Book genre");
                Console.WriteLine("5. Book avaliability");
                Console.WriteLine("What do you want to edit:");
                var editChoice = Convert.ToInt32(Console.ReadLine());
                
                switch(editChoice)
                {
                    case 1:
                        Console.WriteLine("Enter new title:");
                        var newTitle = Console.ReadLine();
                        foreach(Book booki in books)
                        {
                            if(booki.id == bookId)
                            {
                                booki.title = newTitle;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter new author:");
                        var newAuthor = Console.ReadLine();
                        foreach(Book booki in books)
                        {
                            if(booki.id == bookId)
                            {
                                booki.author = newAuthor;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter new Published date vy dd/mm/yyyy:");
                        var newPd = Console.ReadLine();
                        foreach(Book booki in books)
                        {
                            if(booki.id == bookId)
                            {
                                booki.publihedDate = newPd;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter new genre:");
                        var newGenre = Console.ReadLine();
                        foreach(Book booki in books)
                        {
                            if(booki.id == bookId)
                            {
                                booki.genre = newGenre;
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Not Avaliable");
                        Console.WriteLine("Enter new avaliability:");
                        var newAva = Convert.ToInt32(Console.ReadLine());
                        foreach(Book booki in books)
                        {
                            if(booki.id == bookId)
                            {
                                if(newAva == 1)
                                {
                                    booki.avaliable = true;
                                }
                                else
                                {
                                    booki.avaliable = false;
                                }
                            }
                        }
                        break;
                }
            }
            catch{
            }
        }
    }
}

class Book
{
    public int id {get; set;}
    public string title {set;get;}
    public string author {get; set;}
    public string publihedDate {set; get;}
    public string genre {set; get;}

    public bool avaliable {get;set;}
    public DateTime borrowDate {set; get;}
    public Book(int newId, string newTitle, string newAuthor, string newPD, string newGenre, bool newava){
        id = newId;
        title = newTitle;
        author = newAuthor;
        publihedDate = newPD;
        genre = newGenre;
        avaliable = newava;
    }
    public Book(){

    }
}

class Patron
{
    public int patId {set; get;}
    public string name {set; get;}
    public string phoneNumber {set; get;}
    public string email {set; get;}
    public List<Book> borrowedBooks {set; get;}
    public Patron(int newId, string newName, string newPhone, string newEmail){
        patId = newId;
        name = newName;
        phoneNumber = newPhone;
        email = newEmail;
    }
    public Patron(){

    }
}

