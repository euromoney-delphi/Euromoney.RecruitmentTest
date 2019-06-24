using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class UnitTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Test1()
        {
            //Arrange
            List<string> badWords = new List<string>()
            {
                "swine", "bad", "nasty", "horrible"
            };

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            //Act
            int badWordCount = WordAnalizer.CountBadWords(content, badWords);

            //Assert
            Assert.AreEqual(2, badWordCount);
        }


        public void Test2()
        {
            //Arrange
            List<string> badWords = new List<string>()
            {
                "the", "bad", "nasty", "horrible"
            };

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            //Act
            int badWordCount = WordAnalizer.CountBadWords(content, badWords);

            //Assert
            Assert.AreEqual(4, badWordCount);
        }
    }

}
