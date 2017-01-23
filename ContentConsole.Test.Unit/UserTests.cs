using System;
using NUnit.Framework;

namespace ContentConsole.Test
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void UserTestReturnBannedContentWords()
        {
            //Arrange
            UserCase usercase = new UserCase();
            //Act
            usercase.CheckBannedWords();
            int no = usercase.badWords;
            //Assert
            Assert.AreEqual(2, no);
        }

        [Test]
        public void AdminUserTestReturnBannedWordsList()
        {
            //Arrange
            AdministratorCase usercase = new AdministratorCase();
            //Act
            string words = usercase.BannedWordsLists();

            //Assert
            Assert.IsTrue(words.Contains("horrible"));
        }

        [Test]
        public void AdminUserTestReturnNewlyAddedBannedWords()
        {
            //Arrange
            AdministratorCase usercase = new AdministratorCase();
            //Act
            usercase.AddBannedWords("sick");
            string words = usercase.BannedWordsLists();

            //Assert
            Assert.IsTrue(words.Contains("sick"));
            Assert.AreEqual(5, usercase.badWords);
        }
        
        [Test]
        public void ReaderUserTestReturnBannedwordsAsHash()
        {
            //Arrange
            ReaderCase usercase = new ReaderCase();
            //Act
            string words = usercase.GetReaderContent();

            //Assert
            Assert.IsTrue(words.Contains("b#d"));
        }

        [Test]
        public void ContenturatorUserTestReturnOriginalcontent()
        {
            //Arrange
            ContentCuratorCase usercase = new ContentCuratorCase();
            //Act
            string words = Content.content;

            //Assert
            Assert.IsFalse(words.Contains("b#d"));
        }
    }
}
