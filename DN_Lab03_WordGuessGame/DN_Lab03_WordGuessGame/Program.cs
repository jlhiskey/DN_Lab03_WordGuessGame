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

            // Starts UI
            MainMenu(_filePath);
        }
        /// <summary>
        /// Provides the user an inital interface to access the word list, start a new game and exit the application.
        /// </summary>
        /// <param name="filePath"></param>
        static void MainMenu(string filePath)
        {
            Console.WriteLine("Select 0 to Exit Application\nSelect 1 To Access Word List\nSelect 2 Start New Game");
            Console.WriteLine();
            byte userInput = 0;

            try
            {
                userInput = byte.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect Format");
                MainMenu(filePath);
            }
            switch (userInput)
            {
                case 0:
                    Environment.Exit(1);
                    break;
                case 1:
                    WordListMenu(filePath);
                    break;
                case 2:
                    StartNewGame(filePath);
                    break;
                default:
                    MainMenu(filePath);
                    break;
            }
        }

        //Helper Methods-------------------------------------------------------------------------------

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

        /// <summary>
        /// Checks if file exists using the param "filePath". If the file is NOT found will create a file with starter words.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        /// <returns> true when sucessful</returns>
        static bool CheckForWordList(string filePath, string content)
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

        /// <summary>
        /// Allows the User to view and manipulate the list of words.
        /// </summary>
        /// <param name="filePath"></param>
        /// 
        static void WordListMenu(string filePath)
        {
            Console.WriteLine("Select 0 to Exit To Main Menu\nSelect 1 To Show Existing Words\nSelect 2 To Add New Words\nSelect 3 To Remove Words");
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
                    MainMenu(filePath);
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

        /// <summary>
        /// Shows the user how many words the person has stored in their wordList.text file. This is done by calling the SplitWords method. It receives an array of words that are in the wordList.txt file. It then prints each word onto the console. It returns an integer indicating how many words on the wordList.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns> Integer that indicates how many words are in wordList.txt</returns>
        static int UI_ShowExistingWords(string filePath)
        {
            try
            {
                string[] words = SplitWords(filePath);
                Console.WriteLine("Here are the words you currently have saved:");
                Console.WriteLine();
                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {words[i]}");
                    Console.WriteLine();
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

        /// <summary>
        /// Allows a user to input a new word. Using regex it validates that user's input word only contains characters between A-Z. Once validated it inputs the validated word into the AddNewWord method.
        /// </summary>
        /// <param name="filePath"></param>
        static void UI_AddNewWord(string filePath)
        {
            Console.WriteLine("What word would you like to add?");
            string inputWord;
            string verifiedWord;

            inputWord = (Console.ReadLine()).ToLower();
            if (Regex.IsMatch(inputWord, @"^[a-zA-Z]+$") == true)
            {
                verifiedWord = inputWord;
                AddNewWord(filePath, verifiedWord);
                Console.WriteLine();
                UI_ShowExistingWords(filePath);
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
        public static string AddNewWord(string filePath, string verifiedWord)
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

        /// <summary>
        /// Lists out all existing words found within wordList.txt using the param "filePath" predicated by a numerical value using the SplitWords method. It then askes user to select an integer that corresponds to the adjacent word. Once the input integer has been validated then that integer into the RemoveWord Method. 
        /// </summary>
        /// <param name="filePath"></param>
        static void UI_RemoveWord(string filePath)
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
            Console.WriteLine($"You selected {words[userResponse - 1]}. Are you sure you want to delete?");
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
            if (confirm == 1)
            {
                RemoveWord(filePath, userResponse - 1);
                UI_ShowExistingWords(filePath);
            }
            else
            {
                WordListMenu(filePath);
            }
        }

        /// <summary>
        /// Takes in param "userResponse" and removes the corresponding word from param "filePath" using the SplitWords, DeleteFile, CreateFile and AppendFile methods. It then calls the SplitWords method to recount words in the word list and returns how many words are left in the wordList.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="userResponse"></param>
        /// <returns>Returns an Integer representing how many words are remaining in the wordList</returns>
        public static int RemoveWord(string filePath, int userResponse)
        {
            try
            {
                string[] words = SplitWords(filePath);
                DeleteFile(filePath);
                string firstWord = "gregor";

                if (words.Length == 1)
                {
                    Console.WriteLine("You need to have at least one word to play the game. I added one for you ;)");
                    Console.WriteLine();
                }
                else
                {
                    firstWord = words[0];
                }
                int startingIndex = 1;
                if (userResponse == 0 && words.Length > 1)
                {
                    firstWord = words[1];
                    startingIndex = 2;
                }

                CreateFile(filePath, firstWord);
                if (startingIndex < words.Length)
                {
                    for (int i = startingIndex; i < words.Length; i++)
                    {
                        if (i != userResponse)
                        {
                            AppendToFile(filePath, words[i]);
                        }
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
        static string ParseReadFileToString(string[] inputArray)
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
                string wordsFromFile = ParseReadFileToString(ReadFile(filePath));
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

        /// <summary>
        /// Takes in a string from param "original string" and returns and array of characters.
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns>Returns char[]</returns>
        public static char[] ParseStringToArray(string originalString)
        {
            try
            {
                Char[] parsedStringArray = originalString.ToCharArray();
                return parsedStringArray;
            }
            catch (Exception e)
            {
                Console.Write(e);
                Console.Write("From StringToArrayParser()");
                throw;
            }
        }
        static int guessTracker = 0;
        /// <summary>
        /// Starts a new game and resets global variables.
        /// </summary>
        /// <param name="filePath"></param>
        static void StartNewGame(string filePath)
        {
            int correctLetters = 0;
            char[] alreadyGuessedLetters = new char[26];
            int confirm = 0;
            guessTracker = 0;
            Array.Clear(alreadyGuessedLetters, 0, 26);
            string randomWordString = RandomWord(filePath);
            char[] randomWord = ParseStringToArray(randomWordString);
            string[] gameArray = new string[randomWord.Length];
            correctLetters = 0;
            for (int i = 0; i < gameArray.Length; i++)
            {
                gameArray[i] = "_";
            }
            Console.WriteLine("New Game Beginning");
            Console.WriteLine("Good Luck");
            Console.WriteLine();
            while (correctLetters < randomWord.Length)
            {
                Console.WriteLine();
                for (int i = 0; i < gameArray.Length; i++)
                {
                    Console.Write($"{ gameArray[i]} ");
                }
                Console.WriteLine();
                Console.WriteLine();
                char guess = UI_GuessALetter(alreadyGuessedLetters);
                if (guess == 'E')
                {
                    guess = UI_GuessALetter(alreadyGuessedLetters);
                }
                bool isCorrect = GuessALetter(randomWord, guess);
                if ( isCorrect== true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{guess} was correct!");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"{guess} was incorrect.");
                }
                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (randomWord[i] == guess)
                    {
                        gameArray[i] = guess.ToString();
                        correctLetters = correctLetters + 1;
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine($"{randomWordString} is the word!");
            Console.WriteLine();
            Console.WriteLine($"You Won! It took you {guessTracker} guesses to figure it out.");
            Console.WriteLine();
            Console.WriteLine($"Would You Like To Play Again?");
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
            if (confirm == 1)
            {
                StartNewGame(filePath);
            }
            else
            {
                MainMenu(filePath);
            }
        }

        /// <summary>
        /// Asks user to input a letter and then checks to see if letter has already been guessed. If it hasnt been guessed then it is returned as a char.
        /// </summary>
        /// <returns>char</returns>
        public static char UI_GuessALetter(char[] alreadyGuessedLetters)
        {
            string inputLetter = null;
            char verifiedLetter = 'E';

            Console.WriteLine("Guess A Letter");
            Console.WriteLine();
            Console.WriteLine("Already Guessed Letters:");
            for (int i = 0; i < alreadyGuessedLetters.Length; i++)
            {
                Console.Write($"{alreadyGuessedLetters[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                inputLetter = (Console.ReadLine()).ToLower();

                if (inputLetter.Length == 1)
                {
                    if (Regex.IsMatch(inputLetter, @"^[a-zA-Z]+$") == true)
                    {
                        verifiedLetter = Char.Parse(inputLetter);
                        for (int i = 0; i < alreadyGuessedLetters.Length; i++)
                        {
                            if (verifiedLetter == alreadyGuessedLetters[i])
                            {
                                Console.WriteLine("Letter has already been guessed.");
                                break;
                            }
                        }
                        guessTracker = guessTracker + 1;
                        alreadyGuessedLetters[verifiedLetter - 97] = verifiedLetter;
                        return verifiedLetter;
                    }
                    else
                    {
                        Console.WriteLine("Please only use letters without spaces");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Don't cheat! Only input one letter");
                }                             
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only use letters without spaces");
                throw;
            }
            return verifiedLetter;  
        } 

        /// <summary>
        /// When user inputs character will return true if character found in randomWord.
        /// </summary>
        /// <param name="randomWord"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static bool GuessALetter(char[] randomWord, char guess)
        {   
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (randomWord[i] == guess)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
