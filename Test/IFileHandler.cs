using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Test
{
    public interface IFileHandler
    {

        List<string> GetFileList(string directoryInput);

        void FindFilesContaining(List<string> fileList, string[] keywords);

        List<string> FindFileDirectory(List<string> fileList, string[] fileNames);

        void AddTimeStamp(List<string> fileDirectoryList);

        List<string> RetrieveEmptyFiles(List<string> fileList);

        void RemoveEmptyFiles(List<string> fileList);

    }
}