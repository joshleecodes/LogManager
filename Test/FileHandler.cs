using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class FileHandler
    {
        public static List<string> GetFileList(string directoryInput)
        {
             return Directory.EnumerateFiles(directoryInput).ToList();
        }

        public static void DisplayFileNames(List<string> fileList)
        {
            if (fileList.Any())
            {
                foreach (var file in fileList)
                {
                    Console.WriteLine(file);
                }

            }
            else
            {
                Console.WriteLine("No fileList found.");
            }
        }

        public static void FindFilesContaining(List<string> fileList, string[] keywords)
        {
            foreach (var file in fileList) //loop through all fileList
            {
                string[] lines = File.ReadAllLines(file); //Store content of fileList into a string array
                for (int i = 0; i < lines.Length; i++)  //For each line
                {
                    for (int j = 0; j < keywords.Length; j++) //change keyword on each iteration
                    {
                        if (lines[i].Contains(keywords[j]))  //search through document for keyword
                        {
                            string currentFileName = Path.GetFileName(file);
                            Console.WriteLine($"Keyword ({keywords[j]}) found in {currentFileName} at line {i}. Line content: {lines[i]}"); //output file name + line containing keyword
                        }
                    } 
                }
                
            }
        }

        public static List<string> FindFileDirectory(List<string> fileList, string[] fileNames)
        {
            List<string> fileDirectories = new List<string>();
            foreach (var file in fileList)
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    if (fileNames[i] == Path.GetFileName(file))
                    {
                        fileDirectories.Add(Path.GetFullPath(file));
                    }
                }
            }
            return fileDirectories;
        }

        public static void AddTimeStamp(List<string> fileDirectoryList)
        {
            string currentTimeStamp = DateTime.Now.ToString();
            foreach (var fileDirectory in fileDirectoryList)
            {
                using (StreamWriter sw = File.AppendText(fileDirectory))
                {
                    sw.WriteLine("\nLast time stamped at " + currentTimeStamp);
                }
            }
        }

        public static List<string> RetrieveEmptyFiles(List<string> fileList)
        {
            List<string> emptyFilesList = new List<string>();
            foreach (var file in fileList) //Loop through fileList
            {
                string fileContent = File.ReadAllText(file);
                if (String.IsNullOrWhiteSpace(fileContent)) //Check if file is empty
                {
                    emptyFilesList.Add(Path.GetFullPath(file));
                }
            }
            return emptyFilesList;
        }

        public static void RemoveEmptyFiles(List<string> fileList)
        {
            foreach (var file in fileList) //Loop through fileList
            {
                string fileContent = File.ReadAllText(file);
                if (String.IsNullOrWhiteSpace(fileContent)) //Check if file is empty
                {
                    //delete file if empty
                    Console.WriteLine($"Empty file found: {Path.GetFileName(file)} File has been deleted");
                    File.Delete(file);
                }
            }
        }
    }
}
