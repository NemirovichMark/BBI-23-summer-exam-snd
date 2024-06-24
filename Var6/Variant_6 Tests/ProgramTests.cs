using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Variant_6;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        const int size = 10000;
        readonly string text = "Объектно-ориентированное программирование направлено на реализацию в программировании сущностей реального мира, " +
                "таких как наследование, сокрытие, полиморфизм и т. д. " +
                "Основная цель ООП состоит в том, чтобы связать воедино данные и функции, которые с ними работают, " +
                "таким образом, чтобы никакая другая часть кода не могла получить доступ к этим данным, кроме этой функции.";
        readonly string reversed = "онткеъбО-еоннаворитнеиро еинавориммаргорп онелварпан ан юицазилаер в иинавориммаргорп йетсонщус огоньлаер арим, " +
            "хикат как еинаводелсан, еитыркос, мзифромилоп и т. д. яанвонсО ьлец ПОО тиотсос в мот, ыботч ьтазявс онидеов еыннад и иицкнуф, " +
            "еыроток с имин тюатобар, микат мозарбо, ыботч яакакин яагурд ьтсач адок ен алгом ьтичулоп путсод к митэ мыннад, еморк йотэ иицкнуф.";
        readonly string emptyText = string.Empty;
        readonly string nullText = null;
        Task1.Book[] _books = new Task1.Book[]
        {
            new Task1.Book("Working Effectively with Legacy Code", "Michael Feathers", 2004),
            new Task1.Book("The Clean Coder", "Robert C. Martin", 2011),
            new Task1.Book("Pragmatic Programmer", "David Thomas", 2019),
            new Task1.Book("Soft Skills:The software developer's life manual", "John Sonmez", 2015),
        };
        Task2.Book[] _books2 = new Task2.Book[]
        {
            new Task2.PaperBook("Working Effectively with Legacy Code", "Michael Feathers", 2004, true),
            new Task2.PaperBook("The Clean Coder", "Robert C. Martin", 2011, false),
            new Task2.ElectronicBook("Pragmatic Programmer", "David Thomas", 2019, "pdf"),
            new Task2.ElectronicBook("Soft Skills:The software developer's life manual", "John Sonmez", 2015, "fb2"),
            new Task2.ElectronicBook("Design patterns : elements of reusable object-oriented software", "Erich Gamma", 1995, "epub"),
            new Task2.AudioBook("Refactoring: Improving the Design of Existing Code", "Martin Fowler", 2019, true),
            new Task2.AudioBook("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002, false)
        };

        [TestMethod()]
        public void Task1CheckBooks()
        {
            Assert.AreEqual("Working Effectively with Legacy Code", _books[0].Title);
            Assert.AreEqual("Michael Feathers", _books[0].Author);
            Assert.AreEqual(0, _books[0].ISBN);
            Assert.AreEqual(2004, _books[0].Year);
            Assert.AreEqual("Soft Skills:The software developer's life manual", _books[3].Title);
            Assert.AreEqual("John Sonmez", _books[3].Author);
            Assert.AreEqual(3, _books[3].ISBN);
            Assert.AreEqual(2015, _books[3].Year);
        }
        [TestMethod()]
        public void Task1CheckSelectAuthor()
        {
            var MartinsBooks = Task1.Book.Select(_books, "Robert C. Martin");
            Assert.AreEqual(1, MartinsBooks.Length);
            Assert.AreEqual("The Clean Coder", MartinsBooks[0].Title);
            Assert.AreEqual("Robert C. Martin", MartinsBooks[0].Author);
            Assert.AreEqual(1, MartinsBooks[0].ISBN);
            Assert.AreEqual(2011, MartinsBooks[0].Year);
        }
        [TestMethod()]
        public void Task1CheckSelectYear()
        {
            var MartinsBooks = Task1.Book.Select(_books, 2019);
            Assert.AreEqual(1, MartinsBooks.Length);
            Assert.AreEqual("Pragmatic Programmer", MartinsBooks[0].Title);
            Assert.AreEqual("David Thomas", MartinsBooks[0].Author);
            Assert.AreEqual(2, MartinsBooks[0].ISBN);
            Assert.AreEqual(2019, MartinsBooks[0].Year);
        }
        [TestMethod()]
        public void Task1CheckOutput()
        {
            Task1.Book[] books = new Task1.Book[10];
            string comparer = string.Empty;
            for (int i = 0; i < books.Length; i++)
            {
                char title = (char)((int)'a' + new Random().Next(0, 26));
                char author = (char)((int)'a' + new Random().Next(0, 26));
                int year = new Random().Next(1990, 2025);
                books[i] = new Task1.Book(title.ToString(), author.ToString(), year);
                comparer = $"Title = {title}, ISBN = {i + _books.Length}, author = {author}, year = {year}";
                Assert.AreEqual(comparer, books[i].ToString());
            }
        }
        [TestMethod()]
        public void Task1CheckSort()
        {
            Task1.Book[] vectors = new Task1.Book[size];
            Task1.Book[] comparer = new Task1.Book[size];
            for (int i = 0; i < size; i++)
            {
                comparer[i] = new Task1.Book("Book", "book", i);
                vectors[i] = new Task1.Book("Book", "book", size - 1 - i);
            }
            Task1 answer = new Task1(vectors);
            answer.Sorting();
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(comparer[i].Year, answer.Books[i].Year);
            }
        }
        [TestMethod()]
        public void Task1SpeedBubbleSimulator()
        {
            long lag = (long)size * (long)size;
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task1SpeedQSSimulator()
        {
            long lag = (long)size * (long)Math.Sqrt(size);
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task2CheckBooks()
        {
            Assert.AreEqual("Working Effectively with Legacy Code", _books2[0].Title);
            Assert.AreEqual("Michael Feathers", _books2[0].Author);
            Assert.AreEqual(0, _books2[0].ISBN);
            Assert.AreEqual(2004, _books2[0].Year);
            Assert.AreEqual(true, (_books2[0] as Task2.PaperBook).IsHardCover);
            Assert.AreEqual("Soft Skills:The software developer's life manual", _books2[3].Title);
            Assert.AreEqual("John Sonmez", _books2[3].Author);
            Assert.AreEqual(3, _books2[3].ISBN);
            Assert.AreEqual(2015, _books2[3].Year);
            Assert.AreEqual("fb2", (_books2[3] as Task2.ElectronicBook).Format);
            Assert.AreEqual("Patterns of Enterprise Application Architecture", _books2[6].Title);
            Assert.AreEqual("Martin Fowler", _books2[6].Author);
            Assert.AreEqual(6, _books2[6].ISBN);
            Assert.AreEqual(2002, _books2[6].Year);
            Assert.AreEqual(false, (_books2[6] as Task2.AudioBook).IsStudioRecord);
        }
        [TestMethod()]
        public void Task2CheckSelectAuthor()
        {
            var MartinsBooks = Task2.Book.Select(_books2, "Martin Fowler");
            Assert.AreEqual(2, MartinsBooks.Length);
            Assert.AreEqual("Refactoring: Improving the Design of Existing Code", MartinsBooks[0].Title);
            Assert.AreEqual(5, MartinsBooks[0].ISBN);
            Assert.AreEqual("Patterns of Enterprise Application Architecture", MartinsBooks[1].Title);
            Assert.AreEqual(6, MartinsBooks[1].ISBN);
        }
        [TestMethod()]
        public void Task2CheckSelectYear()
        {
            var MartinsBooks = Task2.Book.Select(_books2, 2019);
            Assert.AreEqual(2, MartinsBooks.Length);
            Assert.AreEqual("Pragmatic Programmer", MartinsBooks[0].Title);
            Assert.AreEqual(2, MartinsBooks[0].ISBN);
            Assert.AreEqual("Refactoring: Improving the Design of Existing Code", MartinsBooks[1].Title);
            Assert.AreEqual(5, MartinsBooks[1].ISBN);
        }
        [TestMethod()]
        public void Task2CheckOutput()
        {
            string[] comparer = new string[7];
            comparer[0] = $"Type = PaperBook, isbn = 0, spec = True";
            comparer[1] = $"Type = PaperBook, isbn = 1, spec = False";
            comparer[2] = $"Type = ElectronicBook, isbn = 2, spec = pdf";
            comparer[3] = $"Type = ElectronicBook, isbn = 3, spec = fb2";
            comparer[4] = $"Type = ElectronicBook, isbn = 4, spec = epub";
            comparer[5] = $"Type = AudioBook, isbn = 5, spec = True";
            comparer[6] = $"Type = AudioBook, isbn = 6, spec = False";
            for (int i = 0; i < comparer.Length; i++)
            {
                Assert.AreEqual(comparer[i], _books2[i].ToString());
            }
        }
        [TestMethod()]
        public void Task2CheckSort()
        {
            Task2.Book[] figures = new Task2.Book[size];
            string[] formats = new string[3] { "pdf", "fb2", "epub" };
            for (int i = 0; i < size; i++)
            {
                int reversed = size - 1 - i;
                if (i < size / 3)
                {
                    figures[i] = new Task2.PaperBook("Book", "book", reversed, i % 2 == 0);
                }
                else if (i >= size / 3 && i < 2 * size / 3)
                {
                    figures[i] = new Task2.ElectronicBook("Book", "book", reversed, formats[i % 3]);
                }
                else
                {
                    figures[i] = new Task2.AudioBook("Book", "book", reversed, i % 2 == 0);
                }
            }
            Task2 answer = new Task2(figures);
            answer.Sorting();
            for (int i = 0; i < size - 1; i++)
            {
                Assert.IsTrue(answer.Books[i].Cost() <= answer.Books[i + 1].Cost());
            }
        }
        [TestMethod()]
        public void Task2SpeedBubbleSimulator()
        {
            long lag = (long)size * (long)size;
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task2SpeedQSSimulator()
        {
            long lag = (long)size * (long)Math.Sqrt(size);
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task2InheritanceCheck()
        {
            Assert.IsTrue(_books2[0] is Task2.Book);
            Assert.IsTrue(_books2[0] is Task2.PaperBook);
            Assert.IsFalse(_books2[0] is Task2.ElectronicBook);
            Assert.IsFalse(_books2[0] is Task2.AudioBook);
            Assert.IsTrue(_books2[3] is Task2.Book);
            Assert.IsFalse(_books2[3] is Task2.PaperBook);
            Assert.IsTrue(_books2[3] is Task2.ElectronicBook);
            Assert.IsFalse(_books2[3] is Task2.AudioBook);
            Assert.IsTrue(_books2[5] is Task2.Book);
            Assert.IsFalse(_books2[5] is Task2.PaperBook);
            Assert.IsFalse(_books2[5] is Task2.ElectronicBook);
            Assert.IsTrue(_books2[5] is Task2.AudioBook);
        }
        [TestMethod()]
        public void Task3CheckNull()
        {
            Task3.Reverter answer = new Task3.Reverter(nullText);
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task3CheckEmpty()
        {
            Task3.Reverter answer = new Task3.Reverter(emptyText);
            Assert.AreEqual(emptyText, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckConstructor()
        {
            Task3.Reverter answer = new Task3.Reverter(text);
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckOutput()
        {
            Task3.Reverter answer = new Task3.Reverter(text);
            Assert.AreEqual(reversed, answer.Output);
        }
        [TestMethod()]
        public void Task3CheckPrint()
        {
            Task3.Reverter answer = new Task3.Reverter(text);
            Assert.AreEqual(reversed, answer.ToString());
        }

        [TestMethod()]
        public void Task4CheckInheritance()
        {
            Task4.StatisticSerializer seerializer = new Task4.StatisticSerializer();
            Assert.IsTrue(seerializer is Task4.CommonSerializer);
            Assert.IsTrue(seerializer is Task4.ISerializer);
        }
        [TestMethod()]
        public void Task4CheckFolderCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Task4.StatisticSerializer serializer = new Task4.StatisticSerializer();
            var catalogs = Directory.GetDirectories(path);
            ClearFolders(catalogs);
            serializer.CreateFolder(path + @"\NoSuchFolder", "ExamSolution666");
            catalogs = Directory.GetDirectories(path);
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution1"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution2"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution3"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution4"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\NoSuchFolder"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution666"));
            serializer.CreateFolder(path, "ExamSolution2");
            serializer.CreateFolder(path, new string[] { "ExamSolution2", "ExamSolution3", "ExamSolution4" });
            catalogs = Directory.GetDirectories(path);
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution1"));
            Assert.IsTrue(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution2"));
            Assert.IsTrue(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution3"));
            Assert.IsTrue(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution4"));
        }
        [TestMethod()]
        public void Task4CheckFileCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var catalogs = Directory.GetDirectories(path);
            ClearFolders(catalogs);
            path = Path.Combine(path + @"\ExamSolution5");
            Task4.StatisticSerializer serializer = new Task4.StatisticSerializer();
            serializer.CreateFolder(path + @"\NoSuchFolder", "ExamSolution666.json");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher1.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher2.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher3.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher4.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\ExamSolution666.json"));
            serializer.CreateFile(path, "Searcher2.json");
            serializer.CreateFile(path, new string[] { "Searcher3.json", "Searcher4.json" });
            files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher1.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Searcher2.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Searcher3.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Searcher4.json"));
        }
        [TestMethod()]
        public void Task4CheckSeriralization()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Searcher.json";
            if (File.Exists(path)) File.Delete(path);
            Task4.StatisticSerializer serializer = new Task4.StatisticSerializer();
            Task3.Reverter Searcherer = new Task3.Reverter(text);
            serializer.Serialize(Searcherer, path);
            var answer = serializer.Deserialize<Task3.Reverter>(path);
            Assert.AreEqual(Searcherer.Input, answer.Input);
            Assert.AreEqual(Searcherer.Output, answer.Output);
        }
        private void ClearFolders(string[] folders)
        {
            foreach (var c in folders)
            {
                if (Directory.Exists(c) && c.Contains("ExamSolution"))
                {
                    var files = Directory.GetFiles(c);
                    foreach (var file in files)
                        File.Delete(file);
                    Directory.Delete(c);
                }
            }
        }
        [TestMethod()]
        public void CodeStyleTest()
        {
            string desc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] filenames = new string[]
                {
                "Task1.cs",
                "Task2.cs",
                "Task3.cs",
                "Task4.cs"
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filenames.Length; i++)
            {
                string path = Path.Combine(desc, filenames[i]);
                string output = "";
                if (output == "") FileExistTest(path, ref output);
                if (output == "") FileFullTest(path, ref output);
                if (output == "") FileForbiddenFunctions(path, ref output);
                sb.Append(output);
            }
            Assert.AreEqual("", sb.ToString());
        }
        private void FileExistTest(string path, ref string output)
        {
            bool isExists = System.IO.File.Exists(path);
            output += isExists ? "" : $"Файл по пути {path} не найден\n";
        }
        private void FileFullTest(string path, ref string output)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            output += !string.IsNullOrEmpty(text) && text.Length > 1 ? "" : $"Файл {path} пуст\n";
        }
        private void FileForbiddenFunctions(string path, ref string output)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            output += text.Contains("Dictionary") ? $"Файл {path} содержит класс Dictionary\n" : "";
            output += text.Contains("HashSet") ? $"Файл {path} содержит класс HashSet\n" : "";
            output += text.Contains("Regex") ? $"Файл {path} содержит класс Regex\n" : "";
            output += text.Contains(".Sort(") || text.Contains(".Reverse(") || text.Contains(".Copy(") ? $"Файл {path} содержит упорядочивающие функции класса Array\n" : "";
            var isForbidden = text.Contains(".Order(") || text.Contains(".Select(") || text.Contains(".Take(") || text.Contains(".Count(") || text.Contains(".Where(") || text.Contains(".Top(");
            output += isForbidden ? $"Файл {path} содержит Linq-запросы\n" : "";
        }
    }
}