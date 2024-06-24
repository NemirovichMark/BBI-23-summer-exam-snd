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
using Variant_3;
using static Variant_3.Task2;

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
        Task1.Dot[] _dots = new Task1.Dot[10]
        {
            new Task1.Dot(new double[3] { 0, 0, 0 }),
            new Task1.Dot(new double[3] { 1, 1, 1 }),
            new Task1.Dot(new double[3] { 1, 0, 0 }),
            new Task1.Dot(new double[3] { 0, 1, 0 }),
            new Task1.Dot(new double[3] { 0, 0, 1 }),
            new Task1.Dot(new double[3] { 1, 1, 0 }),
            new Task1.Dot(new double[3] { 0, 1, 1 }),
            new Task1.Dot(new double[3] { 1, 0, 1 }),
            new Task1.Dot(new double[3] { 2, 1, 0 }),
            new Task1.Dot(new double[3] { 1, 2, 3 })
        };
        Task2.Dot[] _dots2 = new Task2.Dot[10]
        {
            new Task2.Dot(new double[3] { 0, 0, 0 }),
            new Task2.Dot(new double[3] { 1, 1, 1 }),
            new Task2.Dot(new double[3] { 1, 0, 0 }),
            new Task2.Dot(new double[3] { 0, 1, 0 }),
            new Task2.Dot(new double[3] { 0, 0, 1 }),
            new Task2.Dot(new double[3] { 1, 1, 0 }),
            new Task2.Dot(new double[3] { 0, 1, 1 }),
            new Task2.Dot(new double[3] { 1, 0, 1 }),
            new Task2.Dot(new double[3] { 2, 1, 0 }),
            new Task2.Dot(new double[3] { 1, 2, 3 })
        };
        double[] _lengthes = new double[10] { 0, Math.Round(Math.Sqrt(3),2),
            1, 1, 1, Math.Round(Math.Sqrt(2),2), Math.Round(Math.Sqrt(2),2),
            Math.Round(Math.Sqrt(2),2), Math.Round(Math.Sqrt(5),2), 
            Math.Round(Math.Sqrt(14), 2) };

        [TestMethod()]
        public void Task1CheckDots()
        {
            Task1.Dot[] Dots = new Task1.Dot[6];
            Dots[0] = new Task1.Dot(new double[0] { });
            Dots[1] = new Task1.Dot(new double[1] { 1 });
            Dots[2] = new Task1.Dot(new double[2] { 1, 2 });
            Dots[3] = new Task1.Dot(new double[3] { 1, 2, 3 });
            Dots[4] = new Task1.Dot(new double[4] { 1, 2, 3, 4 });
            Dots[5] = new Task1.Dot(new double[5] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(default(Task1.Dot), Dots[0]);
            Assert.AreEqual(default(Task1.Dot), Dots[1]);
            Assert.AreEqual(default(Task1.Dot), Dots[2]);
            Assert.AreEqual(default(Task1.Dot), Dots[4]);
            Assert.AreEqual(default(Task1.Dot), Dots[5]);
            Assert.AreEqual(new Task1.Dot(new double[3] { 1, 2, 3 }), Dots[3]);
        }
        [TestMethod()]
        public void Task1CheckVectors()
        {
            Task1.Vector[] vectors = new Task1.Vector[5];
            vectors[0] = new Task1.Vector(_dots[0], _dots[0]);
            vectors[1] = new Task1.Vector(_dots[0], _dots[1]);
            vectors[2] = new Task1.Vector(default(Task1.Dot), _dots[1]);
            vectors[3] = new Task1.Vector(_dots[1], default(Task1.Dot));
            vectors[4] = new Task1.Vector(default(Task1.Dot), default(Task1.Dot));
            Assert.AreEqual(default(Task1.Vector), vectors[0]);
            Assert.AreNotEqual(default(Task1.Vector), vectors[1]);
            Assert.AreNotEqual(default(Task1.Vector), vectors[2]);
            Assert.AreNotEqual(default(Task1.Vector), vectors[3]);
            Assert.AreEqual(default(Task1.Vector), vectors[4]);
        }
        [TestMethod()]
        public void Task1CheckDotsOutput()
        {
            Task1.Dot[] dots = new Task1.Dot[10];
            string comparer = string.Empty;
            for (int i = 0; i < dots.Length; i++)
            {
                int x = new Random().Next(-10, 10);
                int y = new Random().Next(-10, 10);
                int z = new Random().Next(-10, 10);
                dots[i] = new Task1.Dot(new double[3] { x, y, z });
                comparer = $"x = {x}, y = {y}, z = {z}";
                Assert.AreEqual(comparer, dots[i].ToString());
            }
        }
        [TestMethod()]
        public void Task1CheckLength()
        {
            var zero = new Task1.Dot();
            for (int i = 0; i < _dots.Length; i++)
            {
                Task1.Vector vector = new Task1.Vector(_dots[i], zero);
                Assert.AreEqual(Math.Round(_lengthes[i],2), vector.Length());
            }
        }
        [TestMethod()]
        public void Task1CheckVectorsOutput()
        {
            string comparer = string.Empty;
            var zero = new Task1.Dot();
            for (int i = 0; i < _dots.Length; i++)
            {
                Task1.Vector vector = new Task1.Vector(_dots[i], zero);
                comparer = $"x = {_dots[i].X}, y = {_dots[i].Y}, z = {_dots[i].Z}\n" +
                    $"x = {zero.X}, y = {zero.Y}, z = {zero.Z}\n" +
                    $"Length = {Math.Round(_lengthes[i], 2)}";
                Assert.AreEqual(comparer, vector.ToString());
            }
        }
        [TestMethod()]
        public void Task1CheckSort()
        {
            Task1.Vector[] vectors = new Task1.Vector[_dots.Length];
            Task1.Vector[] comparer = new Task1.Vector[_dots.Length];
            for (int i = 0; i < _dots.Length; i++)
            {
                comparer[i] = new Task1.Vector(_dots[i], _dots[i]);
                vectors[i] = new Task1.Vector(_dots[_dots.Length - 1 - i], _dots[_dots.Length - 1 - i]);
            }
            Task1 answer = new Task1(vectors);
            answer.Sorting();
            Task1.Vector zero = new Task1.Vector();
            for (int i = 0; i < _dots.Length; i++)
            {
                Assert.AreEqual(Math.Round(comparer[i].Length(), 3),
                    Math.Round(answer.Vectors[i].Length(), 3));
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
        public void Task2CheckDots()
        {
            Task2.Dot[] dots = new Task2.Dot[6];
            dots[0] = new Task2.Dot(new double[0] { });
            dots[1] = new Task2.Dot(new double[1] { 1 });
            dots[2] = new Task2.Dot(new double[2] { 1, 2 });
            dots[3] = new Task2.Dot(new double[3] { 1, 2, 3 });
            dots[4] = new Task2.Dot(new double[4] { 1, 2, 3, 4 });
            dots[5] = new Task2.Dot(new double[5] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(default(Task2.Dot), dots[0]);
            Assert.AreEqual(default(Task2.Dot), dots[1]);
            Assert.AreEqual(default(Task2.Dot), dots[2]);
            Assert.AreEqual(default(Task2.Dot), dots[4]);
            Assert.AreEqual(default(Task2.Dot), dots[5]);
            Assert.AreEqual(new Task2.Dot(new double[3] { 1, 2, 3 }), dots[3]);
        }
        [TestMethod()]
        public void Task2CheckVectors()
        {
            Task2.Vector[] vectors = new Task2.Vector[5];
            vectors[0] = new Task2.Vector(_dots2[0], _dots2[0]);
            vectors[1] = new Task2.Vector(_dots2[0], _dots2[1]);
            vectors[2] = new Task2.Vector(default(Task2.Dot), _dots2[1]);
            vectors[3] = new Task2.Vector(_dots2[1], default(Task2.Dot));
            vectors[4] = new Task2.Vector(default(Task2.Dot), default(Task2.Dot));
            Assert.AreEqual(default(Task2.Vector), vectors[0]);
            Assert.AreNotEqual(default(Task2.Vector), vectors[1]);
            Assert.AreNotEqual(default(Task2.Vector), vectors[2]);
            Assert.AreNotEqual(default(Task2.Vector), vectors[3]);
            Assert.AreEqual(default(Task2.Vector), vectors[4]);
        }
        [TestMethod()]
        public void Task2CheckSphereCenter()
        {
            Task2.Sphere[] spheres = new Task2.Sphere[10];
            string comparer = string.Empty;
            for (int i = 0; i < spheres.Length; i++)
            {
                int x = new Random().Next(-10, 10);
                int y = new Random().Next(-10, 10);
                int z = new Random().Next(-10, 10);
                Task2.Dot center = new Task2.Dot(new double[] { x, y, z });
                Task2.Vector vector = new Task2.Vector();
                spheres[i] = new Task2.Sphere(center);
                Assert.AreEqual(center, spheres[i].Center);
                Assert.AreEqual(vector, spheres[i].Pointer);
            }
        }
        [TestMethod()]
        public void Task2CheckSphereVector()
        {
            Task2.Sphere[] spheres = new Task2.Sphere[10];
            Task2.Dot zero = new Task2.Dot(new double[] { 0, 0, 0 });
            for (int i = 1; i < spheres.Length; i++)
            {
                spheres[i] = new Task2.Sphere(_dots2[i]);
                spheres[i].CreateVector(zero);
                Assert.AreEqual(_dots2[i], spheres[i].Center);
                Assert.AreEqual(_lengthes[i], spheres[i].Pointer.Length());
            }
        }
        [TestMethod()]
        public void Task2CheckCubeCenter()
        {
            Task2.Cube[] spheres = new Task2.Cube[10];
            string comparer = string.Empty;
            for (int i = 0; i < spheres.Length; i++)
            {
                int x = new Random().Next(-10, 10);
                int y = new Random().Next(-10, 10);
                int z = new Random().Next(-10, 10);
                Task2.Dot center = new Task2.Dot(new double[] { x, y, z });
                Task2.Vector vector = new Task2.Vector();
                spheres[i] = new Task2.Cube(center);
                Assert.AreEqual(center, spheres[i].Center);
                Assert.AreEqual(vector, spheres[i].Pointer);
            }
        }
        [TestMethod()]
        public void Task2CheckCubeVector()
        {
            Task2.Cube[] spheres = new Task2.Cube[10];
            Task2.Dot zero = new Task2.Dot(new double[] { 0, 0, 0 });
            string comparer = string.Empty;
            for (int i = 0; i < spheres.Length; i++)
            {
                spheres[i] = new Task2.Cube(_dots2[i]);
                Assert.AreEqual(_dots2[i], spheres[i].Center);
                spheres[i].CreateVector(zero);
                Assert.AreEqual(_lengthes[i], spheres[i].Pointer.Length());
            }
        }
        [TestMethod()]
        public void Task2CheckSphereVolume()
        {
            Task2.Sphere sphere = new Task2.Sphere(_dots2[0]);
            Task2.Sphere sphere2 = new Task2.Sphere(_dots2[0]);
            sphere.CreateVector(_dots2[1]);
            sphere2.CreateVector(_dots2[9]);
            double comparer = Math.Round(Math.PI * 4 / 3 * Math.Pow(1.73, 3),2);
            double comparer2 = Math.Round(Math.PI * 4 / 3 * Math.Pow(3.74, 3),2);
            Assert.AreEqual(comparer, sphere.Volume());
            Assert.AreEqual(comparer2, sphere2.Volume());
        }
        [TestMethod()]
        public void Task2CheckCubeVolume()
        {
            Task2.Cube sphere = new Task2.Cube(_dots2[0]);
            Task2.Cube sphere2 = new Task2.Cube(_dots2[0]);
            sphere.CreateVector(_dots2[1]);
            sphere2.CreateVector(_dots2[9]);
            double comparer = Math.Round(Math.Pow(1, 3), 2);
            double comparer2 = Math.Round(Math.Pow(Math.Sqrt(14) / Math.Sqrt(3), 3), 2);
            Assert.AreEqual(comparer, sphere.Volume());
            Assert.AreEqual(comparer2, sphere2.Volume());
        }
        [TestMethod()]
        public void Task2CheckOutput()
        {
            Task2.Shape[] figures = new Task2.Shape[2];
            string comparerS = string.Empty;
            string comparerR = string.Empty;
            figures[0] = new Task2.Sphere(_dots2[0]);
            figures[1] = new Task2.Cube(_dots2[0]);
            figures[0].CreateVector(_dots2[3]);
            figures[1].CreateVector(_dots2[3]);
            comparerS = $"Sphere with V = {Math.Round(Math.PI * 4 / 3, 2)}";
            comparerR = $"Cube with V = {Math.Round(Math.Pow(1 / Math.Sqrt(3), 3), 2)}";
            Assert.AreEqual(comparerS, figures[0].ToString());
            Assert.AreEqual(comparerR, figures[1].ToString());
        }
        [TestMethod()]
        public void Task2CheckSort()
        {
            Task2.Shape[] figures = new Task2.Shape[size];
            Task2.Shape[] comparer = new Task2.Shape[size];
            var zeroDot = new Task2.Dot();
            for (int i = 0; i < size; i++)
            {
                var curDot = new Task2.Dot(new double[] { i, i, i });
                var reverseDot = new Task2.Dot(new double[] { size-1-i, size - 1 - i, size - 1 - i });
                if (i < size / 2)
                {
                    comparer[i] = new Task2.Sphere(curDot);
                    figures[i] = new Task2.Sphere(reverseDot);
                }
                else
                {
                    comparer[i] = new Task2.Cube(curDot);
                    figures[i] = new Task2.Cube(reverseDot);
                }
            }
            Task2 answer = new Task2(figures);
            answer.Sorting();
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(comparer[i].Volume(), answer.Shapes[i].Volume());
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
            Task2.Sphere sphere = new Task2.Sphere(_dots2[0]);
            Task2.Cube cube = new Task2.Cube(_dots2[0]);
            Assert.IsTrue(sphere is Task2.Shape);
            Assert.IsFalse(sphere is Task2.Cube);
            Assert.IsTrue(cube is Task2.Shape);
            Assert.IsFalse(cube is Task2.Sphere);
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
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckPrint()
        {
            Task3.Searcher answer = new Task3.Searcher(text);
            string output = "как";
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output, answer.ToString());
            }
        }

        [TestMethod()]
        public void Task4CheckInheritance()
        {
            Task4.DataSerializer seerializer = new Task4.DataSerializer();
            Assert.IsTrue(seerializer is Task4.SerializerInFormate);
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
            Task4.DataSerializer serializer = new Task4.DataSerializer();
            Task3.Searcher Searcherer = new Task3.Searcher(text);
            serializer.Write(Searcherer, path);
            var answer = serializer.Read<Task3.Searcher>(path);
            Assert.AreEqual(Searcherer.Input, answer.Input);
            for (int i = 0; i < Searcherer.Output.Length; i++)
            {
                Assert.AreEqual(Searcherer.Output[i], answer.Output[i]);

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