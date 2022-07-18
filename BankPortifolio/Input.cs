using BankPortifolio.Domain;
using System;
using System.Collections.Generic;

namespace BankPortifolio.App
{
    internal class Input
    {
        public Int32 nLines { get; set; }
        public DateTime referenceDate { get; set; }
        public List<Trade> trades { get; set; }
    }
}
