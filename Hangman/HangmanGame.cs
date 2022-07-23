using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGame
    {
        public string wordToGuess;
        

        public HangmanGame(string word)
        {
            wordToGuess = word;
        }

        public void GuessCharacter()

        {
            int counter = 0;
            string s;
            string inputChar;
            char[] outputWord = new char[wordToGuess.Length];
            List<char> alreadyGuessed = new List<char>();

            for (int j = 0; j < wordToGuess.Length; j++)
            {
                outputWord[j] = '_';
            }

            for (int j = 0; j < 10; j++)
            {
                inputChar = Console.ReadLine();

                s = inputChar;
                s.ToCharArray();
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (s[0] == wordToGuess[i])
                    {
                        counter++;
                        outputWord[i] = s[0];
                        alreadyGuessed.Add(s[0]);
                    }
                    else if (!outputWord[i].Equals(wordToGuess[i]))
                    {
                        outputWord[i] = '_';
                    }
                    
                    
                }
                Console.WriteLine(outputWord);
                if (counter == wordToGuess.Length)
                {
                    Console.WriteLine("Congrats! You won!");
                }
            }
          
            
        }

        public void ShowUngessedWord()
        {
            char[] wordToShow = new char[wordToGuess.Length];
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                Console.Write("_" + " ");
            }
        }


    }
}
