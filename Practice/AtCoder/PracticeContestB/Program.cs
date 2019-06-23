using System;
using System.Linq;

namespace PracticeContestB
{
    class Program
    {
        public static char[] answer;
        public static int queryCount = 0;

        static void Main(string[] args)
        {
            // 条件の受け取り
            var conds = "26 100".Split().Select(int.Parse).ToArray();
//            var conds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = conds[0];
            var q = conds[1];

            answer = GenerateRandomAlphabets(n);
            var sortedAlphabets = QuickSort(n);

            Console.WriteLine(String.Format("! {0}", String.Concat(sortedAlphabets)));
            Console.WriteLine(String.Format("Ans. {0}", String.Concat(answer)));
            Console.WriteLine(String.Format("Match. {0}", String.Concat(answer) == String.Concat(sortedAlphabets)));
            Console.WriteLine(String.Format("Cnt. {0}", queryCount));
        }

        /* バブルソート */
        static char[] BubbleSort(int n)
        {
            var alphabets = GenerateInitialAlphabets(n);

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n - 1 - i; j++)
                {
                    var result = QueryGreaterThan(alphabets[j], alphabets[j + 1]);
                    if (!result)
                    {
                        var temp = alphabets[j];
                        alphabets[j] = alphabets[j + 1];
                        alphabets[j + 1] = temp;
                    }
                }
            }

            return alphabets;
        }

        /* クイックソート */
        static char[] QuickSort(int n)
        {
            var alphabets = GenerateInitialAlphabets(n);

            QuickSortImpl(alphabets, 0, n - 1);

            return alphabets;
        }

        static void QuickSortImpl(char[] alphabets, int start, int end)
        {
            if (end <= start) return;

            var left = start;
            var right = end;
            var pivot = alphabets[left];

            while (left < right)
            {
                while (left < right)
                {
                    // 基準値 pivot より小さい場合、値を入れ替え対象とする
                    var result = QueryGreaterThan(pivot, alphabets[right]);
                    if (!result) break;

                    right--;
                }
                if (left != right)
                {
                    alphabets[left] = alphabets[right];
                    left++;
                }

                while (left < right)
                {
                    // 基準値 pivot より大きい場合、値を入れ替え対象とする
                    var result = QueryGreaterThan(pivot, alphabets[left]);
                    if (result) break;

                    left++;
                }
                if (left != right)
                {
                    alphabets[right] = alphabets[left];
                    right--;
                }
            }

            alphabets[left] = pivot;

            QuickSortImpl(alphabets, start, left - 1);
            QuickSortImpl(alphabets, left + 1, end);
        }

        // クエリの出力、結果の受け取り、判定を実行
        static bool QueryGreaterThan(char left, char right)
        {
            Console.WriteLine(String.Format("? {0} {1}", left, right));
            var res = CheckWeight(left, right);
//            var res = Console.ReadLine();
            return res == "<";
        }

        // 大文字アルファベットの初期配列を作成
        static char[] GenerateInitialAlphabets(int n)
        {
            return Enumerable.Range(0, n).Select(i => (char)('A' + i)).ToArray();
        }

        static char[] GenerateRandomAlphabets(int n)
        {
            return Enumerable.Range(0, n)
                .Select(i => (char)('A' + i))
                .OrderBy(x => Guid.NewGuid())
                .ToArray();
        }

        static string CheckWeight(char a, char b)
        {
            queryCount++;
            var aIndex = Array.FindIndex(answer, (x) => a == x);
            var bIndex = Array.FindIndex(answer, (x) => b == x);

            if (aIndex < bIndex) return "<";
            if (bIndex < aIndex) return ">";

            throw new Exception();
        }
    }
}
