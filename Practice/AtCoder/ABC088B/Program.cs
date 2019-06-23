using System;
using System.Linq;

namespace ABC088B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var n = int.Parse(Console.ReadLine());
            var cards = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sortedCards = cards.OrderByDescending(i => i).ToArray();

            // Alice, Bob の得点を計算
//            var scoreAlice = sortedCards.Where((_, index) => index % 2 == 0).Sum();
//            var scoreBob = sortedCards.Where((_, index) => index % 2 == 1).Sum();

            int scoreAlice = 0, scoreBob = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) scoreAlice += sortedCards[i];
                else scoreBob += sortedCards[i];
            }

            var scoreDifference = scoreAlice - scoreBob;

            // 解答の出力
            Console.WriteLine(scoreDifference);
        }
    }
}
