using System;
using ContentConsole.Words;
using FluentAssertions;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{

    [TestFixture]
    public class WordsFactoryTest
    {
        private WordsFactory _systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            _systemUnderTest = new WordsFactory();
        }


        [Test]
        public void should_init_wordsresponse_with_phrase()
        {
            
            //arrange
            var phrase = "test phrase";

            //act
            var response=_systemUnderTest.Init(phrase).Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.Phrase.ShouldBeEquivalentTo(phrase);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void should_throw_argumentnullexception_when_init_with_null_phrase()
        {
            //act
            var response = _systemUnderTest.Init(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void should_throw_argumentnullexception_when_add_word_is_null()
        {
            //act
            var response = _systemUnderTest.WithWordFound(null);
        }


        [Test]
        public void should_add_word_to_wordsresponse()
        {

            //arrange
            var phrase = "test phrase";
            var word = "word";

            //act
            var response = _systemUnderTest.Init(phrase).WithWordFound(word).Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.Phrase.ShouldBeEquivalentTo(phrase);
            response.WordsFound.ShouldBeEquivalentTo(1);
        }

        [Test]
        public void should_add_words_to_wordsresponse()
        {

            //arrange
            var phrase = "test phrase";
            var worda = "word";
            var wordb = "word";

            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithWordFound(wordb).Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.Phrase.ShouldBeEquivalentTo(phrase);
            response.WordsFound.ShouldBeEquivalentTo(2);
        }

        [Test]
        public void should_pretify_one_word_to_wordsresponse()
        {
            //arrange
            var phrase = "test phrase";
            var worda = "test";
            
            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithPretify('#').Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.WordsFound.ShouldBeEquivalentTo(1);
            response.Phrase.ShouldBeEquivalentTo("t##t phrase");
        }

        [Test]
        public void should_pretify_repited_word_to_wordsresponse()
        {
            //arrange
            var phrase = "test test phrase";
            var worda = "test";

            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithPretify('#').Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.WordsFound.ShouldBeEquivalentTo(1);
            response.Phrase.ShouldBeEquivalentTo("t##t t##t phrase");
        }


        [Test]
        public void should_pretify_different_words_to_wordsresponse()
        {
            //arrange
            var phrase = "test other phrase";
            var worda = "test";
            var wordb = "other";

            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithWordFound(wordb)
                .WithPretify('#').Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.WordsFound.ShouldBeEquivalentTo(2);
            response.Phrase.ShouldBeEquivalentTo("t##t o###r phrase");
        }


        [Test]
        public void should_pretify_one_word_three_characters_to_wordsresponse()
        {
            //arrange
            var phrase = "tet phrase";
            var worda = "tet";

            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithPretify('#').Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.WordsFound.ShouldBeEquivalentTo(1);
            response.Phrase.ShouldBeEquivalentTo("t#t phrase");
        }

        [Test]
        public void should_ignore_pretify_one_word_with_just_two_characters_to_wordsresponse()
        {
            //arrange
            var phrase = "tt phrase";
            var worda = "tt";

            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithPretify('#').Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.WordsFound.ShouldBeEquivalentTo(1);
            response.Phrase.ShouldBeEquivalentTo("tt phrase");
        }

        [Test]
        public void should_ignore_pretify_one_word_with_just_one_character_to_wordsresponse()
        {
            //arrange
            var phrase = "t phrase";
            var worda = "t";

            //act
            var response = _systemUnderTest.Init(phrase)
                .WithWordFound(worda)
                .WithPretify('#').Create();

            //assert
            Assert.That(response, Is.Not.Null);
            response.WordsFound.ShouldBeEquivalentTo(1);
            response.Phrase.ShouldBeEquivalentTo("t phrase");
        }

    }
}
