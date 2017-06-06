using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class DisallowedWordRepo
    {
        [Test]
        public void Repo_Contains_Starting_Words()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();

            // Act.
            var words = repo.GetDisallowedWords();

            // Assert.
            Assert.That(words.Count, Is.EqualTo(4));

        }

        [Test]
        public void Can_Add_Disallowed_Word_To_Repo()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();

            // Affirm.
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(4));

            // Act.
            var result = repo.AddDisallowedWord("ugly");

            // Assert.
            Assert.That(result, Is.True);
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(5));

        }

        [Test]
        public void Cannot_Add_Existing_Disallowed_Word_To_Repo()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();
            var words = repo.GetDisallowedWords();

            // Affirm.
            Assert.That(words.Count, Is.EqualTo(4));

            // Act.
            var result = repo.AddDisallowedWord(words[0]);

            // Assert.
            Assert.That(result, Is.False);
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(4));

        }

        [Test]
        public void Cannot_Add_Existing_Disallowed_Word_To_Repo_Case_Insensitive()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();
            var words = repo.GetDisallowedWords();

            // Affirm.
            Assert.That(words.Count, Is.EqualTo(4));

            // Act.
            var result = repo.AddDisallowedWord(words[0].ToUpper());

            // Assert.
            Assert.That(result, Is.False);
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(4));

        }

        [Test]
        public void Can_Remove_Disallowed_Word_From_Repo()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();
            var words = repo.GetDisallowedWords();

            // Affirm.
            Assert.That(words.Count, Is.EqualTo(4));

            // Act.
            var result = repo.RemoveDisallowedWord(words[0]);

            // Assert.
            Assert.That(result, Is.True);
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(3));

        }

        [Test]
        public void Can_Remove_Disallowed_Word_From_Repo_Case_Insensitive()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();
            var words = repo.GetDisallowedWords();

            // Affirm.
            Assert.That(words.Count, Is.EqualTo(4));

            // Act.
            var result = repo.RemoveDisallowedWord(words[0].ToUpper());

            // Assert.
            Assert.That(result, Is.True);
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(3));

        }

        [Test]
        public void Cannot_Remove_Disallowed_Word_From_Repo_Doesnt_Exist()
        {

            // Arrange.
            var repo = new ContentConsole.DisallowedWordRepo();
            var words = repo.GetDisallowedWords();

            // Affirm.
            Assert.That(words.Count, Is.EqualTo(4));

            // Act.
            var result = repo.RemoveDisallowedWord("Humbug");

            // Assert.
            Assert.That(result, Is.False);
            Assert.That(repo.GetDisallowedWords().Count, Is.EqualTo(4));

        }
    }
}
