using HorseTrackApp.Controller;
using HorseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HorseTrackUnitTest
{
    public class InventoryControllerTest
    {
        [Fact]
        public void UpdateHorseTest_Passed()
        {
            List<Inventory> DispiensingList = new List<Inventory>()
            {
                new Inventory{ Notes=1,NotesCounter=3},
                new Inventory{ Notes=2,NotesCounter=2},
                new Inventory{ Notes=5,NotesCounter=4},
            };

            InventoryController invController = new InventoryController();
            bool result = invController.UpdateInventory(DispiensingList);
            Assert.Equal(result, true);
        }        
    }
}
