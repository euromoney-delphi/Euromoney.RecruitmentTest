using System;
using System.Collections.Generic;
using ContentConsole.Words;
using Domain;
using NSubstitute;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{

    [TestFixture]
    public class WordServiceTest
    {
        private IRepository<Word> _wordsRepository;
        private WordsService _systemUnderTest;
        private IWordsFactory _wordsFactory;
        private IUserProfile _userProfile;

        [SetUp]
        public void Setup()
        {
            _wordsRepository = Substitute.For<IRepository<Word>>();
            _wordsFactory = Substitute.For<IWordsFactory>();
            _userProfile = Substitute.For<IUserProfile>();
            _systemUnderTest = new WordsService(_wordsRepository, _wordsFactory, _userProfile);
        }
 

        [Test]
        public void should_add_correct_word_to_repostory_when_add_word()
        {
            //arrange
            var word = "hello";
            _userProfile.IsAdministrator().Returns(true);

            //act
            _systemUnderTest.AddWord(word);

            //arrange
            _wordsRepository.Received(1).Add(Arg.Is<Word>(x => x.Name == word));
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void should_throw_argumentnullexception_when_add_word_si_null()
        {
            //arange 
            _userProfile.IsAdministrator().Returns(true);

            //act
            _systemUnderTest.AddWord(null);
        }


        [Test]
        [ExpectedException(typeof(NotAllowedException))]
        public void should_throw_notallowedexception_when_no_admin_tries_to_add_word()
        {
            //arrange
            _userProfile.IsAdministrator().Returns(false);

            //act
            _systemUnderTest.AddWord("test");
        }


        [Test]
        public void should_init_factory_with_correct_phrase_when_analyse()
        {
            //arrange
            var phrase = "phrase";

            //act
            _systemUnderTest.Analyse(phrase);

            //arrange
            _wordsFactory.Received(1).Init(Arg.Is<string>(x => x == phrase));
        }


        [Test]
        public void should_add_one_discovered_word_to_factory_when_analyse()
        {
            //arrange
            var phrase = "phraseword1 phraseword2 phraseword3 test test";
            var worda = new Word() {Name = "phraseword1"};
            var testWords = new List<Word>() { worda };
            _wordsRepository.FindAll().Returns(testWords);

            //act
            _systemUnderTest.Analyse(phrase);

            //arrange
            _wordsFactory.Received(1).WithWordFound(Arg.Is<string>(x => x == worda.Name));
        }


        [Test]
        public void should_add_multiple_discovered_word_to_factory_when_analyse()
        {
            //arrange
            var phrase = "phraseword1 phraseword2 phraseword3 test test";
            var worda = new Word() { Name = "phraseword1" };
            var wordb = new Word() { Name = "phraseword2" };
            var wordc = new Word() { Name = "phraseword3" };

            var testWords = new List<Word>() { worda, wordb, wordc };
            _wordsRepository.FindAll().Returns(testWords);

            //act
            _systemUnderTest.Analyse(phrase);

            //arrange
            _wordsFactory.Received(3).WithWordFound(Arg.Any<string>());
        }


        [Test]
        public void should_create_wordresponse_when_analyse()
        {
            //arrange
            var phrase = "phraseword1 phraseword2 phraseword3 test test";
            var worda = new Word() { Name = "phraseword1" };
            _wordsFactory.Create().Returns(new WordResponse());
            //act
            var response = _systemUnderTest.Analyse(phrase);

            //arrange
            Assert.That(response, Is.Not.Null);
            _wordsFactory.Received(1).Create();
        }


        [Test]
        public void should_pretify_wordresponse_when_a_reader_analyse()
        {
            //arrange
            var phrase = "phraseword1 phraseword2 phraseword3 test test";
            var worda = new Word() { Name = "phraseword1" };
            _wordsFactory.Create().Returns(new WordResponse());
            _userProfile.IsReader().Returns(true);
            _userProfile.IsContentCurator().Returns(false);

            //act
            var response = _systemUnderTest.Analyse(phrase);

            //arrange
            Assert.That(response, Is.Not.Null);
            _wordsFactory.Received(1).WithPretify(Arg.Any<char>());
        }

        [Test]
        public void should_no_pretify_wordresponse_when_a_reader_analyse()
        {
            //arrange
            var phrase = "phraseword1 phraseword2 phraseword3 test test";
            var worda = new Word() { Name = "phraseword1" };
            _wordsFactory.Create().Returns(new WordResponse());
            _userProfile.IsContentCurator().Returns(true);

            //act
            var response = _systemUnderTest.Analyse(phrase);

            //arrange
            Assert.That(response, Is.Not.Null);
            _wordsFactory.Received(0).WithPretify(Arg.Any<char>());
        }


    }
}
