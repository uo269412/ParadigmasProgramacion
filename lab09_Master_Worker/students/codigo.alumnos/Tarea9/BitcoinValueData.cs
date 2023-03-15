using System;

namespace TPP.Laboratory.Concurrency.Lab09
{
    public class BitcoinValueData
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return Timestamp + ": " + Value;
        }
    }
}
