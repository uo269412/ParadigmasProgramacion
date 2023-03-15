
namespace TPP.Laboratory.Concurrency.Lab09
{

    internal class Worker {

        private BitcoinValueData[] vector;
        private int fromIndex, toIndex;
        private int fixedValue;
        private double result;
        internal double Result {
            get { return this.result; }
        }

        internal Worker(BitcoinValueData[] vector, int fromIndex, int toIndex, int fixedValue) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.fixedValue = fixedValue;
        }

        internal void Compute() {
            this.result = 0;
            for(int i= this.fromIndex; i<=this.toIndex; i++)
            {
                if (this.vector[i].Value > fixedValue)
                {
                    this.result += 1;
                }
            }
        }

    }

}
