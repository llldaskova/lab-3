using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new RomanNumber(10);
            var number2 = new RomanNumber(20);
            Console.WriteLine(number.CompareTo(number2));
           
        }
    }
}
