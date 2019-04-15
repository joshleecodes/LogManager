using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLogManager
{
    [TestClass]
    public class StringSplitTest
    {
        [TestMethod]
        public void SingleValueString()
        {
            string entryString = "one";
            string[] resultStrings = entryString.Split(',');

            Assert.AreEqual("one", resultStrings[0]);

        }

        [TestMethod]
        public void MultipleValueString()
        {
            string entryString = "one,two,three";
            string[] resultStrings = entryString.Split(',');

            Assert.AreEqual("three", resultStrings[2]);
        }

    }
}
