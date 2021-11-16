using ComputerDatabase.Qa.Core.Models;
using System;

namespace ComputerDatabase.Qa.Core.Builders
{
    public class ComputerBuilder
    {
        private Computer _computer = new Computer();

        public Computer Build() => _computer;

        public ComputerBuilder WithComputerName(string computerName)
        {
            _computer.ComputerName = computerName;
            return this;
        }

        public ComputerBuilder WithIntroducedDate()
        {
            _computer.IntroducedDate = DateTime.Now.AddDays(-20);
            return this;
        }
    }
}
