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
            CreateFile(filePath, content);
            AppendToFile(filePath, newWord);
            ReadFile(filePath);
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
        static void ReadFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
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

        //SplitWords

    }
}
