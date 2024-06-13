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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                Book newBook = new Book()
                {
                    Title = bookTitle, Author = bookAuthor, PublihedDate = publihedDate, Genre = bookGenre,
                    BorrowDate = borrowedDate, ToBeRetaurnedDate = dateToBeRet, Avaliable = true, BorrowById = 0,
                    Number = ids, Id = new Guid()
                };
                _bookRepository.AddBook(newBook, ref books);
                Console.WriteLine(books.First().Author);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                        bookID = (int)_bookServices.SearchForABook(ref books);
                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        DeleteBookScreen(ref books);
                        break;
                }

                _bookRepository.DeleteBook(ref books, bookID);
                Console.WriteLine("Book deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        void EditPatronInfoByIdScreen()
        {
            try
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
                Patron newPatron = new();
                switch(editChoice)
                {
                    case 1:
                        var newName = UtilsClass.EnterNotEmptyString("Enter new patron name: \n");
                        newPatron.Name = newName;
                        break;
                    case 2:
                        var newEmail = UtilsClass.EnterPatronEmail();
                        newPatron.Email = newEmail;

                        break;
                    case 3:
                        var newPhone = UtilsClass.EnterPatronPhoneNumber(phoneNumbers);
                        newPatron.PhoneNumber = newPhone;

                        break;
                    default:
                        Console.WriteLine("Please enter one of the following choices only.");
                        break;
                }
                _patronRepository.EditPatronInfoById(ref patrons, patronIdtoEdit, newPatron);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        void EditBookByIdScreen()
        {
            try
            {
                Console.WriteLine("--------------------------------");
                _bookServices.ShowAvaliableBooks(ref books);
                var bookId = UtilsClass.EnterNotEmptyInt("Enter book id to edit");
                Console.WriteLine("1. Book title");
                Console.WriteLine("2. Book author");
                Console.WriteLine("3. Published Date");
                Console.WriteLine("4. Book genre");
                Console.WriteLine("5. Book avaliability");
                Console.WriteLine("What do you want to edit:");
                var editChoice = UtilsClass.EnterNotEmptyInt("");
                var boo = books.FirstOrDefault(x => x.Number == bookId);
                Book newBook = new();
                
                switch (editChoice)
                {
                    case 1:
                        var newTitle = UtilsClass.EnterNotEmptyString("Enter new title:");
                        newBook.Title = newTitle;
                        break;
                    case 2:
                        var newAuthor = UtilsClass.EnterNotEmptyString("Enter new author:");
                        newBook.Author = newAuthor;
                        break;
                    case 3:
                        var newPd = UtilsClass.EnterNotEmptyString("Enter new Published date vy dd/mm/yyyy:");
                        newBook.PublihedDate = newPd;
                        break;
                    case 4:
                        var newGenre = UtilsClass.EnterNotEmptyString("Enter new genre:");
                        newBook.Genre = newGenre;
                        break;
                    case 5:
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Not Avaliable");
                        Console.WriteLine("Enter new avaliability:");
                        var newAva = UtilsClass.EnterNotEmptyInt("");
                        if (newAva == 1)
                        {
                            newBook.Avaliable = true;
                            Console.WriteLine("Status Channged Successufully");
                        }
                        else if (newAva == 2)
                        {
                            newBook.Avaliable = false;
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
                _bookRepository.EditBookById(ref books, bookId, newBook);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}


