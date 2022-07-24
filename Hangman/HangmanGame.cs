﻿using System;
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
            while (CheckIfWeHaveMissingCharacters())
            {
                var newChar = ReadNewCharacter();
                if (CanWeUseThisLetter(newChar))
                {
                    if (HasUserUsedTheSameCharacter(newChar))
                    {
                        Console.WriteLine();
                        Console.WriteLine("You already used this character");
                    }
                    else
                    {
                        AddNewCharacterToUnderscoreArray(newChar);
                    }
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
        private bool CheckIfWeHaveMissingCharacters()
        {
            var areThereMissingCharacter = undescoreArray.Contains('_');
            return areThereMissingCharacter;
        }
        private bool CanWeUseThisLetter(char newChar)
        {
            bool isNewCharacterContainedInGuessedWord = wordArray.Contains(newChar);
            return isNewCharacterContainedInGuessedWord;
        }
        private bool HasUserUsedTheSameCharacter(char newChar)
        {
            bool haveWeAlreadyUsedThisCharacter = undescoreArray.Contains(newChar);
            return haveWeAlreadyUsedThisCharacter;
        }
        private char ReadNewCharacter()
        {
            Console.Write("Enter a character: ");
            var myCharacter = Console.ReadKey().KeyChar;
            while (true)
            {
                if (char.IsLetter(myCharacter))
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Invalid input! Enter a different character: ");
                    myCharacter = Console.ReadKey().KeyChar;
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
