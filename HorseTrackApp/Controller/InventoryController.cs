using HorseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackApp.Controller
{
    public class InventoryController
    {      
        public List<Inventory> Inventories { get; set; }
        public InventoryController()
        {
            this.Inventories = new List<Inventory>() {
            new Inventory(){ Notes=1,NotesCounter=10},
            new Inventory(){ Notes=5,NotesCounter=10},
            new Inventory(){ Notes=10,NotesCounter=10},
            new Inventory(){ Notes=20,NotesCounter=10},
            new Inventory(){ Notes=100,NotesCounter=10}
            };   
        }

        public bool UpdateInventory(List<Inventory> DispiensingList)
        {
            try
            {
               foreach (var item in DispiensingList)
               {
                  this.Inventories.Where(x => x.Notes == item.Notes).ToList().ForEach(i => i.NotesCounter -= item.NotesCounter);
               }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while updating Entry:"+ ex.ToString());
                return false;
            }
        }
    }
}
