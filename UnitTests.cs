using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentConsole;

namespace ContentConsole.Test.Unit
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestRemoveBannedWords()
        {
            string output = Program.RemoveBannedWords("This is a test string with some random bad words.", new string[] { "bad", "This" });
            Assert.AreEqual("T##s is a test string with some random b#d words.", output);
        }

        [TestMethod]
        public void TestCountBannedWords()
        {
            int output = Program.CountBannedWords("This is a test string with some random bad words.", new string[] { "bad", "This" });
            Assert.AreEqual(2, output);
        }
    }
}
