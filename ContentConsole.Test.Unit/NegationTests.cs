using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    public class NegationTests
    {
        [Test]
        public void GetTotalCount()
        {
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string result = Program.GetTotalNumberOfBadWords(content);

            Assert.AreEqual("Total count of bad words : 2", result);
        }

        [Test]
        public void FilterBadWords()
        {
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string result = Program.FilterBadWords(content);

            Assert.AreEqual("The weather in Manchester in winter is b#d. It rains all the time - it must be h#######e for people visiting.", result);
        }

        [Test]
        public void DisableBadFiltering()
        {
            var content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string result = Program.DisableBadFiltering(content);
            string count = Program.GetTotalNumberOfBadWords(content);

            Assert.AreEqual("Total count of bad words : 2The weather in Manchester in winter is . It rains all the time - it must be  for people visiting.", count + result);
        }
    }
}
