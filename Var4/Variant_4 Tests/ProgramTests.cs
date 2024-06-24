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
using Variant_4;

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
        Task1.Triangle[] _Triangles = new Task1.Triangle[]
        {
            new Task1.Triangle(new int[3] { 0, 0, 0 }),
            new Task1.Triangle(new int[3] { 1, 1, 1 }),
            new Task1.Triangle(new int[3] { 1, 0, 0 }),
            new Task1.Triangle(new int[3] { 1, 1, 2 }),
            new Task1.Triangle(new int[3] { 1, -1, 1 }),
            new Task1.Triangle(new int[3] { 1, 1, 0 }),
            new Task1.Triangle(new int[3] { 3, 2, 1 }),
            new Task1.Triangle(new int[3] { 5, 4, 2 })
        };
        Task2.Triangle[] _Triangles2 = new Task2.Triangle[]
        {
            new Task2.Triangle(new int[3] { 0, 0, 0 }),
            new Task2.Triangle(new int[3] { 1, 1, 1 }),
            new Task2.Triangle(new int[3] { 1, 0, 0 }),
            new Task2.Triangle(new int[3] { 1, 1, 2 }),
            new Task2.Triangle(new int[3] { 1, -1, 1 }),
            new Task2.Triangle(new int[3] { 1, 1, 0 }),
            new Task2.Triangle(new int[3] { 3, 2, 1 }),
            new Task2.Triangle(new int[3] { 5, 4, 2 })
        };
        Task2.Fourangle[] _Fourangles2 = new Task2.Fourangle[]
        {
            new Task2.Fourangle(new int[2] { 0, 0 }),
            new Task2.Fourangle(new int[2] { 1, 0 }),
            new Task2.Fourangle(new int[2] { 1, 1 }),
            new Task2.Fourangle(new int[2] { 1, -2 }),
            new Task2.Fourangle(new int[2] { 1, 3 }),
            new Task2.Fourangle(new int[2] { 4, 4 })
        };
        Task2.Circle[] _Circles2 = new Task2.Circle[]
        {
            new Task2.Circle(new int[2] { 0, 0 }),
            new Task2.Circle(new int[2] { 1, 0 }),
            new Task2.Circle(new int[2] { 1, 1 }),
            new Task2.Circle(new int[2] { 1, -2 }),
            new Task2.Circle(new int[2] { 1, 3 }),
            new Task2.Circle(new int[2] { 4, 4 })
        };
        double[] _areas = new double[] { 0, 0.43, 0, 0, 0, 0, 0, 3.8 };
        double[] _areasC = new double[] { 0, 0, Math.PI, 0, 3 * Math.PI, 16 * Math.PI };
        double[] _areasR = new double[] { 0, 0, 1, 0, 3, 16 };
        string[] _names = new string[] {"равносторонний", "равносторонний", "равнобедренный", "равнобедренный",
        "равнобедренный", "равнобедренный", "разносторонний", "разносторонний", };
        string[] _namesC = new string[] { "круг", "эллипс", "круг", "эллипс", "эллипс", "круг" };
        string[] _namesR = new string[] { "квадрат", "прямоугольник", "квадрат", "прямоугольник", "прямоугольник", "квадрат" };

        [TestMethod()]
        public void Task1CheckTriangles()
        {
            Task1.Triangle[] Triangles = new Task1.Triangle[5];
            Triangles[0] = new Task1.Triangle(new int[0] { });
            Triangles[1] = new Task1.Triangle(new int[1] { 1 });
            Triangles[2] = new Task1.Triangle(new int[2] { 1, 2 });
            Triangles[3] = new Task1.Triangle(new int[3] { 1, 2, 3 });
            Triangles[4] = new Task1.Triangle(new int[4] { 1, 2, 3, 4 });
            for (int i = 0; i < Triangles.Length; i++)
            {
                if (i == 3)
                {
                    Assert.AreEqual(1, Triangles[3].A);
                    Assert.AreEqual(2, Triangles[3].B);
                    Assert.AreEqual(3, Triangles[3].C);
                    continue;
                }
                Assert.AreEqual(0, Triangles[i].A);
                Assert.AreEqual(0, Triangles[i].B);
                Assert.AreEqual(0, Triangles[i].C);
            }
        }
        [TestMethod()]
        public void Task1CheckArea()
        {
            for (int i = 0; i < _Triangles.Length; i++)
            {
                Assert.AreEqual(Math.Round(_areas[i], 2), _Triangles[i].Area());
            }
        }
        [TestMethod()]
        public void Task1CheckDistinct()
        {
            for (int i = 0; i < _Triangles.Length; i++)
            {
                Assert.AreEqual(_names[i], _Triangles[i].Distinct());
            }
        }
        [TestMethod()]
        public void Task1CheckTrianglesOutput()
        {
            Task1.Triangle[] Triangles = new Task1.Triangle[10];
            string comparer = string.Empty;
            for (int i = 0; i < Triangles.Length; i++)
            {
                int x = new Random().Next(-10, 10);
                int y = new Random().Next(-10, 10);
                int z = new Random().Next(-10, 10);
                Triangles[i] = new Task1.Triangle(new int[3] { x, y, z });
                comparer = $"Type = {Triangles[i].GetType().Name}, subtype = {Triangles[i].Distinct()}, a = {Triangles[i].A}, b = {Triangles[i].B}, c = {Triangles[i].C}, with S = {Math.Round(Triangles[i].Area(), 2)}";
                Assert.AreEqual(comparer, Triangles[i].ToString());
            }
        }
        [TestMethod()]
        public void Task1CheckSort()
        {
            Task1.Triangle[] vectors = new Task1.Triangle[size];
            Task1.Triangle[] comparer = new Task1.Triangle[size];
            for (int i = 0; i < size; i++)
            {
                comparer[i] = new Task1.Triangle(new int[] { i, i, i });
                vectors[i] = new Task1.Triangle(new int[] { size - 1 - i, size - 1 - i, size - 1 - i });
            }
            Task1 answer = new Task1(vectors);
            answer.Sorting();
            for (int i = 0; i < _Triangles.Length; i++)
            {
                Assert.AreEqual(Math.Round(comparer[i].Area(), 2),
                    Math.Round(answer.Triangles[i].Area(), 2));
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
        public void Task2CheckCircles()
        {
            Task2.Circle[] Triangles = new Task2.Circle[5];
            Triangles[0] = new Task2.Circle(new int[0] { });
            Triangles[1] = new Task2.Circle(new int[1] { 1 });
            Triangles[2] = new Task2.Circle(new int[2] { 1, 2 });
            Triangles[3] = new Task2.Circle(new int[3] { 1, 2, 3 });
            Triangles[4] = new Task2.Circle(new int[4] { 1, 2, 3, 4 });
            for (int i = 0; i < Triangles.Length; i++)
            {
                if (i == 2)
                {
                    Assert.AreEqual(1, Triangles[i].A);
                    Assert.AreEqual(2, Triangles[i].B);
                    continue;
                }
                Assert.AreEqual(0, Triangles[i].A);
                Assert.AreEqual(0, Triangles[i].B);
            }
        }
        [TestMethod()]
        public void Task2CheckFourangles()
        {
            Task2.Fourangle[] Triangles = new Task2.Fourangle[5];
            Triangles[0] = new Task2.Fourangle(new int[0] { });
            Triangles[1] = new Task2.Fourangle(new int[1] { 1 });
            Triangles[2] = new Task2.Fourangle(new int[2] { 1, 2 });
            Triangles[3] = new Task2.Fourangle(new int[3] { 1, 2, 3 });
            Triangles[4] = new Task2.Fourangle(new int[4] { 1, 2, 3, 4 });
            for (int i = 0; i < Triangles.Length; i++)
            {
                if (i == 2)
                {
                    Assert.AreEqual(1, Triangles[i].A);
                    Assert.AreEqual(2, Triangles[i].B);
                    continue;
                }
                Assert.AreEqual(0, Triangles[i].A);
                Assert.AreEqual(0, Triangles[i].B);
            }
        }
        [TestMethod()]
        public void Task2CheckTriangles()
        {
            Task2.Triangle[] Triangles = new Task2.Triangle[5];
            Triangles[0] = new Task2.Triangle(new int[0] { });
            Triangles[1] = new Task2.Triangle(new int[1] { 1 });
            Triangles[2] = new Task2.Triangle(new int[2] { 1, 2 });
            Triangles[3] = new Task2.Triangle(new int[3] { 1, 2, 3 });
            Triangles[4] = new Task2.Triangle(new int[4] { 1, 2, 3, 4 });
            for (int i = 0; i < Triangles.Length; i++)
            {
                if (i == 3)
                {
                    Assert.AreEqual(1, Triangles[3].A);
                    Assert.AreEqual(2, Triangles[3].B);
                    Assert.AreEqual(3, Triangles[3].C);
                    continue;
                }
                Assert.AreEqual(0, Triangles[i].A);
                Assert.AreEqual(0, Triangles[i].B);
                Assert.AreEqual(0, Triangles[i].C);
            }
        }
        [TestMethod()]
        public void Task2CheckCircleArea()
        {
            for (int i = 0; i < _Circles2.Length; i++)
            {
                Assert.AreEqual(Math.Round(_areasC[i], 2), _Circles2[i].Area());
            }
        }
        [TestMethod()]
        public void Task2CheckCircleDistinct()
        {
            for (int i = 0; i < _Circles2.Length; i++)
            {
                Assert.AreEqual(_namesC[i], _Circles2[i].Distinct());
            }
        }
        [TestMethod()]
        public void Task2CheckFouranglesArea()
        {
            for (int i = 0; i < _Fourangles2.Length; i++)
            {
                Assert.AreEqual(Math.Round(_areasR[i], 2), _Fourangles2[i].Area());
            }
        }
        [TestMethod()]
        public void Task2CheckFourangleDistinct()
        {
            for (int i = 0; i < _Fourangles2.Length; i++)
            {
                Assert.AreEqual(_namesR[i], _Fourangles2[i].Distinct());
            }
        }
        [TestMethod()]
        public void Task2CheckTriangleArea()
        {
            for (int i = 0; i < _Triangles2.Length; i++)
            {
                Assert.AreEqual(Math.Round(_areas[i], 2), _Triangles2[i].Area());
            }
        }
        [TestMethod()]
        public void Task2CheckTriangleDistinct()
        {
            for (int i = 0; i < _Triangles2.Length; i++)
            {
                Assert.AreEqual(_names[i], _Triangles2[i].Distinct());
            }
        }
        [TestMethod()]
        public void Task2CheckOutput()
        {
            string comparerS = string.Empty;
            string comparerR = string.Empty;
            string comparerT = string.Empty;
            comparerS = $"Type = Circle, subtype = {_namesC[5]}, a = {_Circles2[5].A}, b = {_Circles2[5].B}, with S = {Math.Round(_Circles2[5].Area(), 2)}";
            comparerR = $"Type = Fourangle, subtype = {_namesR[5]}, a = {_Fourangles2[5].A}, b = {_Fourangles2[5].B}, with S = {Math.Round(_Fourangles2[5].Area(), 2)}";
            comparerT = $"Type = Triangle, subtype = {_names[5]}, a = {_Triangles2[5].A}, b = {_Triangles2[5].B}, c = {_Triangles2[5].C}, with S = {Math.Round(_Triangles2[5].Area(), 2)}";
            Assert.AreEqual(comparerS, _Circles2[5].ToString());
            Assert.AreEqual(comparerR, _Fourangles2[5].ToString());
            Assert.AreEqual(comparerT, _Triangles2[5].ToString());
        }
        [TestMethod()]
        public void Task2CheckSort()
        {
            Task2.Figure[] figures = new Task2.Figure[size];
            for (int i = 0; i < size; i++)
            {
                int[] reversed = new int[] { size - 1 - i, size - 1 - i, size - 1 - i };
                if (i < size / 3)
                {
                    figures[i] = new Task2.Circle(reversed);
                }
                else
                if (i >= size / 3 && i < 2 * size / 3)
                {
                    figures[i] = new Task2.Fourangle(reversed);
                }
                else
                {
                    figures[i] = new Task2.Triangle(reversed);
                }
            }
            Task2 answer = new Task2(figures);
            answer.Sorting();
            for (int i = 0; i < size - 1; i++)
            {
                Assert.IsTrue(answer.Figures[i].Area() <= answer.Figures[i + 1].Area());
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
            Assert.IsTrue(_Circles2[0] is Task2.Circle);
            Assert.IsTrue(_Circles2[0] is Task2.Figure);
            Assert.IsFalse(_Circles2[0] is Task2.Triangle);
            Assert.IsFalse(_Circles2[0] is Task2.Fourangle);
            Assert.IsFalse(_Fourangles2[0] is Task2.Circle);
            Assert.IsTrue(_Fourangles2[0] is Task2.Figure);
            Assert.IsTrue(_Fourangles2[0] is Task2.Fourangle);
            Assert.IsFalse(_Fourangles2[0] is Task2.Triangle);
            Assert.IsFalse(_Triangles2[0] is Task2.Circle);
            Assert.IsTrue(_Triangles2[0] is Task2.Figure);
            Assert.IsFalse(_Triangles2[0] is Task2.Fourangle);
            Assert.IsTrue(_Triangles2[0] is Task2.Triangle);
        }
        [TestMethod()]
        public void Task3CheckNull()
        {
            Task3.Uniques answer = new Task3.Uniques(nullText);
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task3CheckEmpty()
        {
            Task3.Uniques answer = new Task3.Uniques(emptyText);
            Assert.AreEqual(emptyText, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckConstructor()
        {
            Task3.Uniques answer = new Task3.Uniques(text);
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckOutput()
        {
            Task3.Uniques answer = new Task3.Uniques(text);
            string[] output = new string[] { "на", "мира", "таких", "сокрытие", "цель", "том", "чтобы", "связать", "таким", "чтобы", "другая", "часть", "кода", "не", "могла", "получить", "доступ", "этим", "кроме", "этой" };
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output[i], answer.Output[i]);
            }
        }
        [TestMethod()]
        public void Task3CheckPrint()
        {
            Task3.Uniques answer = new Task3.Uniques(text);
            string output = "на\nмира\nтаких\nсокрытие\nцель\nтом\nчтобы\nсвязать\nтаким\nчтобы\nдругая\nчасть\nкода\nне\nмогла\nполучить\nдоступ\nэтим\nкроме\nэтой";
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output, answer.ToString());
            }
        }

        [TestMethod()]
        public void Task4CheckInheritance()
        {
            Task4.UniquesSerializer seerializer = new Task4.UniquesSerializer();
            Assert.IsTrue(seerializer is Task4.AbstractSerializer);
        }
        [TestMethod()]
        public void Task4CheckFolderCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Task4.UniquesSerializer serializer = new Task4.UniquesSerializer();
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
            Task4.UniquesSerializer serializer = new Task4.UniquesSerializer();
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
            Task4.UniquesSerializer serializer = new Task4.UniquesSerializer();
            Task3.Uniques Searcherer = new Task3.Uniques(text);
            serializer.Serialize(Searcherer, path);
            var answer = serializer.Deserialize<Task3.Uniques>(path);
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