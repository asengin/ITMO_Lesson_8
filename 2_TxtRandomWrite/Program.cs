using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2_TxtRandomWrite
{
    class Program
    {
        /*Программно создайте текстовый файл и запишите в него 10 случайных чисел. Затем программно откройте созданный файл, 
         * рассчитайте сумму чисел в нем, ответ выведите на консоль.
         */
        static void Main(string[] args)
        {
            string path = "Numbers.txt";
            Random random = new Random();
            const int num = 10; //Константа, количество генерируемых значений
            int[] numbersFromFile = new int[num]; //Инициализируем массив для чисел из файла
            int sumNumFromFile = 0; //Сумма считанных значений

            if (!File.Exists(path)) //Создание файла, если нет
                File.Create(path);

            using (StreamWriter Write = new StreamWriter(path))
            {
                for (int i = 0; i < num; i++) //Запись 10 случайных чисел
                    Write.WriteLine(random.Next(-200, 200)); //Генерация случайного числа в заданном диапазоне
            }

            using (StreamReader Read = new StreamReader(path))
            {
                #region Отладочная информация
                // Console.WriteLine(Read.ReadToEnd()); //Вывел все значения
                // Console.WriteLine("---Отработал ReadToEnd---");
                // Console.WriteLine(Read.ReadLine()); //Ничего не выводит, потому что курсор остался в конце

                // int temp = Convert.ToInt32(Read.ReadLine());
                // Console.WriteLine($"Переменная int temp={temp}");
                #endregion
                Console.WriteLine($"Содержимое файла {path}\n-----");
                for (int i = 0; i < num; i++) //Построчное считывание значений из файла
                {
                    numbersFromFile[i] = Convert.ToInt32(Read.ReadLine());
                    Console.WriteLine(numbersFromFile[i]);
                    sumNumFromFile += numbersFromFile[i];
                }
            }
            Console.WriteLine($"-----\nКоличество считанных элементов: {num}\nСумма считанных элементов: {sumNumFromFile}");
            Console.ReadKey();
        }
    }
}
