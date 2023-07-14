using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HangmanGame.Tests
{
    [TestFixture]
    public class HangmanTests
    {

        //helper method to create hangman obj
        public Hangman GenerateHangman()
        {
            string[] words = { "hello", "goodbye", "today" };
            Hangman hangman = new Hangman(words);

            return hangman;
        }


        [Test]
        public void SelectWord_ReturnsValidWord()
        {

            //Arrange
            var hangman = GenerateHangman();


            //Act
            string word = hangman.SelectWord(); 

            //Assert
            Assert.Contains(word, hangman.Words);

        }

        [Test]
        public void PopulateLetterPositionsDictionary_PopulatesCorrectly()
        {
            var hangman = GenerateHangman();
            hangman.TargetWord = "hello";
            

            // Act
            hangman.PopulateLetterPositionsDictionary();
            var letterPositions = hangman.LetterPositions;


            //Assert
            Assert.That(letterPositions.ContainsKey('h'), Is.True);
            Assert.That(letterPositions['h'], Is.EquivalentTo(new List<int> { 0 }));

            Assert.That(letterPositions.ContainsKey('l'), Is.True);
            Assert.That(letterPositions['l'], Is.EquivalentTo(new List<int> { 2, 3 }));

        }

        [Test]
        public void GetWordStatus_ReturnsCorrectStatus()
        {
            //Arrange
            var hangman = GenerateHangman();

            hangman.TargetWord = "hello";
            hangman.CorrectUserGuesses = new List<char> { 'h', 'l' };

            hangman.LetterPositions = new Dictionary<char, List<int>>()
            {
                { 'h', new List<int> { 0 } },
                { 'l', new List<int> { 2, 3 } }
            };


            //Act
            string actual = hangman.GetWordStatus();
            string expected = "h*ll*";

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        
        
        }
    }
}
