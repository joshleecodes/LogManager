using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public static string Directory
        {
            get;
            set;
        }
        public enum MenuInputValues{ DisplayFiles = 1, FindKeyword = 2,
            AddTimestamp = 3, RemoveEmpty = 4, UpdateDirectory = 5, Exit = 6 }

        static void Main(string[] args)
        {
            //Dir = "C:\Users\joshua.lee\Documents\Omen Log";

            bool programActive = true;
            List<string> fileList = new List<string>();
            string directoryInput;

            SystemManager systemManager = new SystemManager();
            FileHandler fileHandler = new FileHandler();

            Console.WriteLine("Welcome to LogManager");

            while (Directory == null) 
            {
                Console.WriteLine("\nPlease enter a directory...");
                directoryInput = Console.ReadLine();
                if (systemManager.IsValidDirectory(directoryInput))
                {
                    systemManager.UpdateDirectory(directoryInput);
                }
            }

            while (programActive)
            {
                fileList = fileHandler.GetFileList(Directory); //looped to update every available on each iteration

                systemManager.DisplayMenu();
                string userInput = Console.ReadLine();
                MenuInputValues testInput = (MenuInputValues) Enum.Parse(typeof(MenuInputValues), userInput);

                switch (testInput)
                {
                    case MenuInputValues.DisplayFiles:
                        fileHandler.DisplayFileNames(fileList);
                        break;
                    case MenuInputValues.FindKeyword:
                        Console.WriteLine("Please enter a keyword. To enter multiple keywords, separate each keyword only with a comma...\n");
                        string[] keyword = systemManager.MultipleInputCheck(Console.ReadLine());
                        fileHandler.FindFilesContaining(fileList, keyword);
                        break;
                    case MenuInputValues.AddTimestamp:
                        Console.WriteLine("Please enter a file name. To add a timestamp to multiple files, separate each name only with a comma...\n");
                        string[] fileNames = systemManager.MultipleInputCheck(Console.ReadLine());
                        List<string> fileDirectory = fileHandler.FindFileDirectory(fileList, fileNames);
                        fileHandler.AddTimeStamp(fileDirectory);
                        break;
                    case MenuInputValues.RemoveEmpty:
                        List<string> emptyFiles = fileHandler.RetrieveEmptyFiles(fileList);
                        if (emptyFiles.Any())
                        {
                            Console.WriteLine("\nEmpty files found:");
                            fileHandler.DisplayFileNames(emptyFiles);
                            Console.WriteLine("\nType delete remove these files?");
                            string deleteInput = Console.ReadLine();
                            if (deleteInput == "delete" || deleteInput == "Delete")
                            {
                                fileHandler.RemoveEmptyFiles(emptyFiles);
                            }
                            else Console.WriteLine("Files NOT deleted.\n");
                        }
                        else Console.WriteLine("\nNo empty files found.");
                        break;
                    case MenuInputValues.UpdateDirectory:
                        Console.WriteLine("\nPlease enter a directory...");
                        directoryInput = Console.ReadLine();
                        if (systemManager.IsValidDirectory(directoryInput))
                        {
                            systemManager.UpdateDirectory(directoryInput);
                            Console.WriteLine($"Directory updated to: {Directory}");
                        }
                        else Console.WriteLine("Directory was not changed.");
                        break;
                    case MenuInputValues.Exit:
                        programActive = false;
                        break;
                    default:
                        Console.WriteLine("Selection invalid, please type a valid option listed above.");
                        break;
                }
            }            
        }
    }
}
