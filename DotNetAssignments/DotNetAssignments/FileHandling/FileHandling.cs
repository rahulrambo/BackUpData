using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.FileHandling
{
    internal class FileHandling
    {
        public void ContentWrite(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File doesn't exist\nSo now creating a file");
            }
            using(FileStream fs=new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                Console.Write("Enter data to write into the File:");
                using(StreamWriter sw=new StreamWriter(fs))
                {
                    sw.WriteLine(Console.ReadLine());
                }
            }
        }
        public async Task ContentReadAsync(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string output = await sr.ReadToEndAsync();
                        Console.WriteLine($"\nUsing Read the output is:{output}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file does not exist!");
            }
        }
        public void CountWord(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Console.WriteLine("Words with the number of Counts:");
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string output = sr.ReadToEnd();
                        char[] arr = {' ',',','\r','\n'};
                        var wordsWithCount = output.Split(arr,StringSplitOptions.RemoveEmptyEntries);                        
                        wordsWithCount.GroupBy(s=>s).ToList().ForEach(s => Console.WriteLine($"{s.Key} appeared {s.Count()} times"));                        
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("There is no such file to count the words");
            }
        }
    }
}
