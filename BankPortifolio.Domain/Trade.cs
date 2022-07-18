using System;

namespace BankPortifolio.Domain
{
    public class Trade {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public eCategory? Category { get; set; }        
    }
}
