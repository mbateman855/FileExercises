using System;
using System.Collections.Generic;
using System.IO;

namespace FileExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 67
            var fileName = "numbers";

            CreateFile(fileName);

            WriteToFile(fileName);

            ReadFile(fileName);

            File.Delete(fileName);

            //Exercise 68
            var dictFileName = "dictionary";

            CreateFile(dictFileName);

            WriteDictionary(dictFileName);

            File.Delete(dictFileName);
        }
        static void CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            
            //try putting the create back in the same scope and do "using" to see if it can let go of the resource
        }

        static void WriteToFile(string fileName)
        {
            //var fileName = "number.txt";
            List<int> fileNums = new List<int> { 7, 12, 13, 15, 12, 11 }; 
            //File.Create(fileName);
            using StreamWriter streamWriter = new StreamWriter(fileName, true);

            foreach(int number in fileNums)
            {
                streamWriter.WriteLine(number);
            }
        }
        
        static void WriteDictionary(string fileName)
        {
            Dictionary<string, string> translation = new Dictionary<string, string>();
            translation.Add("hello", "hola");
            translation.Add("food", "comida");
            translation.Add("world", "mundo");
            translation.Add("computer", "computadora");
            translation.Add("exercise", "ejercicio");

            using StreamWriter streamWriter = new StreamWriter(fileName);

            foreach (var tran in translation)
            {
                streamWriter.WriteLine(tran);
            }
           
        }

        static void ReadFile(string fileName)
        {
            using StreamReader streamReader = new StreamReader(fileName);

            int sum = 0;

            while (!streamReader.EndOfStream)
            {
                sum += int.Parse(streamReader.ReadLine());
            }

            Console.WriteLine($"Your sum is {sum}");
        }
    }
}
