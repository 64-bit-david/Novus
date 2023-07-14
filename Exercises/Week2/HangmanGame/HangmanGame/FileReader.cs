using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class FileReader
    {
        private string filePath;

        public FileReader(string path)
        {
            filePath = path;
        }

        public string[] ReadFile()
        {
            string contents = "";
            try
            {
                string filename = Path.GetFileName(filePath);
                using (var sr = new StreamReader(filePath))
                {
                    // Read the stream as a string, and write the string to the console.
                    contents = sr.ReadToEnd();
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("The file could not be read.");
                Console.WriteLine(e.Message);
            }

            //Store each word into an array using split on '\n'

            string[] array = contents.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);

            return array;

        }
    }
}
