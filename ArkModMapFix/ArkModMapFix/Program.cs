using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ArkModMapFix
{
    class Program
    {

        string directory;
        string[] directories;
        string[] files;
        int count = 0;
        static string[] noScan = { "TheCenter", "Ragnarok", "ArkModMapFix" };

        public Program(string directory)
        {
            files = ReturnFiles(directory).ToArray();
            directories = ReturnFolders(directory).ToArray();
            this.directory = directory;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Where is your Steam folder located? (Example: C:\\Program Files\\Steam\\)");
            string directory = Console.ReadLine();

            Program p = new Program(directory + "steamapps\\common\\ARK\\ShooterGame\\Content\\Mods");

            foreach (string path in p.directories)
            {

                if(!p.files.Contains(path))
                {
                    if (!noScan.Contains(path))
                    {
                        p.count += 1;
                        Console.WriteLine("Delete folder: " + path);
                    }
                }

                

            }


            Console.WriteLine("Total files mismatched: " + p.count);
            Console.WriteLine("Directory: " + p.directory);
            Console.ReadLine();
        }

        List<string> ReturnFiles(string path)
        {

            string[] fullFiles = Directory.GetFiles(path);
          
            List<string> finalList = new List<String>();
            
            foreach(string p in fullFiles)
            {
                string[] substrings = p.Split('\\', '.');

                finalList.Add(substrings[substrings.Length - 2]);

            }

            return finalList;
        }

        List<string> ReturnFolders(string path)
        {
            string[] fullFolder = Directory.GetDirectories(path);

            List<string> finalList = new List<String>();

            foreach(string p in fullFolder)
            {
                string[] substrings = p.Split('\\');

                finalList.Add(substrings[substrings.Length - 1]);
            }

            return finalList;

        }

    }

}
