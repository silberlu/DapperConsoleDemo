using System;
using System.Threading;

namespace DapperConsoleDemo.UI
{
    public static class ReadDigit
    {
        public static int Check(string menuText, string errorText, int menuOptions, int delay, int positionLeft, int positionTop)
        {
            int userInput = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Clear();
                Console.Write(menuText);
                if (!int.TryParse(Console.ReadLine(), out int output) || output > menuOptions || output < 0)
                {
                    DisplayErrorMessage(errorText, delay, positionLeft, positionTop);
                }
                else
                {
                    validInput = true;
                    userInput = output;
                }
            }
            return userInput;
        }

        private static void DisplayErrorMessage(string errorText, int delay, int positionLeft, int positionTop)
        {
            Console.SetCursorPosition(positionLeft, positionTop);
            Console.Write(errorText);
            Thread.Sleep(delay);
            Console.Clear();
        }
    }
}
