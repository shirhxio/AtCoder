using System;
using System.Linq;

namespace PracticeContest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 単一入力の受け取り
            var a = int.Parse(Console.ReadLine());

            // 複数入力の受け取り
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var b = inputs[0];
            var c = inputs[1];

            var sum = a + b + c;

            // 文字列の受け取り
            var str = Console.ReadLine();

            // 回答の出力 
            Console.WriteLine(String.Format("{0} {1}", sum.ToString(), str));
        }
    }
}
