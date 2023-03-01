using HorseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackApp.Controller
{
    public class HorseController
    {
        public List<Horse> Horses { get; set; }
        public HorseController()
        {
            Horses = new List<Horse>()
            {
                 new Horse() { HorseNo = 1, HorseName = "That Darn Gray Cat", Odds = 5, Result = "Won" },
                 new Horse() { HorseNo = 2, HorseName = "Fort Utopia", Odds = 10, Result = "Lost" },
                 new Horse() { HorseNo = 3, HorseName = "Count Sheep", Odds = 9, Result = "Lost" },
                 new Horse() { HorseNo = 4, HorseName = "Ms Traitour ", Odds = 4, Result = "Lost" },
                 new Horse() { HorseNo = 5, HorseName = "Real Princess ", Odds = 3, Result = "Lost" },
                 new Horse() { HorseNo = 6, HorseName = "Pa Kettle ", Odds = 5, Result = "Lost" },
                 new Horse() { HorseNo = 7, HorseName = "Gin Stinger ", Odds = 6, Result = "Lost" }
            };
        }

        /// <summary>
        /// This Function will change the winningHorse as per the input provided
        /// </summary>
        /// <param name="_horses"></param>
        /// <param name="ChangeWinningHorse"></param>
        public bool UpdateWinningHorse(int ChangeWinningHorse)
        {
            try
            {
                if (ChangeWinningHorse < 1 || ChangeWinningHorse > 7)
                {
                    Console.WriteLine("Invalid Horse Number :");
                    return false;
                }
                else
                {
                    Console.WriteLine("Changing the winning Horse :");
                    Horse oldWinner = this.Horses.FirstOrDefault(x => x.Result == "Won");
                    if (oldWinner != null)
                        this.Horses[oldWinner.HorseNo - 1].Result = "Lost";
                    this.Horses[ChangeWinningHorse - 1].Result = "Won";
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred:" + ex.Message);
                return false;
            }
        }
    }
}
