using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackApp
{
    public class ProcessInput
    {
        public int ChangeWinningHorse { get; set; }
        public string firstParam { get; set; }
        public string secondParam { get; set; }

        /// <summary>
        /// This Function will parse the input and seperated out the parameters
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public string ParseInput(string Input)
        {
            
            string[] inputs = Input.Split(' ');
            firstParam = inputs[0];
            
            int betAmount = 0;
            bool isValidBet = false;

            int no;

            if (inputs.Length > 2)
            {
                Console.WriteLine("Invalid Input");
                return "Invalid";
            }
            else if (inputs.Length > 1)
            {
                secondParam = inputs[1];
            }

            // Checking input is correct or not
            if (int.TryParse(firstParam, out no))
            {
                int inputno = int.Parse(firstParam.ToString());
                //Cheking horse no is valid or not
                if (inputno > 7 || inputno < 1)
                {
                    Console.WriteLine("Invalid Horse Number:" + inputno);
                    return "Invalid";
                }
                else
                {
                    isValidBet = double.Parse(secondParam) % 1 == 0;
                    if (isValidBet)
                    {
                        betAmount = int.Parse(secondParam);
                        return "WinAmount";
                    }
                    else
                    {
                        Console.WriteLine("Invalid Bet Amount:" + secondParam);
                        return "Invalid";
                    }
                }
            }
            else
            {
                if (firstParam.ToString().ToUpper() == "R")
                    return "Restock";
                else if (firstParam.ToString().ToUpper() == "Q")
                    return "Quit";
                else if (firstParam.ToString().ToUpper() == "W")
                {
                    ChangeWinningHorse = int.Parse(secondParam);
                    return "ChangeWinner";
                }
                else
                    return "Invalid";

            }            
        }
    }
}
