using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGame
    {
        /// <summary>
        /// this is the word we need to find, but splitted in an array
        /// </summary>
        private char[] wordArray;

        /// <summary>
        /// this is an array of underscores which will contained the correct guesses of the player
        /// </summary>
        private char[] undescoreArray;

        private bool IsGuessedWordIncomplete => undescoreArray.Contains('_');

        public HangmanGame(string word)
        {
            wordArray = word.ToCharArray();
            undescoreArray = new char[wordArray.Length];   
            for(int i = 0; i < undescoreArray.Length; i++)
            {
                undescoreArray[i] = '_';
            }
        }

        public void RunGame()
        {
            Console.WriteLine("Welcome! This is the word:");
            PrintUnderscoreArray();
            Console.WriteLine("Guess the character:");
            while (IsGuessedWordIncomplete)
            {
                var newChar = ReadNewCharacter();
                if (CanWeUseThisLetter(newChar))
                {
                    AddNewCharacterToUnderscoreArray(newChar);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Character not in word! Try again!");
                }
                PrintUnderscoreArray();
            }
            Console.WriteLine("Congrats! You won!");
        }

        private void AddNewCharacterToUnderscoreArray(char newChar)
        {
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i] == newChar)
                {
                    undescoreArray[i] = newChar;
                }
            }
        }
        private bool CanWeUseThisLetter(char newChar)
        {
            return wordArray.Contains(newChar);
        }
        private bool HasUserUsedTheSameCharacter(char newChar)
        {
            bool haveWeAlreadyUsedThisCharacter = undescoreArray.Contains(newChar);
            return haveWeAlreadyUsedThisCharacter;
        }
        private char ReadNewCharacter()
        {
            Console.Write("Enter a character: ");
            char myCharacter;
            while (true)
            {
                myCharacter = Console.ReadKey().KeyChar;
                if (char.IsLetter(myCharacter))
                {
                    if (HasUserUsedTheSameCharacter(myCharacter))
                    {
                        Console.WriteLine();
                        Console.WriteLine("You already used this character");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Invalid input! Enter a different character: ");
                }
            }
            return myCharacter;
        }
        private void PrintUnderscoreArray()
        {
            Console.WriteLine();
            foreach(var ch in undescoreArray)
            {
                Console.Write(ch);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}
