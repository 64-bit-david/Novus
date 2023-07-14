using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HangmanGame
{

    /*
     A class representing the hangman game
     */
    public class Hangman
    {

        //requires an array of words on instansiation 
        public Hangman(string[] words)
        {
            Words = words;
            Turns = 7;
            CorrectUserGuesses = new List<char>();
            LetterPositions = new Dictionary<char, List<int>>();
        }

        public static readonly string[] HangmanImages =
 {
            @" 
              +---+
                  |
                  |
                  |
                  |
                  |
                ========",

            @" 
              +---+
              |   |
                  |
                  |
                  |
                  |
                ========",

            @" 
              +---+
              |   |
              O   |
                  |
                  |
                  |
                ========",

            @" 
              +---+
              |   |
              O   |
              |   |
                  |
                  |
                ========",

            @" 
              +---+
              |   |
              O   |
             /|   |
                  |
                  |
                ========",

            @" 
              +---+
              |   |
              O   |
             /|\  |
                  |
                  |
                ========",

            @" 
              +---+
              |   |
              O   |
             /|\  |
             /    |
                  |
                ========",

            @" 
              +---+
              |   |
              O   |
             /|\  |
             / \  |
                  |
                ========"
        };
        public string[] Words;
        public string TargetWord;

        //Holds the letters of a word that the user has guessed
        public List<char> CorrectUserGuesses { get; set; }

        public int Turns { get; internal set; }
       
        //keys represent the unqique letters of a word
        //values represent all the positions within the word of where the letter occur
        public Dictionary<char, List<int>> LetterPositions { get; set; }




        /// <summary>
        /// Randomly selects a word from the word Array.
        /// </summary>
        /// <returns>A word as a string.</returns>
        public string SelectWord()
        {
            Random random = new Random();
            int index = random.Next(0, Words.Length);
            return Words[index].ToLower();
        }



        /// <summary>
        ///   Populates the LetterPositions Dictionary when the game starts 
        ///   with the targetWord is selected once it is selected
        /// </summary>  
        public void PopulateLetterPositionsDictionary()
        {
            for (int i = 0; i < TargetWord.Length; i++)
            {
                if (LetterPositions.ContainsKey(TargetWord[i]))
                {
                    LetterPositions[TargetWord[i]].Add(i);
                }
                else
                {
                    LetterPositions[TargetWord[i]] = new List<int> { i };
                }
            }
        }

        /// <summary>
        /// Returns an image of the hangman based on how many Turns are left
        /// </summary>
        /// <returns>A string representation of the hangman</returns>
        public string PrintHangman()
        {
            return HangmanImages[HangmanImages.Length - Turns];
        }


        /// <summary>
        /// Returns the word with the guesses letters displays
        /// </summary>
        /// <returns>A string that represents the word with guessed letters visible</returns>
        public string GetWordStatus()
        {
            char[] outputArr = new char[TargetWord.Length];

            for(int i = 0; i< TargetWord.Length; i++ )
            {
                outputArr[i] = '*';
            }
            
            foreach(char c in  CorrectUserGuesses)
            {
                foreach(int i in LetterPositions[c])
                {
                    outputArr[i] = c;
                }
            }

            string outputString = String.Join("", outputArr);
            return outputString;
        }




        /// <summary>
        ///   Starts the Game 
        /// </summary>

        public void Start()
        {
            

            TargetWord = SelectWord();
            PopulateLetterPositionsDictionary();


            
            Console.WriteLine("Playing Hangman in Test Mode");
            Console.WriteLine($"You aim is to guess the random hidden word in {Turns} turns.");
      
            

            while (Turns > 0)
            {

                //Provides the user info on the current status of the game
                Console.WriteLine(PrintHangman());
                string currentWordStatus = GetWordStatus();
                Console.WriteLine("---------------------");
                Console.WriteLine($"Word to guess: {currentWordStatus}");
                Console.WriteLine($"You have {Turns} turns remaining");


                Console.Write("Guess a letter: ");
                char letter = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if(!Char.IsLetter(letter))
                {
                    Console.WriteLine("Please enter a valid letter.");
                    continue;
                }

                //prompt to try again if input invalid
                if (CorrectUserGuesses.Contains(letter))
                {
                    Console.WriteLine($"You have already correctly guessed the letter {letter}!");
                    continue;
                }

                //Correct guess
                else if (LetterPositions.ContainsKey(letter))
                {
                    CorrectUserGuesses.Add(letter);
                    Console.WriteLine($"The letter {letter} is correct!");
                    string updatedDisplayWord = GetWordStatus();
                    
                    //end the game when all letters guessed
                    if (updatedDisplayWord == TargetWord)
                    {
                        Console.WriteLine($"{updatedDisplayWord}");
                        Console.WriteLine($"Congratulations! You won the game with {Turns} turns remaining");
                        break;
                    }
                    Turns--;
                }
                //Incorrect Guess
                else
                {
                    Console.WriteLine($"The letter {letter} is not correct. Please try again");
                    Turns--;
                }
            }

            //End the game when the user runs out of turns
            Console.WriteLine("You ran out of turns! Game Over");
            Console.WriteLine($"The correct word was {TargetWord}");
            Console.ReadLine();
        }    
    
    }
}
