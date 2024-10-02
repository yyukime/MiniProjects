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
            Console.WriteLine("Enter a Dir to analyse:");
            Input();
        }
        public static void Input()
        {
            string? MethodOutput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(MethodOutput) == true)
            {
                Console.Clear();
                StartUI();
            }
            else
            {
                AnalyzeForTotalFileCount(MethodOutput);
            }
        }

        public static void AnalyzeForSubDirectories(string SubDirPath)
        {
            Console.WriteLine($"You are analyzing the Directory: {SubDirPath}");

            AnalyzeForTotalDirSize(SubDirPath);

            DirectoryInfo dir = new DirectoryInfo(SubDirPath);
            DirectoryInfo[] ToDisplay = dir.GetDirectories();
            Console.WriteLine("The number of subdirectories is: " + ToDisplay.Length);


        }

        public static void AnalyzeForTotalDirSize(string SizePath)
        {
            long TotalSize = 0;

            DirectoryInfo DirInfo = new DirectoryInfo(SizePath);
            FileInfo fileInfo = new FileInfo(SizePath);
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

        public static void AnalyzeForTotalFileCount(string FileCountPath) // Wo ist meine Zeit hin? Und wieso war ich trotz ihr so machtlos? 
        {
            int FileCount = 0;
            string[] files = Directory.GetFiles(FileCountPath, "*.*" , SearchOption.AllDirectories);  
            foreach (string file in files)
            {
                FileCount ++; // oder +=
            }
            Console.WriteLine(FileCount);
        }
             









    }





}


