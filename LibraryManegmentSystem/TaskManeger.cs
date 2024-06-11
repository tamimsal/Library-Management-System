using LibraryManegmentSystem.models;
using LibraryManegmentSystem.repositories.Interfaces;
using LibraryManegmentSystem.services.Interfaces;
using LibraryManegmentSystem.Utilties;

namespace LibraryManegmentSystem
{
    public class TaskManegerFun
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPatronRepository _patronRepository;
        private readonly IPatronServices _patronServices;
        private readonly IBookServices _bookServices;
        private readonly ITransactionsServices _TransactionsServices;
        public TaskManegerFun(IBookRepository bookRepository, IPatronRepository patronRepository,
            IPatronServices patronServices, IBookServices bookServices, ITransactionsServices transactionsServices)
        {
            _bookRepository = bookRepository;
            _patronRepository = patronRepository;
            _patronServices = patronServices;
            _bookServices = bookServices;
            _TransactionsServices = transactionsServices;
        }

        List<Book> books = new ();
        List<Patron> patrons = new List<Patron>();
        List<string> phoneNumbers = new List<string>();
        int patronId = 0;
        bool doComplete = true;
        bool bookDo = true;
        int ids = 0;
        bool patronDo = true;
        bool libDo = true;
        bool patronChoiceDo = true;
        public void MainScreen()
        {
            try
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Welcome to the best library EVER!");
                Console.WriteLine("Sign in as:");
                Console.WriteLine("1. Patron");
                Console.WriteLine("2. Librarian");
                var signInChoice = 0;
                signInChoice = Convert.ToInt32(Console.ReadLine());
                switch (signInChoice)
                {
                    case 0:
                        Console.WriteLine("Please enter one of the following choices");
                        break;

                    case 1:
                        patronDo = true;
                        while (patronDo)
                        {
                            PatronScreen();
                        }
                        break;

                    case 2:
                        libDo = true;
                        while (libDo)
                        {
                            LibrarianScreen();
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
        void PatronScreen()
        {
            try
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Show my books");
                Console.WriteLine("2. Show all books");
                Console.WriteLine("3. exit");
                var patronScreenChoice = UtilsClass.EnterNotEmptyInt("Enter your choice: \n");
                switch (patronScreenChoice)
                {
                    case 1:
                        _patronServices.ShowPatronBooks(ref patrons, ref books);
                        break;

                    case 2:
                        _bookServices.ShowAvaliableBooks(ref books);
                        break;

                    case 3:
                        patronDo = false;
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

        void LibrarianScreen()
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Book Magegment");
                Console.WriteLine("2. Patron Magegment");
                Console.WriteLine("3. Checkout a book");
                Console.WriteLine("4. Back");
                var libChoice = Convert.ToInt32(Console.ReadLine());
                switch (libChoice)
                {
                    case 1:
                        bookDo = true;
                        while (bookDo)
                        {
                            EnterBookChoice(ref books, ref bookDo, ref ids);
                        }
                        break;

                    case 2:
                        patronChoiceDo = true;
                        while (patronChoiceDo)
                        {
                            EnterPatronChoiceScreen(ref patrons, ref phoneNumbers, ref patronChoiceDo, patronId, books);
                        }
                        break;
                    
                    case 3:
                        _TransactionsServices.CheckOutBook(ref books, ref patrons);
                        break;
                    
                    case 4:
                        libDo = false;
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
        void EnterBookChoice(ref List<Book> books, ref bool bookDo, ref int ids)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add Books");
                Console.WriteLine("2. Show avaliable books");
                Console.WriteLine("3. Edit books info.");
                Console.WriteLine("4. Delete book");
                Console.WriteLine("5. Search for a book");
                Console.WriteLine("6. Back");
                int choice = UtilsClass.EnterNotEmptyInt("");
                switch (choice)
                {
                    case 1:
                        AddBookScreen(ref books, ref ids);
                        break;

                    case 2:
                        _bookServices.ShowAvaliableBooks(ref books);
                        break;

                    case 3:
                        EditBookByIdScreen();
                        break;

                    case 4:
                        DeleteBookScreen(ref books);
                        break;
                    case 5:
                        _bookServices.SearchForABook(ref books);
                        break;
                    case 6:
                        bookDo = false;
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

        public void AddBookScreen(ref List<Book> books, ref int ids)
        {
            try
            {
                string bookTitle = UtilsClass.EnterNotEmptyString("Enter book title: \n");
                string bookAuthor = UtilsClass.EnterNotEmptyString("Enter book author: \n");
                string publihedDate = UtilsClass.EnterNotEmptyString("Enter book published date in dd/mm/yyyy : \n");
                string? bookGenre = UtilsClass.EnterNotEmptyString("Enter book genre: \n");
                ids++;
                DateTime borrowedDate = DateTime.Now, dateToBeRet = DateTime.Now;
                Guid bookGuid = new Guid();
                Book newBook = new Book()
                {
                    Title = bookTitle, Author = bookAuthor, PublihedDate = publihedDate, Genre = bookGenre,
                    BorrowDate = borrowedDate, ToBeRetaurnedDate = dateToBeRet, Avaliable = true, BorrowById = 0,
                    Number = ids, Id = bookGuid
                };
                _bookRepository.AddBook(newBook, ref books);
                //books.Add(newBook);
                Console.WriteLine(books.First().Author);
            }
            catch
            {
                Console.WriteLine("Error, be careful");
            }

        }
        public void DeleteBookScreen(ref List<Book> books)
        {
            try
            {
                int searchChoice;
                Console.WriteLine("Delete By: ");
                Console.WriteLine("1. Book Id");
                Console.WriteLine("2. Search for a book");
                searchChoice = UtilsClass.EnterNotEmptyInt("");
                int bookID = 0;
                switch (searchChoice)
                {
                    case 1:
                        bookID = _bookServices.ChooseBookById(ref books);
                        break;
                    case 2:
                        bookID = _bookServices.SearchForABook(ref books);
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        DeleteBookScreen(ref books);
                        break;
                }

                _bookRepository.DeleteBook(ref books, bookID);
                Console.WriteLine("Book deleted Successfully");
            }
            catch
            {
            }
        }

        void EnterPatronChoiceScreen(ref List<Patron> patrons, ref List<string> phoneNumbers, ref bool patronChoiceDo,
            int patronId, List<Book> books)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Add Patron");
                Console.WriteLine("2. Show all patrons");
                Console.WriteLine("3. Edit Patron info.");
                Console.WriteLine("4. Show books borrowed by patron");
                Console.WriteLine("5. Search a patron");
                Console.WriteLine("6. Delete patron");
                Console.WriteLine("7. Back");
                int patronChoice = UtilsClass.EnterNotEmptyInt("");
                switch (patronChoice)
                {
                    case 1:
                        AddPatronScreen(ref patrons, ref phoneNumbers, patronId);
                        break;
                    case 2:
                        _patronServices.ShowAllPatrons(ref patrons);
                        break;

                    case 3:
                        EditPatronInfoByIdScreen();
                        break;
                    case 4:
                        _patronServices.ShowPatronBooks(ref patrons, ref books);
                        break;
                    case 5:
                        _patronServices.SearchForAPatron(ref patrons);
                        break;
                    case 6:
                        DeletePatronScreen(ref patrons);
                        break;
                    case 7:
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
        void EditPatronInfoByIdScreen()
        {
            Console.WriteLine("Patron Names:");
            foreach(Patron patroni in patrons)
            {
                Console.WriteLine(patroni.Id + ", " + patroni.Name + ", " + patroni.Email);
            }
            var patronIdtoEdit = UtilsClass.EnterNotEmptyInt("Enter patron id to edit:");
            Console.WriteLine("1. Patron name");
            Console.WriteLine("2. Patron email");
            Console.WriteLine("3. Patron phone number");
            Console.WriteLine("What do you want to edit:");
            var editChoice = UtilsClass.EnterNotEmptyInt("");
            switch(editChoice)
            {
                case 1:
                    var newName = UtilsClass.EnterNotEmptyString("Enter new patron name: \n");
                    _patronRepository.EditPatronInfoById(ref patrons, patronIdtoEdit, newName, editChoice);
                    
                    break;
                case 2:
                    var newEmail = UtilsClass.EnterPatronEmail();
                    _patronRepository.EditPatronInfoById(ref patrons, patronIdtoEdit, newEmail, editChoice);
                    break;
                case 3:
                    var newPhone = UtilsClass.EnterPatronPhoneNumber(phoneNumbers);
                    _patronRepository.EditPatronInfoById(ref patrons, patronIdtoEdit, newPhone, editChoice);
                    break;
                default:
                    Console.WriteLine("Please enter one of the following choices only.");
                    break;
            }
        }

        void EditBookByIdScreen()
        {
            try
            {
                Console.WriteLine("--------------------------------");
                foreach (Book Booki in books)
                {
                    if (Booki.Avaliable == true)
                    {
                        Console.WriteLine(Booki.Number + ", " + Booki.Title + ", " + Booki.Author);
                    }
                }
                var bookId = UtilsClass.EnterNotEmptyInt("Enter book id to edit");
                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Published Date");
                Console.WriteLine("4. Book genre");
                Console.WriteLine("5. Book avaliability");
                Console.WriteLine("What do you want to edit:");
                var editChoice = UtilsClass.EnterNotEmptyInt("");
                var boo = from book in books
                    where book.Number == bookId
                    select book;
                switch (editChoice)
                {
                    case 1:
                        var newTitle = UtilsClass.EnterNotEmptyString("Enter new title:");
                        _bookRepository.EditBookById(ref books, editChoice, bookId,newTitle);
                        break;
                    case 2:
                        var newAuthor = UtilsClass.EnterNotEmptyString("Enter new author:");
                        _bookRepository.EditBookById(ref books, editChoice, bookId, newAuthor);

                        break;
                    case 3:
                        var newPd = UtilsClass.EnterNotEmptyString("Enter new Published date vy dd/mm/yyyy:");
                        _bookRepository.EditBookById(ref books, editChoice, bookId, newPd);

                        break;
                    case 4:
                        var newGenre = UtilsClass.EnterNotEmptyString("Enter new genre:");
                        _bookRepository.EditBookById(ref books, editChoice, bookId, newGenre);

                        break;
                    case 5:
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Not Avaliable");
                        Console.WriteLine("Enter new avaliability:");
                        var newAva = UtilsClass.EnterNotEmptyInt("");
                        if (newAva == 1)
                        {
                            _bookRepository.EditBookById(ref books, editChoice, bookId, "1");
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else if (newAva == 2)
                        {
                            _bookRepository.EditBookById(ref books, editChoice, bookId,"0");
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else
                        {
                            Console.WriteLine("Choose only 1 or 2 \n status not changed");
                        }

                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        void AddPatronScreen(ref List<Patron> patrons, ref List<string> phoneNumbers, int patronId)
        {
            try
            {
                Console.WriteLine("--------------------------------");
                var patronName = UtilsClass.EnterNotEmptyString("Enter patron name: \n");
                var patronEmail = UtilsClass.EnterPatronEmail();
                var patronPhone = UtilsClass.EnterPatronPhoneNumber(phoneNumbers);
                patronId++;
                List<Book> borroweds = new List<Book>();
                Patron newPatron = new Patron()
                    { Name = patronName, Email = patronEmail, Id = patronId, PhoneNumber = patronPhone };
                _patronRepository.AddPatron(ref newPatron, ref patrons);
            }
            catch
            {
            }
        }

        void DeletePatronScreen(ref List<Patron> patrons)
        {
            try
            {
                if (patrons.Count == 0)
                {
                    Console.WriteLine("No patrons found!");
                    return;
                }

                int deleteChoice = 0;
                Console.WriteLine("Delete by:");
                Console.WriteLine("1. Search for patron");
                Console.WriteLine("2. By patron id");
                deleteChoice = UtilsClass.EnterNotEmptyInt("Enter your choice");
                int deleteId = 0;
                switch (deleteChoice)
                {
                    case 1:
                        deleteId = _patronServices.SearchForAPatron(ref patrons);
                        break;

                    case 2:
                        deleteId = _patronServices.ChoosePatronById(patrons);
                        break;

                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        DeletePatronScreen(ref patrons);
                        break;
                }
                _patronRepository.DeletePatron(ref patrons, deleteId);
            }
            catch
            {
            }
        }
    }
}


