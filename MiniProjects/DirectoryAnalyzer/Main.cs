using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DirectoryAnalyser
{

    class Program
    {

        public static void Main()
        {
            StartUI();
        }

        static void StartUI()
        {
            Console.Clear();
            Console.WriteLine("Enter a Dir to analyse:");
            Input();
        }
        
        public static void Input()
        {
            string? MethodOutput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(MethodOutput))
            {
                try
                {
                    AnalyzeAll(MethodOutput);
                }
                catch
                {
                    Console.WriteLine("Something went wrong... Press any key to try again");
                    Console.ReadKey();
                    StartUI();
                }
            }
            else
            {
                Console.Clear();
                StartUI();
            }
        }

        public static void AnalyzeForSubDirectories(string Path)
        {
            Console.WriteLine($"You are analyzing the Directory: {Path}");
            DirectoryInfo dir = new(Path);
            DirectoryInfo[] ToDisplay = dir.GetDirectories();
            Console.WriteLine("The number of subdirectories is: " + ToDisplay.Length);
        }
        
        public static void AnalyzeForTotalDirSize(string Path)
        {
            long TotalSize = 0;

            DirectoryInfo DirInfo = new(Path);
     
            DirectoryInfo[] DirList = DirInfo.GetDirectories();

            foreach (DirectoryInfo Dir in DirList) // makes list for each step? Inefficient?
            {
                FileInfo[] FileInfoList = Dir.GetFiles(); // for each directory a new list? for each list a new list to read files from?

                foreach (FileInfo fileInfo1 in FileInfoList)
                {
                    TotalSize += fileInfo1.Length;
                }
            }
            Console.WriteLine(TotalSize);
        }
        
        public static void AnalyzeForTotalFileCount(string Path) // Wo ist meine Zeit hin? Und wieso war ich trotz ihr so machtlos? 
        {
            int FileCount = 0;
            string[] files = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                FileCount++; // oder +=
            }
            Console.WriteLine(FileCount);
        }
        
        public static void AnalyzeAll(string Path)
        {
            long TotalSize = 0;
            int TotalSubDirs = 0;
            int FileCount = 0;
            
            // Total SubDirs
            string[] DirSearch = Directory.GetDirectories(Path,"*.*",SearchOption.AllDirectories);
            foreach (string  dir in DirSearch)
            {
                TotalSubDirs ++;
            }

            // Amount of Files
            string[] files = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                FileCount++; // oder +=
            }

            // Total Size
            string[] SizeSearch = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
            
            foreach (string file in SizeSearch)
            {
                FileInfo f1 = new(file);
                TotalSize += f1.Length;
            }

            // Convert to Mb
            double ConvertToMb = TotalSize / Math.Pow(1024, 2);
            double FinalResult = Math.Round(ConvertToMb, 2);

            // Display 
            Console.WriteLine($"You are analyzing the Directory: {Path}");
            Console.WriteLine();
            Console.WriteLine($"Total Size: {FinalResult} mb");
            Console.WriteLine($"Amount of Files: {FileCount}");
            Console.WriteLine($"Subdirectories: {TotalSubDirs}");

        }

    }

}


