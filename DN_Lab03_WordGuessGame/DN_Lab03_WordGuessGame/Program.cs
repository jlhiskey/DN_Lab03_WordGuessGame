using System;
using System.IO;

namespace DN_Lab03_WordGuessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "../../../assets/wordList.txt";
            string initialContent = "josie cat";
            

            // Initalized wordList file when application is loaded.
            CheckForWordList(filePath, initialContent);

            //Testing Area
            UI_ShowExistingWords(filePath);

            
            Console.ReadLine();
        }

        //Home Navigation

            //Word List

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

        // File Methods------------------------------------------------

        //CreateFile
        public static void CreateFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    try
                    {
                        streamWriter.Write($"{content}");
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                        Console.Write("From CreateFile");
                        throw;
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write(e);
                Console.Write("From CreateFile");
                throw;
            }
            catch (NotSupportedException e)
            {
                Console.Write(e);
                Console.Write("From CreateFile");
                throw;
            }
            catch (AccessViolationException e)
            {
                Console.Write(e);
                Console.Write("From CreateFile");
                throw;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From CreateFile");
                throw;
            }
        }

        //ReadFile
        public static string[] ReadFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                
                return lines;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From ReadFile");
                throw;
            }
            
        }
        
        //AppendFile
        public static void AppendToFile(string filePath, string newWord)
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
                Console.Write("From AppendToFile");
                throw;
            }
        }

        //DeleteFile
        public static void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);

            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From DeleteFile()");
                throw;
            }
        }

        //Modify Word List Methods---------------------------------------------

        //Create New wordList if File Doesn't Exist
        public static bool CheckForWordList(string filePath, string content)
        {
            try
            {   
                if (!File.Exists(filePath))
                {
                    CreateFile(filePath, content);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From CheckForWordList()");
                throw;
            }
        }

        //Show Existing Words
        public static int UI_ShowExistingWords(string filePath)
        {
            try
            {
                string[] words = SplitWords(filePath);
                Console.WriteLine("Here are the words you currently have saved:");
                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine(words[i]);
                }
                return words.Length;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From UI_ShowExistingWords()");
                throw;
            }
            
        }

        //Add New Words to List

        //Remove Words from List


        //Game Methods---------------------------------------------------------

        //Parses ReadFile Output into strings
        private static string ParseReadFile(string[] inputArray)
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
                Console.Write("From ParsedReadFile");
                throw;
            }

        }

        //SplitWords
        public static string[] SplitWords(string filePath)
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
                Console.Write("From SplitWords()");
                throw;
            }
            
        }
        //Select a Random Word frow SplitWords Output
        public static string RandomWord(string filePath)
        {
            try
            {
                Random rand = new Random();
                string[] words = SplitWords(filePath);
                string randomWord = words[rand.Next(words.Length)];
                return randomWord;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From RandomWord()");
                throw;
            }
        }
        
    }
}
