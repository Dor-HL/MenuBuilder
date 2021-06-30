using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class SpaceCounter : IMenuAction
    {
        public void OnChosenItem()
        {
            int spacesCounter = 0;
            Console.WriteLine("Please enter your sentence");
            string userInput = Console.ReadLine();

            foreach(char currentChar in userInput)
            {
                if(currentChar == ' ')
                {
                    spacesCounter++;
                }
            }

            string result = string.Format("The number of spaces in your sentence is {0}", spacesCounter);
            Console.WriteLine(result);
        }
    }
}
