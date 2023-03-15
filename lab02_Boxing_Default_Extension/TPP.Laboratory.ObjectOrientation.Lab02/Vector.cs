using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    public class Vector
    {
        public int Size { get; set; }
        private int[] List { get; }

        private int Threshold { get; set; }

        public Vector ()
        {
            Threshold = 10;
            List = new int[Threshold];
        }
        public void Add(int firstValue)
        {
           if (List.GetLength() < Threshold )
            {

            }
           
        }

        public int GetElement(int v)
        {
            throw new NotImplementedException();
        }

        public void SetElement(int v, int firstValue)
        {
            throw new NotImplementedException();
        }
    }
}
