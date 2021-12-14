using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3_FileStatistic
{
    class Program
    {
        /*
         * Вручную подготовьте текстовый файл с фрагментом текста. Напишите программу, которая выводит статистику по файлу 
         * - количество символов, строк и слов в тексте.
         */
        static void Main(string[] args)
        {
            const string path = "Text.txt";
            int charCount = 0;
            int lineCount = 0;
            int wordCount = 0;
            string line;

            if (!File.Exists(path)) //Блок проверки наличия файла
            {
                Console.WriteLine($"Файл {path} не найден !");
                Console.ReadKey();
                return;
            }

            using (StreamReader Reader = new StreamReader(path))
            {
                Console.WriteLine("Содержимое файла\n\n-----Начало-----");
                while ((line = Reader.ReadLine()) != null) //Значение null - конец входного потока. Цикл выполняется пока его не достигнет
                {
                    Console.WriteLine(line); //Считываем строку
                    lineCount++; //Увеличиваем счетчик строк
                    charCount += line.Length; //Подсчитываем длину строки
                    wordCount += line.Split().Length; //Разбиваем строку на массив строк с разделителем пробел, считываем количество.
                    #region Отладка
                    //for (int i = 0; i <= line.Length; i++)
                    //    charCount++;
                    // Console.WriteLine($"Количество слов: {line.Split().Length}\nКоличество символов: {line.Length}");
                    #endregion
                }
                Console.WriteLine("-----Конец------\n\nСтатистика по файлу.\n");
                Console.WriteLine($"Количество строк: {lineCount}\nКоличество слов: {wordCount}\nКоличество символов (без \\n): {charCount}");
            }

            Console.ReadKey();
        }
    }
}
