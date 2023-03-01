using HorseTrackApp;
using HorseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HorseTrackUnitTest
{
    public class ProcessInputTest
    {
        [Fact]
        public void ChangeHorseWinner_Passed()
        {
            ProcessInput _inputProcess = new ProcessInput();            
            var ParsedInput= _inputProcess.ParseInput("w 4");
            Assert.Equal("ChangeWinner", ParsedInput);

        }

        [Fact]
        public void MultipleInvalidParameterCheck_Passed()
        {
            ProcessInput _inputProcess = new ProcessInput();
            var ParsedInput = _inputProcess.ParseInput("w 4 5");
            Assert.Equal("Invalid", ParsedInput);

        }

        [Fact]
        public void RestockInput_Passed()
        {
            ProcessInput _inputProcess = new ProcessInput();
            var ParsedInput = _inputProcess.ParseInput("r");
            Assert.Equal("Restock", ParsedInput);

        }

        [Fact]
        public void QuitInput_Passed()
        {
            ProcessInput _inputProcess = new ProcessInput();
            var ParsedInput = _inputProcess.ParseInput("q");
            Assert.Equal("Quit", ParsedInput);

        }

        [Fact]
        public void InvalidInput_Passed()
        {
            ProcessInput _inputProcess = new ProcessInput();
            var ParsedInput = _inputProcess.ParseInput("a");
            Assert.Equal("Invalid", ParsedInput);

        }
    }
}
