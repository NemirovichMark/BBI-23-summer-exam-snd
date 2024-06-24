using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_6
{
    public class Task1
    {
        public struct Book
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

            public override string ToString()
            {
                return $"Title = {Title}, ISBN = {ISBN}, author = {Author}, year = {Year}";
            }
        }

        private Book[] books; // Массив книг

        public Task1(Book[] books)
        {
            this.books = books;
        }

        public Book[] Books => books; // Свойство для чтения массива книг

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var book in books)
            {
                result += book.ToString() + Environment.NewLine; // Формирование строки для каждого элемента массива
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
            // Реализация пузырьковой сортировки
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = 0; j < books.Length - i - 1; j++)
                {
                    if (books[j].Year > books[j + 1].Year)
                    {
                        
                        Book temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            
            var bookArray = new Task1.Book[]
            {
            new Task1.Book("Book A", "Author 1", 2001),
            new Task1.Book("Book B", "Author 2", 1999),
            new Task1.Book("Book C", "Author 1", 2010),
            new Task1.Book("Book D", "Author 3", 2005)
            };

            
            var task = new Task1(bookArray);

            
            Console.WriteLine(task.ToString());

            
            task.Sorting();

            
            Console.WriteLine("Sorted books:");
            Console.WriteLine(task.ToString());

            
            var booksByAuthor1 = Task1.Select(new List<Task1.Book>(bookArray), b => b.Author == "Author 1");
            Console.WriteLine("Books by Author 1:");
            foreach (var book in booksByAuthor1)
            {
                Console.WriteLine(book.ToString());
            }

            
            var booksFrom2001 = Task1.Select(new List<Task1.Book>(bookArray), b => b.Year == 2001);
            Console.WriteLine("Books from 2001:");
            foreach (var book in booksFrom2001)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}