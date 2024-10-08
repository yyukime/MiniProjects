using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    class Wait
    {
        static void NumberGenerator()
        {
            Random RandomNumber = new Random();
            int RNGInt = RandomNumber.Next(1);
            Console.WriteLine(RNGInt);

        }

        static void Main(string[] args)
        {
            NumberGenerator();
        }





    }
}

