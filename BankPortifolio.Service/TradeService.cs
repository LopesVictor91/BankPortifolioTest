using BankPortifolio.Domain;
using System;
using System.Collections.Generic;

namespace BankPortifolio.Service
{
    public class TradeService
    {
        public List<Trade> Categorize(List<Trade> trades, DateTime referenceDate)
        {
            foreach (var trade in trades)
            {
                if ((referenceDate - trade.NextPaymentDate).TotalDays > 30)
                    trade.Category = eCategory.EXPIRED;
                else if (trade.Value > 1000000 && trade.ClientSector.Equals("Private"))
                    trade.Category = eCategory.HIGHRISK;
                else if (trade.Value > 1000000 && trade.ClientSector.Equals("Public"))
                    trade.Category = eCategory.MEDIUMRISK;
                else trade.Category = null;
            }

            return trades;
        }
    }
}
