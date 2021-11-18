using ComputerDatabase.Qa.Core.Models;
using System;

namespace ComputerDatabase.Qa.Core.Builders
{
    //Helps to build new computer opject with different parameters
    public class ComputerBuilder
    {
        private Computer _computer = new Computer();

        public Computer Build() => _computer;

        public ComputerBuilder WithComputerName(string computerName)
        {
            _computer.ComputerName = computerName;
            return this;
        }

        public ComputerBuilder WithIntroducedDate(DateTime introducedDate)
        {
            _computer.IntroducedDate = introducedDate;
            return this;
        }

        public ComputerBuilder WithDiscontinuedDate(DateTime discontinuedDate)
        {
            _computer.DiscontinuedDate = discontinuedDate;
            return this;
        }

        public ComputerBuilder WithCompany(string companyName)
        {
            _computer.Company = companyName;
            return this;
        }
    }
}
