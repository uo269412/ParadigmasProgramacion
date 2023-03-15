using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using angle;

namespace use.angle
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(Math.PI);
            Console.WriteLine("Angle (radians) {0}", a.Radians);
            Console.WriteLine("Angle (degrees) {0}", a.Degrees);
            Console.WriteLine("Sine            {0}", a.Sine());
            Console.WriteLine("Cosine          {0}", a.Cosine());
            Console.WriteLine("Tangent         {0}", a.Tangent());
        }
    }
}
