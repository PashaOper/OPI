using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // Клас, який представляє книгу
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal SecurityDeposit { get; set; } // заставна вартість
        public decimal RentalCost { get; set; } // вартість прокату
    }

    // Клас, який представляє читача
    class Reader
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    // Клас, який представляє запит на книгу в прокаті
    class RentalRequest
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Penalty { get; set; } // штраф
    }

    class Library
    {
        private List<RentalRequest> rentalRequests = new List<RentalRequest>();

        // Додати запит на прокат книги
        public void AddRentalRequest(RentalRequest request)
        {
            rentalRequests.Add(request);
        }

        // Розрахувати вартість прокату з урахуванням терміну прокату та знижок
        public decimal CalculateRentalCost(Book book, DateTime issueDate, DateTime dueDate, bool isDiscounted)
        {
            TimeSpan duration = dueDate - issueDate;
            decimal rentalCost = book.RentalCost;

            // Розрахунок вартості з урахуванням терміну прокату
            if (duration.Days > 7)
            {
                // Штраф за кожен день запізнення
                int daysOverdue = duration.Days - 7;
                rentalCost += daysOverdue * 0.5m; // наприклад, штраф 0.5 долара за кожен день запізнення
            }

            // Знижка для деяких категорій читачів
            if (isDiscounted)
            {
                rentalCost *= 0.9m; // наприклад, 10% знижка для певних категорій читачів
            }

            return rentalCost;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єктів книг, читачів і запитів на прокат

            Book book1 = new Book { Title = "Book 1", Author = "Author 1", Genre = "Genre 1", SecurityDeposit = 5m, RentalCost = 10m };
            Book book2 = new Book { Title = "Book 2", Author = "Author 2", Genre = "Genre 2", SecurityDeposit = 5m, RentalCost = 15m };

            Reader reader1 = new Reader { LastName = "Last Name 1", FirstName = "First Name 1", MiddleName = "Middle Name 1", Address = "Address 1", PhoneNumber = "Phone Number 1" };
            Reader reader2 = new Reader { LastName = "Last Name 2", FirstName = "First Name 2", MiddleName = "Middle Name 2", Address = "Address 2", PhoneNumber = "Phone Number 2" };

            RentalRequest request1 = new RentalRequest { Book = book1, Reader = reader1, IssueDate = DateTime.Now, DueDate = DateTime.Now.AddDays(10), Penalty = 0 };
            RentalRequest request2 = new RentalRequest { Book = book2, Reader = reader2, IssueDate = DateTime.Now, DueDate = DateTime.Now.AddDays(5), Penalty = 0 };

            // Взаємодія з бібліотекою

            Library library = new Library();
            library.AddRentalRequest(request1);
            library.AddRentalRequest(request2);

            // Приклад розрахунку вартості прокату

            decimal rentalCost1 = library.CalculateRentalCost(book1, request1.IssueDate, request1.DueDate, isDiscounted: false);
            decimal rentalCost2 = library.CalculateRentalCost(book2, request2.IssueDate, request2.DueDate, isDiscounted: true);

            Console.WriteLine($"Rental cost for Book 1: {rentalCost1}");
            Console.WriteLine($"Rental cost for Book 2: {rentalCost2}");

            Console.ReadLine();
        }
    }
}
