using HorseTrackApp.Controller;
using HorseTrackApp.Models;
using HorseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackApp
{
    public class Program
    {         

        public static void Main(string[] args)
        {
            HorseService horseService = new HorseService();

            //Intialize the inventory and create a object of it.
            InventoryController invController = new InventoryController();
            horseService.ShowInventory(invController.Inventories);

            //Intialize the Horses and create a object of it.
            HorseController horseController = new HorseController();
            horseService.ShowHorses(horseController.Horses);

            
            string cmd = "";
            int betAmount = 0;
            do
            {
               
                // Taking input from user
                Console.WriteLine("Please enter the Command:");
                string input = Console.ReadLine();
                ProcessInput processInput = new ProcessInput();
                cmd = processInput.ParseInput(input);
               

                switch (cmd)
                {
                    case "Restock":
                        horseService.ReStockInventory(invController.Inventories);
                        horseService.ShowInventory(invController.Inventories);
                        horseService.ShowHorses(horseController.Horses);
                        break;

                    case "ChangeWinner":
                        horseService.ShowInventory(invController.Inventories);
                       bool Result= horseController.UpdateWinningHorse(processInput.ChangeWinningHorse);
                        horseService.ShowHorses(horseController.Horses);
                        break;

                    case "WinAmount":
                        horseService.ShowInventory(invController.Inventories);
                        horseService.ShowHorses(horseController.Horses);
                        betAmount =int.Parse(processInput.secondParam);
                        horseService.CalculateWinAmount(invController.Inventories, horseController.Horses,betAmount, processInput.firstParam,invController );
                        horseService.ShowInventory(invController.Inventories);
                        break;                    

                    case "Invalid":
                        break;

                    default:
                        Console.WriteLine("Invalid Command:" + cmd);
                        break;
                }             
            } while (cmd!= "Quit");
        }
    }
}
