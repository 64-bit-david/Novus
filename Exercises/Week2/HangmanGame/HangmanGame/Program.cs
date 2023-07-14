using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string[] words = { "hello", "mister", "random", "hangman"};
            string filePath = @"Files/Words.txt";
            var reader = new FileReader(filePath);
            var words = reader.ReadFile();
            Hangman hangman = new Hangman(words);

            hangman.Start();

            Console.ReadLine();
        }
    }
}
