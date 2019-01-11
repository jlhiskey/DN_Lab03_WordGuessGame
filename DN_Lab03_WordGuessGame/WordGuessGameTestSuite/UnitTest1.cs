using System;
using Xunit;
using DN_Lab03_WordGuessGame;

namespace WordGuessGameTestSuite
{
    public class FileAccess
    {
        [Fact]
        public void TestingThatAFileCanBeUpdated()
        {
            string _filePath = "../../../assets/wordList1.txt";
            string newWord = "bob";
            Program.CreateFile(_filePath, "test");
            Program.AppendToFile(_filePath, newWord);
            Array actual = Program.ReadFile(_filePath);
            Array expected = new string[] { "test bob" };
            Assert.Equal(expected, actual);
            Program.DeleteFile(_filePath);
        }
        [Fact]
        public void TestingThatAWordCanBeAdded()
        {
            string _filePath = "../../../assets/wordList2.txt";
            string newWord = "bob";
            Program.CreateFile(_filePath, "test");
            Assert.Equal("bob", Program.AddNewWord(_filePath, newWord));
            Program.DeleteFile(_filePath);
        }
        [Fact]
        public void TestingThatYouCanRetreiveAllWordsFromFile()
        {
            string _filePath = "../../../assets/wordList3.txt";
            string newWord = "bob";
            Program.CreateFile(_filePath, "test");
            Program.AddNewWord(_filePath, newWord);
            Array actual = Program.SplitWords(_filePath);
            Array expected = new string[] { "test", "bob" };
            Assert.Equal(expected, actual);
            Program.DeleteFile(_filePath);
        }
    }
    public class GameLogic
    {
        [Fact]
        public void TestingThatLetterIsFoundInWord()
        {
            string _filePath = "../../../assets/wordList4.txt";
            Program.CreateFile(_filePath, "test");
            char[] randomWord = Program.ParseStringToArray(Program.RandomWord(_filePath));
            char guess = 't';
            Assert.True(Program.GuessALetter(randomWord, guess));
            Program.DeleteFile(_filePath);
        }
        [Fact]
        public void TestingThatLetterIsNotFoundInWord()
        {
            string _filePath = "../../../assets/wordList5.txt";
            Program.CreateFile(_filePath, "test");
            char[] randomWord = Program.ParseStringToArray(Program.RandomWord(_filePath));
            char guess = 'z';
            Assert.False(Program.GuessALetter(randomWord, guess));
            Program.DeleteFile(_filePath);
        }
    }
}
