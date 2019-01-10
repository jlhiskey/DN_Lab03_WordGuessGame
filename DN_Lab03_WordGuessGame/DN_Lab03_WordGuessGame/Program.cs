using System;
using System.IO;

namespace DN_Lab03_WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../assets/wordList.txt";
            CreateFile(filePath);
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
        static void CreateFile(string filePath)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    try
                    {
                        streamWriter.WriteLine("hello world");
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


        //AppendFile

        //DeleteFile

        //SplitWords

    }
}
