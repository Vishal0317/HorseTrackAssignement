using HorseTrackApp.Controller;
using System;
using Xunit;

namespace HorseTrackUnitTest
{
    public class HorseControllerTest
    {
        [Fact]
        public void UpdateHorseTest_Passed()
        {
            HorseController horseController = new HorseController();
            bool result = horseController.UpdateWinningHorse(3);
            Assert.Equal(result,false);
        }

        [Fact]
        public void UpdateHorseTest_Failed()
        {
            HorseController horseController = new HorseController();
            bool result=horseController.UpdateWinningHorse(8);
            Assert.Equal(result, true);
        }
    }
}
