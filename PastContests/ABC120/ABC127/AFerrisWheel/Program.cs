using System;
using System.Linq;

namespace AFerrisWheel
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = inputs[0];
            var b = inputs[1];

            var price = GetPrice(a, b);

            // 解答の出力
            Console.WriteLine(price);
        }

        // 観覧車の年齢別料金の取得
        static int GetPrice(int age, int basePrice)
        {
            if (age >= 13)
            {
                return basePrice;
            }
            else if (age >= 6)
            {
                return basePrice / 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
