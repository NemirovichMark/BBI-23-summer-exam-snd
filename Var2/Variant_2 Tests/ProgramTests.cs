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
using Variant_2;

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
        Task1.Point[] points = new Task1.Point[4] {
                new Task1.Point(new double[2] { 0, 0 }),
                new Task1.Point(new double[2] { 1.5, 3.8 }),
                new Task1.Point(new double[2] { -2.3, 4 }),
                new Task1.Point(new double[2] { -4, -0.01 }) };
        Task2.Point[] points2 = new Task2.Point[4] {
                new Task2.Point(new double[2] { 0, 0 }),
                new Task2.Point(new double[2] { 1.5, 0 }),
                new Task2.Point(new double[2] { 1.5, 3 }),
                new Task2.Point(new double[2] { 0, 3 }) };

        [TestMethod()]
        public void Task1CheckDots()
        {
            Task1.Point[] squares = new Task1.Point[6];
            squares[0] = new Task1.Point(new double[0] { });
            squares[1] = new Task1.Point(new double[1] { 1 });
            squares[2] = new Task1.Point(new double[2] { 1, 2 });
            squares[3] = new Task1.Point(new double[3] { 1, 2, 3 });
            squares[4] = new Task1.Point(new double[4] { 1, 2, 3, 4 });
            squares[5] = new Task1.Point(new double[5] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(default(Task1.Point), squares[0]);
            Assert.AreEqual(default(Task1.Point), squares[1]);
            Assert.AreEqual(default(Task1.Point), squares[3]);
            Assert.AreEqual(default(Task1.Point), squares[4]);
            Assert.AreEqual(default(Task1.Point), squares[5]);
            Assert.AreEqual(new Task1.Point(new double[2] { 1, 2 }), squares[2]);
        }
        [TestMethod()]
        public void Task1CheckOutput()
        {
            Task1.Point[] points = new Task1.Point[10];
            string comparer = string.Empty;
            for (int i = 0; i < points.Length; i++)
            {
                int x = new Random().Next(-10, 10);
                int y = new Random().Next(-10, 10);
                points[i] = new Task1.Point(new double[2] { x, y });
                comparer = $"x = {x}, y = {y}";
                Assert.AreEqual(comparer, points[i].ToString());
            }
        }
        [TestMethod()]
        public void Task1CheckSort()
        {
            Task1.Point[] points = new Task1.Point[size];
            Task1.Point[] comparer = new Task1.Point[size];
            for (int i = 0; i < size; i++)
            {
                comparer[i] = new Task1.Point(new double[2] { i, i });
                points[i] = new Task1.Point(new double[2] { size - 1 - i, size - 1 - i });
            }
            Task1 answer = new Task1(points);
            answer.Sorting();
            Task1.Point zero = new Task1.Point();
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(Math.Round(comparer[i].Length(zero), 3),
                    Math.Round(answer.Points[i].Length(zero), 3));
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
        public void Task1CheckLength()
        {
            double[] comparer = new double[4] { 0, 4.09, 4.61, 4 };
            double[] answer = new double[4];
            Task1.Point zero = new Task1.Point();
            for (int i = 0; i < points.Length; i++)
                answer[i] = points[i].Length(zero);
            for (int i = 0; i < points.Length; i++)
            {
                Assert.AreEqual(Math.Round(comparer[i], 3), Math.Round(answer[i], 3));
            }
        }
        [TestMethod()]
        public void Task2CheckDots()
        {
            Task2.Point[] squares = new Task2.Point[6];
            squares[0] = new Task2.Point(new double[0] { });
            squares[1] = new Task2.Point(new double[1] { 1 });
            squares[2] = new Task2.Point(new double[2] { 1, 2 });
            squares[3] = new Task2.Point(new double[3] { 1, 2, 3 });
            squares[4] = new Task2.Point(new double[4] { 1, 2, 3, 4 });
            squares[5] = new Task2.Point(new double[5] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(default(Task2.Point), squares[0]);
            Assert.AreEqual(default(Task2.Point), squares[1]);
            Assert.AreEqual(default(Task2.Point), squares[3]);
            Assert.AreEqual(default(Task2.Point), squares[4]);
            Assert.AreEqual(default(Task2.Point), squares[5]);
            Assert.AreEqual(new Task2.Point(new double[2] { 1, 2 }), squares[2]);
        }
        [TestMethod()]
        public void Task2CheckFourangles()
        {
            Task2.Square[] squares = new Task2.Square[6];
            squares[0] = new Task2.Square(new Task2.Point[] { });
            squares[1] = new Task2.Square(new Task2.Point[] { new Task2.Point(new double[2] { 1, 2 }) });
            squares[2] = new Task2.Square(new Task2.Point[] { new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }) });
            squares[3] = new Task2.Square(new Task2.Point[] { new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }) });
            squares[4] = new Task2.Square(new Task2.Point[] { new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }) });
            squares[5] = new Task2.Square(new Task2.Point[] { new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }), new Task2.Point(new double[2] { 1, 2 }) });
            Task2.Point[] comparer = new Task2.Point[4];
            for (int i = 0; i < squares.Length; i++)
            {
                for (int j = 0; j < squares[i].Points.Length; j++)
                {
                    if (i == 4)
                        Assert.AreEqual(new Task2.Point(new double[2] { 1, 2 }), squares[i].Points[j]);
                    else
                        Assert.AreEqual(comparer[j], squares[i].Points[j]);
                }
            }
        }
        [TestMethod()]
        public void Task2CheckSquares()
        {
            Task2.Square[] squares = new Task2.Square[10];
            string comparer = string.Empty;
            for (int i = 0; i < squares.Length; i++)
            {
                Task2.Point[] points = new Task2.Point[4];
                for (int j = 0; j < points.Length; j++)
                {
                    int x = new Random().Next(-10, 10);
                    int y = new Random().Next(-10, 10);
                    points[j] = new Task2.Point(new double[2] { x, y });
                }
                squares[i] = new Task2.Square(points);
                for (int j = 0; j < points.Length; j++)
                    Assert.AreEqual(points[j], squares[i].Points[j]);
            }
        }
        [TestMethod()]
        public void Task2CheckRectangles()
        {
            Task2.Rectangle[] squares = new Task2.Rectangle[10];
            string comparer = string.Empty;
            for (int i = 0; i < squares.Length; i++)
            {
                Task2.Point[] points = new Task2.Point[4];
                for (int j = 0; j < points.Length; j++)
                {
                    int x = new Random().Next(-10, 10);
                    int y = new Random().Next(-10, 10);
                    points[j] = new Task2.Point(new double[2] { x, y });
                }
                squares[i] = new Task2.Rectangle(points);
                for (int j = 0; j < points.Length; j++)
                    Assert.AreEqual(points[j], squares[i].Points[j]);
            }
        }
        [TestMethod()]
        public void Task2CheckOutput()
        {
            Task2.Fourangle[] figures = new Task2.Fourangle[2];
            string comparerS = string.Empty;
            string comparerR = string.Empty;
            figures[0] = new Task2.Square(points2);
            figures[1] = new Task2.Rectangle(points2);
            comparerS = $"Square with P = {6}, S = {2.25}";
            comparerR = $"Rectangle with P = {9}, S = {4.5}";
            Assert.AreEqual(comparerS, figures[0].ToString());
            Assert.AreEqual(comparerR, figures[1].ToString());
        }
        [TestMethod()]
        public void Task2CheckSort()
        {
            Task2.Fourangle[] figures = new Task2.Fourangle[size];
            Task2.Fourangle[] comparer = new Task2.Fourangle[size];
            for (int i = 0; i < size; i++)
            {
                var points = new Task2.Point[4] {
                    new Task2.Point(new double[] { i, i }),
                new Task2.Point(new double[] { i, i }),
                new Task2.Point(new double[] { i, i }),
                new Task2.Point(new double[] { i, i })};
                var pointsReversed = new Task2.Point[4] {
                    new Task2.Point(new double[] { size-i-1, size -i-1 }),
                new Task2.Point(new double[] { size-i-1, size-i-1 }),
                new Task2.Point(new double[] { size-i-1, size-i-1 }),
                new Task2.Point(new double[] { size-i-1, size-i-1 })};
                comparer[i] = new Task2.Square(points);
                if (i < size / 2)
                {
                    figures[i] = new Task2.Square(pointsReversed);
                }
                else
                {
                    figures[i] = new Task2.Rectangle(pointsReversed);
                }
            }
            Task2 answer = new Task2(figures);
            answer.Sorting();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(comparer[i].Points[j], answer.Fourangles[i].Points[j]);
                }
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
            Task2.Square square = new Task2.Square(new Task2.Point[4]  {
                    new Task2.Point(new double[] {0,1 }),
                new Task2.Point(new double[] { 0,2 }),
                new Task2.Point(new double[] { 5,2}),
                new Task2.Point(new double[] { 5,1})});
            Task2.Rectangle rectangle = new Task2.Rectangle(new Task2.Point[4]  {
                    new Task2.Point(new double[] {0,1 }),
                new Task2.Point(new double[] { 0,2 }),
                new Task2.Point(new double[] { 5,2}),
                new Task2.Point(new double[] { 5,1})});
            Assert.IsTrue(square is Task2.Fourangle);
            Assert.IsFalse(square is Task2.Rectangle);
            Assert.IsTrue(rectangle is Task2.Fourangle);
            Assert.IsFalse(rectangle is Task2.Square);
        }
        [TestMethod()]
        public void Task3CheckNull()
        {
            Task3.Grep answer = new Task3.Grep(nullText);
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task3CheckEmpty()
        {
            Task3.Grep answer = new Task3.Grep(emptyText);
            Assert.AreEqual(emptyText, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckConstructor()
        {
            Task3.Grep answer = new Task3.Grep(text);
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckOutput()
        {
            Task3.Grep answer = new Task3.Grep(text);
            string[] output = new string[] { "в", "и", "чтобы", "функции" };
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckPrint()
        {
            Task3.Grep answer = new Task3.Grep(text);
            string output = "на реализацию в мира, таких как и т. д. цель ООП в связать данные и функции, с ними таким никакая другая часть не к этим данным,";
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output, answer.ToString());
            }
        }

        [TestMethod()]
        public void Task4CheckInheritance()
        {
            Task4.DataSerializer seerializer = new Task4.DataSerializer();
            Assert.IsTrue(seerializer is Task4.IDataSerializer);
        }
        [TestMethod()]
        public void Task4CheckFolderCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Task4.DataSerializer serializer = new Task4.DataSerializer();
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
            Task4.DataSerializer serializer = new Task4.DataSerializer();
            serializer.CreateFolder(path + @"\NoSuchFolder", "ExamSolution666.json");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Grep1.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Grep2.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Grep3.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Grep4.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\ExamSolution666.json"));
            serializer.CreateFile(path, "Grep2.json");
            serializer.CreateFile(path, new string[] { "Grep3.json", "Grep4.json" });
            files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Grep1.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Grep2.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Grep3.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Grep4.json"));
        }
        [TestMethod()]
        public void Task4CheckSeriralization()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Grep.json";
            if (File.Exists(path)) File.Delete(path);
            Task4.DataSerializer serializer = new Task4.DataSerializer();
            Task3.Grep Greper = new Task3.Grep(text);
            serializer.Write(Greper, path);
            var answer = serializer.Read<Task3.Grep>(path);
            Assert.AreEqual(Greper.Input, answer.Input);
            for (int i = 0; i < Greper.Output.Length; i++)
            {
                Assert.AreEqual(Greper.Output[i], answer.Output[i]);

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