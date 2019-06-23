using System;
using System.Linq;

namespace AChangingACharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var k = inputs[1];

            var s = Console.ReadLine().ToCharArray();
            
            // K 番目の文字を小文字に変換
            s[k - 1] = char.ToLower(s[k - 1]);

            // 解答の出力
            Console.WriteLine(String.Concat(s));
        }
    }
}
