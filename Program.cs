using System;
using System.Collections.Concurrent;
using System.IO;

namespace homework5_4
{
    internal class Program
    {
        const int N = 10;
        public static string[] FileReader(string filename)
        {
            string myLine, word=null;
            int i=0;
            string[] theFile = new string[N];
            try
            {
                using (StreamReader s = new StreamReader(filename))
                {
                    myLine = s.ReadLine();
                }
                foreach(char c in myLine)
                {
                    if (c == ' ' || c == '$')
                    {
                        theFile[i] = word;
                        word = null;
                        i++;
                    }
                    else
                    {
                        word += c;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, check your directory,please.");
                Console.WriteLine(e.Message);
            }

            return theFile;
        }
        public static void FileInverter(string inputFile, string outputFile)
        {
            string[] words = FileReader(inputFile);
            
            using (StreamWriter sw = File.AppendText(outputFile))
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == "defunct")
                    {
                        continue;
                    }
                    sw.Write(words[i] + " ");
                    sw.Write(i + " ");

                    Console.WriteLine(words[i]);
                    for (int j= i+1; j <= words.Length-1; j++)
                    {
                        if (words[i] == words[j] && words[i] != "defunct")
                        {
                            sw.Write(j + " ");
                            words[j] = "defunct";
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            string[] FileAsStrings = FileReader("input.txt");

            Console.WriteLine("The File has:");
            for (int i=0; i< FileAsStrings.Length; i++)
            {
                Console.WriteLine(FileAsStrings[i]);
            }
            FileInverter("input.txt", "output.txt");
        }
    }
}