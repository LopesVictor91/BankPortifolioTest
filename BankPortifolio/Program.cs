using BankPortifolio.Domain;
using BankPortifolio.Service;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BankPortifolio.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = inputParse();

            var categorizedTrades = (new TradeService()).Categorize(input.trades, input.referenceDate);

            foreach (var trade in categorizedTrades)
            {
                Console.WriteLine(trade.Category.ToString());
            }
        }

        private static DateTime dateParse(string datetime)
        {
            return DateTime.ParseExact(datetime,
                                "MM/dd/yyyy",
                                CultureInfo.InvariantCulture);
        }

        private static Input inputParse() {
            try
            {
                List<string> initialInput = new List<string>();
                List<Trade> trades = new List<Trade>();
                DateTime referenceDate;
                Int32 nLines;

                var lineInput = Console.ReadLine();
                while (lineInput != string.Empty)
                {
                    initialInput.Add(lineInput);
                    lineInput = Console.ReadLine();
                }

                referenceDate = dateParse(initialInput[0]);
                nLines = Convert.ToInt32(initialInput[1]);

                foreach (String line in initialInput.GetRange(2, nLines))
                {
                    string[] data = line.Split(' ');

                    trades.Add(new Trade()
                    {
                        Value = Convert.ToDouble(data[0]),
                        ClientSector = data[1],
                        NextPaymentDate = dateParse(data[2])
                    });
                }


                return new Input()
                {
                    referenceDate = referenceDate,
                    nLines = nLines,
                    trades = trades
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to parse input");
                Console.WriteLine("Hint: {0}", ex.Message);
                return null;
            }
        }
    }


}
