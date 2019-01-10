using System;
using System.IO;

namespace DN_Lab03_WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../assets/wordList.txt";
            string content = "hello";
            string newWord = "world";
            //CreateFile(filePath, content);
            //AppendToFile(filePath, newWord);
            //ReadFile(filePath);
            SplitWords(filePath);
            Console.ReadLine();
        }

        //Home Navigation

            //Modify Word List

                //View Words Link

                //Add Word Link

                //Remove Word Link

            //Start New Game

            //Exit Application

        //View Words in External File

            //ReadFile

            //Split Words into Array

            //Print Words

        //Add Word to External File

            //AppendToFile

        //Remove Word from External File

            //ReadFile

            //Split Words into Array

            //Find Word and remove from Array

            //CreateFile

        //Exit Game

            //Home Navigation Link

        //Start New Game

            //Select Random Word

            //Ask User to Input Char

            //Respond With Correct/Incorrect

            //Keep Track of Char Used

            //Tell Them They Won

        //Helper Methods-----------------------------------------------

        //CreateFile
        static void CreateFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    try
                    {
                        streamWriter.Write($"{content}");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write(e);
                throw;
            }
            catch (NotSupportedException e)
            {
                Console.Write(e);
                throw;
            }
            catch (AccessViolationException e)
            {
                Console.Write(e);
                throw;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        //ReadFile
        static string[] ReadFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                
                return lines;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
            
        }

        //AppendFile
        static void AppendToFile(string filePath, string newWord)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.Write($" {newWord}");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        //DeleteFile
        static void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);

            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        //SplitWords
        static string[] SplitWords(string filePath)
        {
            // Using space as my delimiter. Might add more if needed.
            char[] delimiterCharacters = { ' ' };
            try
            {
                string wordsFromFile = ParseReadFile(ReadFile(filePath));
                string[] words = wordsFromFile.Split(delimiterCharacters);

                return words;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
            
        }
        //Parsing ReadFile Input into strings
        static string ParseReadFile(string[] inputArray)
        {
            string parsedData = "";
            try
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    parsedData = parsedData + inputArray[i];
                }
                return parsedData;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
            
        }

    }
}
