using System;
using System.Linq;

namespace ABC081B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var n = Console.ReadLine();
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 可能な操作回数のカウント
            var count = 0;
            while (nums.All(x => x % 2 == 0))
            {
                count++;
                nums = nums.Select(x => x / 2).ToArray();
            }

            // 解答の出力
            Console.WriteLine(count);
        }
    }
}
