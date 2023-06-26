using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;

namespace Dictionary
{
    class Dictionary
    {
        string file1;
        string file2;
        string language;
        public void installation(string file1, string file2,string language)
        {
            this.file1 = file1;
            this.file2 = file2;
            this.language = language;
        }
        public void Add_word()
        {
            try {
                string[] lines = File.ReadAllLines(file1);
                string[] lines2 = File.ReadAllLines(file2);
                List<string> list1 = new List<string>();
                List<string> list2 = new List<string>();
                foreach (string i in lines)
                {
                    list1.Add(i);
                }
                foreach (string i in lines2)
                {
                    list2.Add(i);
                }
                Console.Write("Напишите слово, которое хотите добавить: ");
                string v1 = Console.ReadLine();
                if (Language_check1(v1))
                {
                    throw new Exception("Неверный язык");
                }
                Console.Write("Напишите перевод: ");
                string v2 = Console.ReadLine();
                if (Language_check2(v2))
                {
                    throw new Exception("Неверный язык");
                }
                list1.Add(v1);
                list1.Sort();
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i] == v1)
                    {
                        list2.Insert(i, v2);
                    }
                }
                Add_file(list1, list2);
            }
            catch (Exception my)
            {
                Console.WriteLine(my.Message);
            }
        }
        public bool Language_check1(string l)
        {
            bool t = false;
            //if (language == "english")
            //{
            //    if(Regex.IsMatch(l, "[^A-Za-z]+"))
            //    {
            //        t = true;
            //    }
            //}
            if (language == "english")
            {
                int k = 0;
                foreach (char ch in l)
                {
                    if ((int)ch >= 97 && (int)ch <= 122 || (int)ch == 20 || (int)ch == 44 || (int)ch == 150)
                    {
                        k++;
                    }
                }
                if (k == l.Length) { t = true; }
            }
            if (language == "русский")
            {
                if (!Regex.IsMatch(l, "[^A-Za-z]+"))
                {
                    t = true;
                }
            }
            return t;
        }
        public bool Language_check2(string l)
        {
            bool t = false;
            if (language == "english")
            {
                if (!Regex.IsMatch(l, "[^A-Za-z]+"))
                {
                    t = true;
                }
            }
            if (language == "русский")
            {
                int k = 0;
                foreach (char ch in l)
                {
                    if ((int)ch >= 97 && (int)ch <= 122 || (int)ch == 20 || (int)ch == 44 || (int)ch == 150)
                    {
                        k++;
                    }
                }
                if (k == l.Length) { t = true; }
            }
            return t;
        }
        public void Add_file(List<string> list1, List<string> list2)
        {
            StreamWriter dic1 = new StreamWriter(file1, false);
            StreamWriter dic2 = new StreamWriter(file2, false);
            for (int i = 0; i < list1.Count; i++)
            {
                dic1.Write(list1[i]); dic1.WriteLine();
            }
            for (int i = 0; i < list2.Count; i++)
            {
                dic2.Write(list2[i]); dic2.WriteLine();
            }
            dic1.Close(); dic2.Close();
        }
        public void Replace_word()
        {
            try
            {
                string[] lines = File.ReadAllLines(file1);
                string[] lines2 = File.ReadAllLines(file2);
                List<string> list1 = new List<string>();
                List<string> list2 = new List<string>();
                foreach (string i in lines)
                {
                    list1.Add(i);
                }
                foreach (string i in lines2)
                {
                    list2.Add(i);
                }
                Console.WriteLine("Выберите, что хотите сделать: ");
                Console.WriteLine("1 - заменить слово");
                Console.WriteLine("2 - заменить перевод слова");
                Console.WriteLine("3 - заменить слово и его перевод в словаре");
                Console.WriteLine("4 - назад");
                Console.Write("Ваш выбор: "); int vibor2 = int.Parse(Console.ReadLine());
                if(vibor2 == 1)
                {
                    Console.WriteLine("Cловарь");
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Console.WriteLine(list1[i] + "  -------   " + list2[i]);
                    }
                    Console.Write("Напишите слово, которое хотите заменить: ");
                    string v = Console.ReadLine();
                    if (Language_check1(v))
                    {
                        throw new Exception("Неверный язык");
                    }
                    Console.Write("Напишите слово,на которое хотите заменить: ");
                    string v1 = Console.ReadLine();
                    if (Language_check1(v1))
                    {
                        throw new Exception("Неверный язык");
                    }
                    int k = 0;
                    int y =0;
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] == v) k = i;y = 1;
                    }
                    if (y == 0) Console.WriteLine("Такого слова нет в словаре!! ");
                    string v2 = list2[k];
                    list1.RemoveAt(k); list2.RemoveAt(k);
                    list1.Add(v1);
                    list1.Sort();
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] == v1)
                        {
                            list2.Insert(i, v2);
                        }
                    }
                    Add_file(list1, list2);
                }
                else if(vibor2 == 2)
                {
                    Console.WriteLine("Cловарь");
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Console.WriteLine(list1[i] + "  -------   " + list2[i]);
                    }
                    Console.Write("Напишите слово, перевод которого хотите заменить: ");
                    string v = Console.ReadLine();
                    if (Language_check1(v))
                    {
                        throw new Exception("Неверный язык");
                    }
                    Console.Write("Напишите новый перевод: ");
                    string v2 = Console.ReadLine();
                    if (Language_check2(v2))
                    {
                        throw new Exception("Неверный язык");
                    }
                    int k = 0;
                    int y = 0;
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] == v) k = i;y = 1;
                    }
                    if (y == 0) Console.WriteLine("Такого слова нет в словаре!! ");
                    list2.RemoveAt(k);
                    list2.Insert(k, v2);
                    Add_file(list1, list2);
                }
                else if (vibor2 == 3)
                {
                    Console.WriteLine("Cловарь");
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Console.WriteLine(list1[i] + "  -------   " + list2[i]);
                    }
                    Console.Write("Напишите слово, которое хотите заменить: ");
                    string v = Console.ReadLine();
                    if (Language_check1(v))
                    {
                        throw new Exception("Неверный язык");
                    }
                    Console.Write("Напишите слово,на которое хотите заменить: ");
                    string v1 = Console.ReadLine();
                    if (Language_check1(v1))
                    {
                        throw new Exception("Неверный язык");
                    }
                    Console.Write("Напишите перевод: ");
                    string v2 = Console.ReadLine();
                    if (Language_check2(v2))
                    {
                        throw new Exception("Неверный язык");
                    }
                    int k = 0;
                    int y = 0;
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] == v) k = i;y = 1;
                    }
                    if (y == 0) Console.WriteLine("Такого слова нет в словаре!! ");
                    list1.RemoveAt(k); list2.RemoveAt(k);
                    list1.Add(v1);
                    list1.Sort();
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] == v1)
                        {
                            list2.Insert(i, v2);
                        }
                    }
                    Add_file(list1, list2);
                }
                else if(vibor2==4){}
                else {Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз!!");}
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз!!");
            }
            catch (Exception my)
            {
                Console.WriteLine(my.Message);
            }
        }
        public void Delete_word()
        {
            try {
                string[] lines = File.ReadAllLines(file1);
                string[] lines2 = File.ReadAllLines(file2);
                List<string> list1 = new List<string>();
                List<string> list2 = new List<string>();
                foreach (string i in lines)
                {
                    list1.Add(i);
                }
                foreach (string i in lines2)
                {
                    list2.Add(i);
                }
                Console.WriteLine("Cловарь");
                for (int i = 0; i < list1.Count; i++)
                {
                    Console.WriteLine(list1[i] + "  -------   " + list2[i]);
                }
                Console.Write("Напишите слово, которое хотите удалить: ");
                string v = Console.ReadLine();
                if (Language_check1(v))
                {
                    throw new Exception("Неверный язык");
                }
                int k = 0;
                int y = 0;
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i] == v) k = i;y= 1;
                }
                if (y == 0) Console.WriteLine("Такого слова нет в словаре!! ");
                list1.RemoveAt(k); list2.RemoveAt(k);
                Add_file(list1, list2);
            }
            catch (Exception my)
            {
                Console.WriteLine(my.Message);
            }
        }
        public void Search_word()
        {
            try {
                string[] lines = File.ReadAllLines(file1);
                string[] lines2 = File.ReadAllLines(file2);
                Console.Write("Напишите слово, у которого хотите узнать перевод: ");
                string v = Console.ReadLine();
                if (Language_check1(v))
                {
                    throw new Exception("Неверный язык");
                }
                int y = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == v)
                    {
                        Console.Write("Перевод слова: "); Console.WriteLine(lines2[i]);
                        y = 1;
                    }
                }
                if (y == 0) Console.WriteLine("Такого слова нет в словаре!! ");
            }
            catch (Exception my)
            {
                Console.WriteLine(my.Message);
            }
        }
        public void Export_dictionary()
        {
            string[] lines = File.ReadAllLines(file1);
            string[] lines2 = File.ReadAllLines(file2);
            Console.Write("Напишите путь, в который сохранить путь: ");
            string v = Console.ReadLine();
            using (FileStream fstream = new FileStream(v+ "\\dictionary.txt", FileMode.OpenOrCreate)) { }
            StreamWriter dic1 = new StreamWriter(v + "\\dictionary.txt", false);
            for (int i = 0; i < lines.Length; i++)
            {
                dic1.WriteLine(lines[i]+"   ---   "+ lines2[i]);
            }
            dic1.Close();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = 2;
            Dictionary dic = new Dictionary();
            while (t != 0)
            {
                try {
                    Console.WriteLine("Выберите, какой словарь хотите: ");
                    Console.WriteLine("1 - англо-русский ");
                    Console.WriteLine("2 - русско-английский");
                    Console.Write("Ваш выбор: "); int vibor = int.Parse(Console.ReadLine());
                    if (vibor == 2)
                    {
                        dic.installation("C:\\Users\\USER\\source\\repos\\Dictionary\\Dictionary\\Dictionarys\\dicrus1.txt", "C:\\Users\\USER\\source\\repos\\Dictionary\\Dictionary\\Dictionarys\\dicengl2.txt","русский");
                    }
                    else
                    {
                        dic.installation("C:\\Users\\USER\\source\\repos\\Dictionary\\Dictionary\\Dictionarys\\dicengl1.txt", "C:\\Users\\USER\\source\\repos\\Dictionary\\Dictionary\\Dictionarys\\dicrus2.txt", "english");
                    }
                    t = 2;
                    while (t != 1)
                    {
                        Console.WriteLine("Выберите, что хотите сделать: ");
                        Console.WriteLine("1 - добавить слово и его перевод в словарь");
                        Console.WriteLine("2 - заменить слово и его перевод в словаре");
                        Console.WriteLine("3 - удалить слово и его перевод в словаре");
                        Console.WriteLine("4 - искать перевод слова");
                        Console.WriteLine("5 - экспортировать словарь");
                        Console.WriteLine("6 - назад");
                        Console.WriteLine("7 - выход");
                        Console.Write("Ваш выбор: "); int vibor2 = int.Parse(Console.ReadLine());
                        if (vibor2 == 1)
                        {
                            dic.Add_word();
                        }
                        else if (vibor2 == 2)
                        {
                            dic.Replace_word();
                        }
                        else if (vibor2 == 3)
                        {
                            dic.Delete_word();
                        }
                        else if (vibor2 == 4)
                        {
                            dic.Search_word();
                        }
                        else if (vibor2 == 5)
                        {
                            dic.Export_dictionary();
                        }
                        else if (vibor2 == 6)
                        {
                            t = 1;
                        }
                        else if (vibor2 == 7)
                        {
                            t = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз!!");
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз!!");
                }
            }
        }
    }
}
