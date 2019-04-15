using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

namespace UnitTestLogManager
{
    [TestClass]
    public class DirectoryTesting
    {
        SystemManager systemManager = new SystemManager();

        [TestMethod]
        public void EmptyDirectory()
        {
            string testStr = string.Empty;
            Assert.AreEqual(false, systemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void NullDirectory()
        {
            string testStr = null;
            Assert.AreEqual(false, systemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void WhitespaceDirectory()
        {
            string testStr = " ";
            Assert.AreEqual(false, systemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void OneCharDirectory()
        {
            string testStr = "a";
            Assert.AreEqual(false, systemManager.IsValidDirectory(testStr));
        }

        [TestMethod]
        public void CDriveDirectory()
        {
            string testStr = "C:";
            Assert.AreEqual(true, systemManager.IsValidDirectory(testStr));
        }

    }
}
