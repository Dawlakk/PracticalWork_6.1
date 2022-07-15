using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticalWork_6._1
{
    internal class Program
    {
        static void Checking()
        {
            bool z = File.Exists("directory.txt");
            if (z == false)
            {
                File.WriteAllText("directory.txt", "Список сотрудников\n", Encoding.Unicode);
            }
        }
        static void Output()
        {
            string[] lines = File.ReadAllLines("directory.txt");
            foreach (var line in lines) Console.WriteLine(line.Replace("#", "   "));
        }
        static void Filling(int count)
        {

            using (StreamWriter sw = new StreamWriter("directory.txt", true, Encoding.Unicode))
            {
                string note = string.Empty;
                Console.WriteLine($"Порядковый номер записи: {count}");
                note = $"{count}#";

                string now = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                Console.WriteLine($"Дата и время записи {now}");
                note += $"{now}#";

                Console.Write("Введите Ф.И.О. сотрудника: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите возраст: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите рост сотрудника: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите дату рождения: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите место рождения: ");
                note += $"{Console.ReadLine()}";
                sw.WriteLine(note);
            }
        }

        static void Main(string[] args)
        {
            Checking();
            bool x = true;
            while (x == true)
            {
                int count = File.ReadAllLines("directory.txt").Length;
                Console.WriteLine($"\nНажмите 1, если хотите просмотреть содержимое справочника и выйти из программы.\nНажмите 2, если хотите добавить новую запись в справочник.");
                string n = Console.ReadLine();
                if (n == "1") { Output(); x = false; }
                else if (n == "2") Filling(count);
                else Console.WriteLine("Некорректный ввод, попробуйте снова");
            }
            Console.ReadLine();
        }
    }
}
