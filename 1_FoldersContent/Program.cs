using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1_FoldersContent
{
    class Program
    {
        /*
         * Выберите любую папку на своем компьютере, имеющую вложенные директории. Выведите на 
         * консоль ее содержимое и содержимое всех подкаталогов.
         */
        static void Main(string[] args)
        {
            const string path = "Folder for program"; //Исходная папка
            int foldersLevel = 0; //Счетчик вложенности
            ShowDirAndFiles(path, foldersLevel);
            Console.ReadKey();
        }

        static void ShowDirAndFiles(string pathFolders, int foldersLevel)
        {
            string[] dirs = Directory.GetDirectories(pathFolders); //массив с наименованием папок
            string[] files = Directory.GetFiles(pathFolders); //массив с наименованием файлов
            string levelIndent = new string('\t', foldersLevel); //Увеличение отступа в зависимости от счетчика вложенности
            foreach (string i in dirs)
            {
                Console.WriteLine(levelIndent + i); //Выводим папки
                ShowDirAndFiles(i, ++foldersLevel); //Рекурсивно повторяем данную операцию для подпапок, увеличиваем счетчик вложенности
            }
            foreach (string i in files)
                Console.WriteLine(levelIndent + i); //выводим наименование файлов с отступами
        }

    }
}
