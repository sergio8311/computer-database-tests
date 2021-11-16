using System;

namespace ComputerDatabase.Qa.Core.Models
{
    public class Computer
    {
        public string ComputerName { get; set; }
        public DateTime IntroducedDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public string Company { get; set; }
    }
}
