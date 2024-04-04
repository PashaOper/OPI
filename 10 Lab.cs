using System;

namespace LibraryManagementSystem
{
    // Інтерфейс книги
    interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string Genre { get; set; }
        decimal SecurityDeposit { get; set; }
        decimal RentalCost { get; set; }
    }

    // Інтерфейс читача
    interface IReader
    {
        string FullName { get; set; }
        string PhoneNumber { get; set; }
    }

    // Інтерфейс запиту на прокат
    interface IRentalRequest
    {
        IBook Book { get; set; }
        IReader Reader { get; set; }
        DateTime IssueDate { get; set; }
        DateTime DueDate { get; set; }
        decimal RentalCost { get; set; }
    }

    // Інтерфейс бібліотеки
    interface ILibrary
    {
        void AddRentalRequest(IRentalRequest request);
        void CheckBook(IRentalRequest request, int isDamaged, decimal damageAmount);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єктів книг та читачів
            IBook book1 = new Book { Title = "Book 1", Author = "Author 1", Genre = "Genre 1", SecurityDeposit = 5m, RentalCost = 10m };
            IBook book2 = new Book { Title = "Book 2", Author = "Author 2", Genre = "Genre 2", SecurityDeposit = 5m, RentalCost = 15m };

            // Створення бібліотеки
            ILibrary library = new Library();

            // Введення даних читача та книги
            Console.WriteLine("Enter your full name: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the book title: ");
            string bookTitle = Console.ReadLine();

            Console.WriteLine("Enter the rental duration (in days): ");
            int rentalDuration = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the rental cost: ");
            decimal rentalCost = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the expected return date (yyyy-mm-dd): ");
            DateTime expectedReturnDate = DateTime.Parse(Console.ReadLine());

            // Створення об'єкта читача та запиту на прокат
            IReader reader = new Reader { FullName = fullName, PhoneNumber = phoneNumber };
            IRentalRequest request = new RentalRequest { Book = new Book { Title = bookTitle }, Reader = reader, IssueDate = DateTime.Now, DueDate = DateTime.Now.AddDays(rentalDuration), RentalCost = rentalCost };

            // Додавання запиту на прокат до бібліотеки
            library.AddRentalRequest(request);

            // Введення даних про повернення книги
            Console.WriteLine("Enter 1 if the book is damaged, otherwise enter 0: ");
            int isDamaged = int.Parse(Console.ReadLine());

            if (isDamaged == 1)
            {
                Console.WriteLine("Enter the amount of damage: ");
                decimal damageAmount = decimal.Parse(Console.ReadLine());

                // Перевірка книги та розрахунок суми, яку треба вирахувати з застави
                library.CheckBook(request, isDamaged, damageAmount);
            }
            else
            {
                Console.WriteLine("The book is intact. You will get back your security deposit.");
            }

            Console.ReadLine();
        }
    }

    // Клас, який представляє книгу
    class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal SecurityDeposit { get; set; } // заставна вартість
        public decimal RentalCost { get; set; } // вартість прокату
    }

    // Клас, який представляє читача
    class Reader : IReader
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }

    // Клас, який представляє запит на книгу в прокаті
    class RentalRequest : IRentalRequest
    {
        public IBook Book { get; set; }
        public IReader Reader { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal RentalCost { get; set; }
    }

    // Клас, який представляє бібліотеку
    class Library : ILibrary
    {
        // Метод для додавання запиту на прокат до бібліотеки
        public void AddRentalRequest(IRentalRequest request)
        {
            // Тут можна додати логіку для зберігання запитів на прокат у певній структурі даних
            Console.WriteLine("Rental request added successfully.");
        }

        // Метод для перевірки книги при поверненні
        public void CheckBook(IRentalRequest request, int isDamaged, decimal damageAmount)
        {
            if (isDamaged == 1)
            {
                // Обчислення суми, яку потрібно вирахувати з застави через збитки
                decimal amountToDeduct = damageAmount;
                Console.WriteLine($"The book is damaged. The amount of damage is {amountToDeduct}. This amount will be deducted from your security deposit.");
            }
            else
            {
                // Виведення повідомлення, що книга ціла і застава повертається
                Console.WriteLine("The book is intact. You will get back your security deposit.");
            }
        }
    }
}
