using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    public class SystemManager
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\nPlease choose an option by entering one of the numbers listed below:");
            Console.WriteLine("\n1. Display all files in directory \n2. Search for a file containing a keyword " +
                              "\n3. Add timestamp to a file \n4. Remove empty logs \n5. Change active directory \n6. Exit\n");
        }

        public void UpdateDirectory(string directoryInput)
        {
            Program.Directory = directoryInput;
        }

        public bool IsValidDirectory(string directoryInput)
        {
            if (!string.IsNullOrEmpty(directoryInput) && Directory.Exists(directoryInput))
            {
                string invalidRegexPattern = @"([,!#$%^&*()\[\]]+|\\\.\.|\\\\\.|\.\.\\\|\.\\\|\.\.\/|\.\/|\/\.\.|\/\.|;|(?<![A-Z]):)";
                Regex regex = new Regex(invalidRegexPattern);
                MatchCollection matches = regex.Matches(directoryInput);
                if (matches.Count == 0)
                {
                    Console.WriteLine("Valid directory input");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid directory input");
                    foreach (Match match in matches)
                    {
                        Console.WriteLine("Directory contains invalid character" + match);
                    }
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid directory input");
                Console.WriteLine("Directory is null or does not exist");
                return false;
            }        
        }

        public string[] MultipleInputCheck(string fileNameInput)
        {
                string[] fileNames = fileNameInput.Split(',');
                return fileNames;
        }
    }
}
