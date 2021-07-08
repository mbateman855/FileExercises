using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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

            Console.WriteLine("Enter a word in English:");
            string inputWord = Console.ReadLine();
            ReadDictFile(dictFileName, inputWord);

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

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    using StreamWriter streamWriter = new StreamWriter(fileName, true);

                    foreach (int number in fileNums)
                    {
                        streamWriter.WriteLine(number);
                    }

                    break;
                }
                catch (IOException) when (i<= 5)
                {
                    Thread.Sleep(1000);
                }
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

            for(int i = 0; i <= 5; i++)
            {
                try
                {
                    using StreamWriter streamWriter = new StreamWriter(fileName);

                    foreach (var tran in translation)
                    {
                        streamWriter.WriteLine(tran);
                    }
                }
                catch (IOException) when (i <= 5)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static void ReadDictFile(string fileName, string input)
        {
            for (int i = 0; i <=5; i++)
            {
                try
                {
                    using StreamReader streamReader = new StreamReader(fileName);

                    while (!streamReader.EndOfStream)
                    {
                        var singleLine = streamReader.ReadLine();



                        if (singleLine.Contains(input))
                        {
                            Console.WriteLine($"{input} is {singleLine.Remove(0, input.Length)}");
                        }
                    }
                }
                catch (IOException) when (i <= 5)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static void ReadFile(string fileName)
        {
            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    using StreamReader streamReader = new StreamReader(fileName);

                    int sum = 0;

                    while (!streamReader.EndOfStream)
                    {
                        sum += int.Parse(streamReader.ReadLine());
                    }
                    Console.WriteLine($"Your sum is {sum}");

                    break;
                }
                catch (IOException) when (i <= 5)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
