using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

namespace UnitTestLogManager
{
    [TestClass]
    public class DirectoryTesting
    {
        [TestMethod]
        public void EmptyDirectory()
        {
            string testStr = string.Empty;
            Assert.AreEqual(false, SystemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void NullDirectory()
        {
            string testStr = null;
            Assert.AreEqual(false, SystemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void WhitespaceDirectory()
        {
            string testStr = " ";
            Assert.AreEqual(false, SystemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void OneCharDirectory()
        {
            string testStr = "a";
            Assert.AreEqual(false, SystemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void CDriveDirectory()
        {
            string testStr = "C:";
            Assert.AreEqual(true, SystemManager.IsValidDirectory(testStr));
        }

    }
}
