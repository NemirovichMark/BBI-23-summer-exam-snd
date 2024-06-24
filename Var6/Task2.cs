using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Variant_6
{
    public class Task2
    {
        public abstract class Book
        {
            private static int isbnCounter = 0;

            public string Title { get; }
            public int ISBN { get; }
            public string Author { get; }
            public int Year { get; }

            public Book(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
                ISBN = isbnCounter++;
            }

            public virtual double Cost()
            {
                return 500 + (DateTime.Now.Year - Year);
            }

            public override string ToString()
            {
                return $"Type = {GetType().Name}, isbn = {ISBN}, spec = ";
            }
        }

        public class PaperBook : Book
        {
            public bool IsHardCover { get; }

            public PaperBook(string title, string author, int year, bool isHardCover)
                : base(title, author, year)
            {
                IsHardCover = isHardCover;
            }

            public override double Cost()
            {
                double baseCost = base.Cost();
                if (IsHardCover)
                {
                    baseCost += 150;
                }
                return baseCost;
            }

            public override string ToString()
            {
                return base.ToString() + (IsHardCover ? "твердый переплет" : "мягкий переплет");
            }
        }

        public class ElectronicBook : Book
        {
            public string Format { get; }

            public ElectronicBook(string title, string author, int year, string format)
                : base(title, author, year)
            {
                Format = format;
            }

            public override double Cost()
            {
                double baseCost = base.Cost();
                double multiplier = Format switch
                {
                    "pdf" => 0.6,
                    "fb2" => 0.8,
                    "epub" => 0.95,
                    _ => 1.0
                };
                return baseCost * multiplier;
            }

            public override string ToString()
            {
                return base.ToString() + Format;
            }
        }

        public class AudioBook : Book
        {
            public bool IsStudioRecord { get; }

            public AudioBook(string title, string author, int year, bool isStudioRecord)
                : base(title, author, year)
            {
                IsStudioRecord = isStudioRecord;
            }

            public override double Cost()
            {
                double baseCost = base.Cost();
                double multiplier = IsStudioRecord ? 0.8 : 0.6;
                return baseCost * multiplier;
            }

            public override string ToString()
            {
                return base.ToString() + (IsStudioRecord ? "студийная запись" : "не студийная запись");
            }
        }

        private Book[] books;

        public Task2(Book[] books)
        {
            this.books = books;
        }

        public Book[] Books => books;

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var book in books)
            {
                result += book.ToString() + Environment.NewLine;
            }
            return result;
        }

        public static List<Book> Select(List<Book> books, Func<Book, bool> condition)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (condition(book))
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public void Sorting()
        {
            // Реализация пузырьковой сортировки по стоимости книги
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = 0; j < books.Length - i - 1; j++)
                {
                    if (books[j].Cost() > books[j + 1].Cost())
                    {
                        // Обмен книгами
                        Book temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        var bookArray = new Task2.Book[]
    //    {
    //        new Task2.PaperBook("Book A", "Author 1", 2001, true),
    //        new Task2.ElectronicBook("Book B", "Author 2", 1999, "pdf"),
    //        new Task2.AudioBook("Book C", "Author 1", 2010, true),
    //        new Task2.PaperBook("Book D", "Author 3", 2005, false)
    //    };

    //        // Создание объекта Task2
    //        var task = new Task2(bookArray);

    //        // Вывод всех книг
    //        Console.WriteLine(task.ToString());

    //        // Сортировка книг по стоимости
    //        task.Sorting();

    //        // Вывод отсортированных книг
    //        Console.WriteLine("Sorted books by cost:");
    //        Console.WriteLine(task.ToString());

    //        // Поиск книг по автору
    //        var booksByAuthor1 = Task2.Select(new List<Task2.Book>(bookArray), b => b.Author == "Author 1");
    //        Console.WriteLine("Books by Author 1:");
    //        foreach (var book in booksByAuthor1)
    //        {
    //            Console.WriteLine(book.ToString());
    //        }

    //        // Поиск книг по году
    //        var booksFrom2001 = Task2.Select(new List<Task2.Book>(bookArray), b => b.Year == 2001);
    //        Console.WriteLine("Books from 2001:");
    //        foreach (var book in booksFrom2001)
    //        {
    //            Console.WriteLine(book.ToString());
    //        }
    //    }
    //}
}

