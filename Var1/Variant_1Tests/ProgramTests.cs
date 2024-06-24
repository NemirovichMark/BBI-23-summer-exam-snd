using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Variant_1;

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
        readonly string emptyText = string.Empty;
        readonly string nullText = null;
        [TestMethod()]
        public void Task1CheckOutput()
        {
            Task1.Number[] numbers = new Task1.Number[10];
            string comparer = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = new Random().Next(-10, 10);
                numbers[i] = new Task1.Number(number);
                comparer += $"Number = {number}";
                if (i != numbers.Length - 1) comparer += '\n';
            }
            Task1 answer = new Task1(numbers);
            Assert.AreEqual(comparer, answer.ToString());
        }
        [TestMethod()]
        public void Task1CheckSort()
        {
            Task1.Number[] numbers = new Task1.Number[size];
            Task1.Number[] comparer = new Task1.Number[size];
            for (int i = 0; i < size; i++)
            {
                comparer[i] = new Task1.Number(i);
                numbers[i] = new Task1.Number(size - 1 - i);
            }
            Task1 answer = new Task1(numbers);
            answer.Sorting();
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer.Numbers[i].Real), 2);
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
        public void Task1CheckAdd()
        {
            int ans = 6;
            Task1.Number[] numbers = new Task1.Number[] { new Task1.Number(1), new Task1.Number(-2.8), new Task1.Number(0), new Task1.Number(5.5) };
            Task1.Number[] answer = new Task1.Number[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Add(numbers[j]);
            Task1.Number[] comparer = new Task1.Number[]
            {
                new Task1.Number(-1.8),
                new Task1.Number(1),
                new Task1.Number(6.5),
                new Task1.Number(-2.8),
                new Task1.Number(2.7),
                new Task1.Number(5.5)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
            }
        }
        [TestMethod()]
        public void Task1CheckSub()
        {
            int ans = 6;
            Task1.Number[] numbers = new Task1.Number[] { new Task1.Number(1), new Task1.Number(-2.8), new Task1.Number(0), new Task1.Number(5.5) };
            Task1.Number[] answer = new Task1.Number[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Sub(numbers[j]);
            Task1.Number[] comparer = new Task1.Number[]
            {
                new Task1.Number(3.8),
                new Task1.Number(1),
                new Task1.Number(-4.5),
                new Task1.Number(-2.8),
                new Task1.Number(-8.3),
                new Task1.Number(-5.5)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
            }
        }
        [TestMethod()]
        public void Task1CheckMul()
        {
            int ans = 6;
            Task1.Number[] numbers = new Task1.Number[] { new Task1.Number(1), new Task1.Number(-2.8), new Task1.Number(0), new Task1.Number(5.5) };
            Task1.Number[] answer = new Task1.Number[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Mul(numbers[j]);
            Task1.Number[] comparer = new Task1.Number[]
            {
                new Task1.Number(-2.8),
                new Task1.Number(0),
                new Task1.Number(5.5),
                new Task1.Number(0),
                new Task1.Number(-15.4),
                new Task1.Number(0)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
            }
        }
        [TestMethod()]
        public void Task1CheckDiv()
        {
            int ans = 6;
            Task1.Number[] numbers = new Task1.Number[] { new Task1.Number(1), new Task1.Number(-2.8), new Task1.Number(0), new Task1.Number(5.5) };
            Task1.Number[] answer = new Task1.Number[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Div(numbers[j]);
            Task1.Number[] comparer = new Task1.Number[]
            {
                new Task1.Number(-0.36),
                new Task1.Number(0),
                new Task1.Number(0.18),
                new Task1.Number(0),
                new Task1.Number(-0.51),
                new Task1.Number(0)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
            }
        }
        [TestMethod()]
        public void Task2CheckOutput()
        {
            Task2.ComplexNumber[] numbers = new Task2.ComplexNumber[10];
            string comparer = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                int re = new Random().Next(-10, 10);
                int im = new Random().Next(-10, 10);
                numbers[i] = new Task2.ComplexNumber(re, im);
                if (im > 0)
                    comparer += $"Number = {re} + {im}i";
                else
                    comparer += $"Number = {re} - {Math.Abs(im)}i";
                if (i != numbers.Length - 1) comparer += '\n';
            }
            Task2 answer = new Task2(numbers);
            Assert.AreEqual(comparer, answer.ToString());
        }
        [TestMethod()]
        public void Task2CheckSort()
        {
            Task2.ComplexNumber[] numbers = new Task2.ComplexNumber[size];
            Task2.ComplexNumber[] comparer = new Task2.ComplexNumber[size];
            for (int i = 0; i < size; i++)
            {
                comparer[i] = new Task2.ComplexNumber(i, i * i);
                numbers[i] = new Task2.ComplexNumber(size - 1 - i, (size - 1 - i) * (size - 1 - i));
            }
            Task2 answer = new Task2(numbers);
            answer.Sorting();
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer.Numbers[i].Real), 2);
                Assert.AreEqual(comparer[i].Imagine, Math.Round(answer.Numbers[i].Imagine), 2);
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
        public void Task2CheckAdd()
        {
            int ans = 6;
            Task2.ComplexNumber[] numbers = new Task2.ComplexNumber[] { new Task2.ComplexNumber(1, -5), new Task2.ComplexNumber(-2.8, 3), new Task2.ComplexNumber(0, 0), new Task2.ComplexNumber(5.5, 0) };
            Task2.ComplexNumber[] answer = new Task2.ComplexNumber[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Add(numbers[j]);
            Task2.ComplexNumber[] comparer = new Task2.ComplexNumber[]
            {
                new Task2.ComplexNumber(-1.8, -2),
                new Task2.ComplexNumber(1, -5),
                new Task2.ComplexNumber(6.5, -5),
                new Task2.ComplexNumber(-2.8, 3),
                new Task2.ComplexNumber(2.7, 3),
                new Task2.ComplexNumber(5.5, 0)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
                Assert.AreEqual(comparer[i].Imagine, Math.Round(answer[i].Imagine), 2);
            }
        }
        [TestMethod()]
        public void Task2CheckSub()
        {
            int ans = 6;
            Task2.ComplexNumber[] numbers = new Task2.ComplexNumber[] { new Task2.ComplexNumber(1, -5), new Task2.ComplexNumber(-2.8, 3), new Task2.ComplexNumber(0, 0), new Task2.ComplexNumber(5.5, 0) };
            Task2.ComplexNumber[] answer = new Task2.ComplexNumber[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Sub(numbers[j]);
            Task2.ComplexNumber[] comparer = new Task2.ComplexNumber[]
            {
                new Task2.ComplexNumber(3.8, -8),
                new Task2.ComplexNumber(1, -5),
                new Task2.ComplexNumber(-4.5, -5),
                new Task2.ComplexNumber(-2.8, 3),
                new Task2.ComplexNumber(-8.3, 3),
                new Task2.ComplexNumber(-5.5, 0)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
                Assert.AreEqual(comparer[i].Imagine, Math.Round(answer[i].Imagine), 2);
            }
        }
        [TestMethod()]
        public void Task2CheckMul()
        {
            int ans = 6;
            Task2.ComplexNumber[] numbers = new Task2.ComplexNumber[] { new Task2.ComplexNumber(1, -5), new Task2.ComplexNumber(-2.8, 3), new Task2.ComplexNumber(0, 0), new Task2.ComplexNumber(5.5, 0) };
            Task2.ComplexNumber[] answer = new Task2.ComplexNumber[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Mul(numbers[j]);
            Task2.ComplexNumber[] comparer = new Task2.ComplexNumber[]
            {
                new Task2.ComplexNumber(12.2, 17),
                new Task2.ComplexNumber(0, 0),
                new Task2.ComplexNumber(5.5, -27.5),
                new Task2.ComplexNumber(0, 0),
                new Task2.ComplexNumber(-15.4, 16.5),
                new Task2.ComplexNumber(0, 0)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
                Assert.AreEqual(comparer[i].Imagine, Math.Round(answer[i].Imagine), 2);
            }
        }
        [TestMethod()]
        public void Task2CheckDiv()
        {
            int ans = 6;
            Task2.ComplexNumber[] numbers = new Task2.ComplexNumber[] { new Task2.ComplexNumber(1, -5), new Task2.ComplexNumber(-2.8, 3), new Task2.ComplexNumber(0, 0), new Task2.ComplexNumber(5.5, 0) };
            Task2.ComplexNumber[] answer = new Task2.ComplexNumber[ans];
            int k = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++, k++)
                    answer[k] = numbers[i].Div(numbers[j]);
            Task2.ComplexNumber[] comparer = new Task2.ComplexNumber[]
            {
                new Task2.ComplexNumber(-1.05, 0.65),
                new Task2.ComplexNumber(0, 0),
                new Task2.ComplexNumber(0.18, -0.91),
                new Task2.ComplexNumber(0, 0),
                new Task2.ComplexNumber(-0.51, 0.55),
                new Task2.ComplexNumber(0, 0)
            };
            for (int i = 0; i < ans; i++)
            {
                Assert.AreEqual(comparer[i].Real, Math.Round(answer[i].Real), 2);
                Assert.AreEqual(comparer[i].Imagine, Math.Round(answer[i].Imagine), 2);
            }
        }
        [TestMethod()]
        public void Task2InheritanceCheck()
        {
            Task2.ComplexNumber number = new Task2.ComplexNumber(1, 0);
            Assert.IsTrue(number is Task2.Number);
        }
        [TestMethod()]
        public void Task3CheckNull()
        {
            Task3.Searcher answer = new Task3.Searcher(nullText);
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task3CheckEmpty()
        {
            Task3.Searcher answer = new Task3.Searcher(emptyText);
            Assert.AreEqual(emptyText, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckConstructor()
        {
            Task3.Searcher answer = new Task3.Searcher(text);
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckOutput()
        {
            Task3.Searcher answer = new Task3.Searcher(text);
            string[] output = new string[] { "в", "и", "чтобы", "функции" };
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output.Length, answer.Output.Length);
                Assert.AreEqual(output[i], answer.Output[i]);
            }
        }
        [TestMethod()]
        public void Task3CheckPrint()
        {
            Task3.Searcher answer = new Task3.Searcher(text);
            string output = "в и чтобы функции";
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output, answer.ToString());
            }
        }

        [TestMethod()]
        public void Task4CheckInheritance()
        {
            Task4.SearcherSerialize seerializer = new Task4.SearcherSerialize();
            Assert.IsTrue(seerializer is Task4.AbstractSerializer);
        }
        [TestMethod()]
        public void Task4CheckFolderCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Task4.SearcherSerialize serializer = new Task4.SearcherSerialize();
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
            Task4.SearcherSerialize serializer = new Task4.SearcherSerialize();
            serializer.CreateFolder(path + @"\NoSuchFolder", "ExamSolution666.json");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\searcher1.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\searcher2.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\searcher3.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\searcher4.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\ExamSolution666.json"));
            serializer.CreateFile(path, "searcher2.json");
            serializer.CreateFile(path, new string[] { "searcher3.json", "searcher4.json" });
            files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\searcher1.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\searcher2.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\searcher3.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\searcher4.json"));
        }
        [TestMethod()]
        public void Task4CheckSeriralization()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\searcher.json";
            if (File.Exists(path)) File.Delete(path);
            Task4.SearcherSerialize serializer = new Task4.SearcherSerialize();
            Task3.Searcher searcher = new Task3.Searcher(text);
            serializer.Write(searcher, path);
            var answer = serializer.Read<Task3.Searcher>(path);
            Assert.AreEqual(searcher.Input, answer.Input);
            for (int i = 0; i < searcher.Output.Length; i++)
            {
                Assert.AreEqual(searcher.Output[i], answer.Output[i]);

            }
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