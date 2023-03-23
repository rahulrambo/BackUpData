using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.FileHandling
{
    internal class Application
    {
        public static async void Start(string[] args)
        {
            string path = @"D:\MyText.txt";
            PathCreation(path);

            FileHandling fileHandling = new FileHandling();
            fileHandling.ContentWrite(path);
            fileHandling.CountWord(path);
            await fileHandling.ContentReadAsync(path);            
        }
        public static void PathCreation(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = new FileStream(path,FileMode.Create, FileAccess.ReadWrite)) ;
        }
    }
}
