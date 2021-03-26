using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    class Program

    {
        public static Random randoms;
        static void Main(string[] args)
        {

            randoms = new Random((int)DateTime.Now.Ticks);
            var numbers = Enumerable.Range(1, 49).ToList();

            int[] SelectedNumbers = new int[6];
            
            for (var i = 0; i < 6; i++) 
            {
                var number = GetNumber(numbers.ToArray());

                while (SelectedNumbers.Contains(number)) 
                {
                    number = GetNumber(numbers.ToArray());
                }
                SelectedNumbers[i] = number;
            }
            Console.WriteLine("Lotto numbers: " + string.Join(" ", SelectedNumbers.OrderBy(n => n)));
        }
        public static int GetNumber(int[] arr)
        {
            if (arr.Length > 1)
            {
                var r = randoms.Next(0, arr.Length);
                var list = arr.ToList();
                list.RemoveAt(r);

                return GetNumber(list.ToArray());
            }
            return arr[0];
        }
    }
}
