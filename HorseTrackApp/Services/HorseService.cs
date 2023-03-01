using HorseTrackApp.Controller;
using HorseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackApp.Services
{
    public  class HorseService
    {

        /// <summary>
        /// Function to display the horses 
        /// </summary>
        /// <param name="_horses"></param>
        public void ShowHorses(List<Horse> _horses)
        {
            Console.WriteLine("Horses:");
            foreach (Horse item in _horses)
            {
                Console.WriteLine(item.HorseNo + "," + item.HorseName + "," + item.Odds + "," + item.Result);
            }
        }

        /// <summary>
        /// Function to show the inventory
        /// </summary>
        /// <param name="_inventories"></param>
        public void ShowInventory(List<Inventory> _inventories)
        {
            Console.WriteLine("Inventory:");
            foreach (Inventory item in _inventories)
            {
                Console.WriteLine("$" + item.Notes + "," + item.NotesCounter);
            }
        }

        /// <summary>
        /// This Function will restock the inventory
        /// </summary>
        /// <param name="_inventories"></param>
        public void ReStockInventory(List<Inventory> _inventories)
        {
            Console.WriteLine("Restocking the Inventory");
            foreach (Inventory item in _inventories)
            {
                item.NotesCounter = 10;
            }   

        }


        /// <summary>
        /// This function will do the following things.
        /// 1. Calculate the winning amount and show the payout.
        /// 2. Show the dispensing the currency notes with there denomintaions.
        /// 3. Update the inventory after dispensing the payout.
        /// </summary>
        /// <param name="_inventories"></param>
        /// <param name="_horses"></param>
        /// <param name="betAmount"></param>
        /// <param name="firstParam"></param>
        /// <param name="invController"></param>
        public void CalculateWinAmount(List<Inventory> _inventories, List<Horse> _horses, int betAmount, string firstParam, InventoryController invController)
        {
            int Payout = 0;
            int totalInventoryValue = _inventories.Sum(x => x.Notes * x.NotesCounter);
            List<Inventory> DispensingList = new List<Inventory>();

            Horse bid = _horses.FirstOrDefault(x => x.HorseNo == int.Parse(firstParam));
            if (bid.Result == "Won")                                    // If the horse you bet is won
            {
                Payout = betAmount * bid.Odds;
                if (totalInventoryValue > Payout)                       // Check for the fund is there as per calculated payout
                {
                    Console.WriteLine("Payout :" + bid.HorseName + ",$" + Payout);

                    int[] bills = new int[] { 100, 20, 10, 5, 1 };
                    int[] billCounter = new int[5];

                    try
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (Payout >= bills[i])
                            {
                                billCounter[i] = Payout / bills[i];
                                Payout = Payout % bills[i];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception in Payout section :" + ex.Message);
                    }

                    try
                    {
                        Console.WriteLine("Dispensing: ");                          // Showing the dispensing list
                        for (int i = 0; i < 5; i++)
                        {
                            if (billCounter[i] != 0)
                            {
                                Console.WriteLine("$" + bills[i] + " , " + billCounter[i]);
                                DispensingList.Add(new Inventory() { Notes = bills[i], NotesCounter = billCounter[i] });
                            }
                        }
                       bool result= invController.UpdateInventory(DispensingList);              // Updating the inventory after payout
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception in Dispensing section :" + ex.Message);
                        throw;
                    }

                }
                else                                                            // InSufficient Fund
                {
                    Console.WriteLine("Insufficient Funds : $" + Payout);
                }
            }
            else                                // If the horse you bet is lost then display message no payout.
            {
                Console.WriteLine("No Payout :" + bid.HorseName);
            }

        }

    }
}
