
# Lab 03: Word Guess Game
 - Josie Cat has requested that a “Word Guess Game” be built. The main idea of the game is she must guess what a mystery word is by inputting (1) letter at a time. The game should save all of her guesses (both correct and incorrect) throughout each session of the game, along with the ability to show her how many letters out of the word she has guessed correctly.

 - Each time a new game session starts, the mystery word chosen should come from an external text file that randomly selects one of the words listed. This bank of words should be editable by Josie so that she may view, add, and delete words as she wishes. She expects the game to have a simple user interface that is easy to navigate.

 - Using everything you’ve learned up to this point, create a word guess game that will meet all of the requirements described in the user story above.
 
## Specs
- The program (should) contain the following
    - Methods for each action (suggestions: Home navigation, View words in the external file, add a word to the external file, Remove words from a text file, exit the game, start a new game)
    - When playing a game, randomly select one of the words to output to the console for the user to guess (Use the Random class)
    - You should have a record of the letters they have attempted so far
    - If they guess a correct letter, display that letter in the console for them to refer back to when making guesses (i.e. C _ T S )
    - Your program does not need to be case sensitive.
    - Errors should be handled through Exception handling
    - Do not create external classes to accomplish this task. All code should live in the Program.cs file
    - Stay within scope, you may use the methods/classes listed below if desired.
    - Once the game is completed, the user should be presented with the option to “Play again” (a new random word is generated), or “Exit” (the program terminates)
    - The user should only be allowed to guess only 1 letter at a time. Do not make it so that they can input the whole alphabet and get the answer.
- When running your application, it should activate the user interface without any direct code manipulation

## Unit Tests
- Test that your app has the following functionality:
    - Test that a file can be updated
    - Test that a word can be added to a file
    - Test that you can retrieve all words from the file
    - Test that the word chosen can accurately detect if the letter exists in the word (test that a letter does exist and does not exist)
## Example Usage
- When you run app.
    - Welcome to Word Guess Game:
    - Main Menu
      - Select 0 to Exit Application
        - Exits Application
      - Select 1 To Access Word List Menu
        - Access Word 1List
          - Select 0 to Exit To Main Menu
            - Returns to Main Menu
          - Select 1 To Show Existing Words
            - Displays a list of saved words.
            - Returns to Access Word List Menu
          - Select 2 To Add New Word
            - Asks for user input (STRING A-Z) of new word.
            - Displays a list of saved words.
            - Returns to Access Word List Menu
          - Select 3 To Remove Word
            - Displays a list of saved words.
            - Asks for user input (INTEGER) of which word they want to delete.
              - Displays selected word and asks if you are sure you want to delete.
                - Select 1 for Yes
                  -  Displays a list of saved words.
                  - Returns to Access Word List Menu
                - Select 2 for No
                  -  - Returns to Access Word List Menu
      - Select 2 to Start New Game
        - New Game
          - Displays _ _ _ equal to how many letters there are in random word chosen from Word List.
          - Displays already guessed letters arranged alphabetically.
          - Asks for user input (SINGLE CHARACTER) to guess a letter.
            - If Correct
              - Displays (selected letter) was correct!
              - Displays _ _ _ equal to how many letters there are in random word chosen from Word List.
              - Displays already guessed letters arranged alphabetically.
              - Asks for user input (SINGLE CHARACTER) to guess a letter.
            - If Incorrect
              - Displays (selected letter) was incorrect.
              - Displays _ _ _ equal to how many letters there are in random word chosen from Word List.
              - Displays already guessed letters arranged alphabetically.
              - Asks for user input (SINGLE CHARACTER) to guess a letter. 
          - Winning the Game
            - Once all correct characters have been guessed you win!
              - Displays (correct word) is the word!
              - Displays You Won! It took you (number of guesses) guesses to figure it out.
              - Displays Would You Like To Play Again?
                - Select 1 for Yes
                  -  Start New Game with new random word.
                - Select 2 for No
                  -  Returns to Main Menu

    ## Screenshots of Usage
    ### Gameplay
    ![solution image](Solution1.PNG)

    ### Word List
    ![solution image](Solution2.PNG)
