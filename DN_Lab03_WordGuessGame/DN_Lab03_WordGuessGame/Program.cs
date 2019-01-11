using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DN_Lab03_WordGuessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string _filePath = "../../../assets/wordList.txt";
            string _initialContent = "josie cat";
            

            // Initalizes wordList file when application is loaded.
            CheckForWordList(_filePath, _initialContent);

            //Testing Area
            WordListMenu(_filePath);


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

        /// <summary>
        /// Creates a text file using the params "filePath" which designates where the file will be stored and the param "content" which will add text to that file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
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

        /// <summary>
        /// Retreives a file using the param "filePath" and returns a string[] with each line of the text document.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns> string[] lines </returns>
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

        /// <summary>
        /// Retreives a file using the param "filePath" and adds a string to the existing file using the param "newWord" Note: The new string will be added to the existing document with a 1 space of seperation from the end of the existing document. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="newWord"></param>
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
        /// <summary>
        /// Deletes a file using the param "filePath".
        /// </summary>
        /// <param name="filePath"></param>
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

        //Create New wordList if File Doesn't Exist
        /// <summary>
        /// Checks if file exists using the param "filePath". If the file is NOT
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        /// <returns> true when sucessful</returns>
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

        //Modify Word List Methods---------------------------------------------

        //TODO: Modify Word List Menu
        static void WordListMenu(string filePath)
        {
            Console.WriteLine("Select 0 to Exit\nSelect 1 To Show Existing Words\nSelect 2 To Add New Words\nSelect 3 To Remove Words");
            Console.WriteLine();
            byte userInput = 0;

            try
            {
                userInput = byte.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect Format");
                WordListMenu(filePath);
            }
            switch (userInput)
            {
                case 0:
                    //MainMenu();
                    break;
                case 1:
                    UI_ShowExistingWords(filePath);
                    Console.WriteLine();
                    WordListMenu(filePath);
                    break;
                case 2:
                    UI_AddNewWord(filePath);
                    Console.WriteLine();
                    WordListMenu(filePath);
                    break;
                case 3:
                    UI_RemoveWord(filePath);
                    Console.WriteLine();
                    WordListMenu(filePath);
                    break;
                default:
                    WordListMenu(filePath);
                    break;
            }
        }
        //Show Existing Words

        /// <summary>
        /// Shows the user how many words the person has stored in their wordList.text file. This is done by calling the SplitWords method. It receives an array of words that are in the wordList.txt file. It then prints each word onto the console. It returns an integer indicating how many words on the wordList.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns> Integer that indicates how many words are in wordList.txt</returns>
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

        /// <summary>
        /// Allows a user to input a new word. Using regex it validates that user's input word only contains characters between A-Z. Once validated it inputs the validated word into the AddNewWord method.
        /// </summary>
        /// <param name="filePath"></param>
        public static void UI_AddNewWord(string filePath)
        {
            Console.WriteLine("What word would you like to add?");
            string inputWord;
            string verifiedWord;

            inputWord = (Console.ReadLine()).ToLower();
            if (Regex.IsMatch(inputWord, @"^[a-zA-Z]+$") == true)
            {
                verifiedWord = inputWord;
                AddNewWord(filePath, verifiedWord);
            }
            else
            {
                Console.WriteLine("Please only use letters without spaces");
                UI_AddNewWord(filePath);
                verifiedWord = null;
            }
        }
        
        /// <summary>
        /// Adds new string to file using the param "filePath" for file location and the param "verifiedWord" for the new string. It then uses the SplitWords method to retreive all of the words from the filePath and returns the last word added to the wordList. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="verifiedWord"></param>
        /// <returns>Word that was added to the wordList.txt file</returns>
        public static string AddNewWord(string filePath, string verifiedWord )
        {
            try
            {
                AppendToFile(filePath, verifiedWord);
                string[] words = SplitWords(filePath);
                return words[words.Length - 1];
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From AddNewWord()");
                throw;
            }
        }

        //Remove Words from List
        
        /// <summary>
        /// Lists out all existing words found within wordList.txt using the param "filePath" predicated by a numerical value using the SplitWords method. It then askes user to select an integer that corresponds to the adjacent word. Once the input integer has been validated then that integer into the RemoveWord Method. 
        /// </summary>
        /// <param name="filePath"></param>
        public static void UI_RemoveWord(string filePath)
        {
            string[] words = SplitWords(filePath);
            int userResponse;
            int confirm;

            Console.WriteLine("Please enter # of word you would like to remove:");
            Console.WriteLine();
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {words[i]}");
                Console.WriteLine();
            }
            try
            {
                userResponse = int.Parse(Console.ReadLine());
                if (userResponse > words.Length)
                {
                    Console.WriteLine($"Please enter Integer between 1 and {words.Length}");
                    userResponse = int.Parse(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Please enter Integer between 1 and {words.Length}");
                userResponse = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine($"You selected {words[userResponse -1]}. Are you sure you want to delete?");
            Console.WriteLine("Press 1 for YES");
            Console.WriteLine("Press 2 for NO");
            try
            {
                confirm = int.Parse(Console.ReadLine());
                if (confirm > 2 || confirm < 1)
                {
                    Console.WriteLine($"Please enter Integer.");
                    Console.WriteLine("Press 1 for YES");
                    Console.WriteLine("Press 2 for NO");
                    confirm = int.Parse(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter Integer.");
                Console.WriteLine("Press 1 for YES");
                Console.WriteLine("Press 2 for NO");
                confirm = int.Parse(Console.ReadLine());
            }
            RemoveWord(filePath, userResponse - 1);
            UI_ShowExistingWords(filePath);
        }
        // Take number and feed it to a delete function.
        public static int RemoveWord(string filePath, int userResponse)
        {
            try
            {
                string[] words = SplitWords(filePath);
                DeleteFile(filePath);
                CreateFile(filePath, "");
                for (int i = 0; i < words.Length; i++)
                {
                    if (i != userResponse)
                    {
                        AppendToFile(filePath, words[i]);
                    }

                }

                words = SplitWords(filePath);
                return words.Length;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From RemoveWord()");
                throw;
            }
            
        }

        // General Use Methods-------------------------------------------------

        /// <summary>
        /// Receives an string[] and returns a concatenated string from input array.
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns> A concatenated string from input string[].</returns>
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
                
        /// <summary>
        /// Using the param "filePath" calls ParseReadfile(Readfile(filePath)) which will retreive data from the wordList.txt file then will parse it into a single string and then delimit them using ' ' and will store them into as seperate words in a string[] and will return the populated string[]. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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

        //Game Methods---------------------------------------------------------

        //Select a Random Word frow SplitWords Output
        /// <summary>
        /// Using the param "filePath" this method calls the SplitWords method which returns an string[] of stored words. It will then select a random word from the array of words and will return that word.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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
