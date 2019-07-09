using System;
using System.Collections.Generic;
using System.Linq;

// https://atcoder.jp/contests/abc133/tasks/abc133_e
namespace EVirusTree2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputs[0], k = inputs[1];

            var nodes = Enumerable.Range(1, n).Select(x => new Node()).ToArray();

            for (var i = 0; i < n - 1; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int indexA = edge[0] - 1, indexB = edge[1] - 1;
                Node.Unite(nodes[indexA], nodes[indexB]);
            }

            var answer = new ModNum(k);

            if (n > 1)
            {
                // 簡易化するため、隣接ノードが1つの末端ノードを root として選定
                var root = nodes.First(x => x.NeighborCount == 1);
                var maxChildCount = nodes.Max(x => x.ChildCount);

                if (k - 2 < maxChildCount)
                {
                    answer = 0; // 距離2以内のノード数がkより大きくなる場合、塗る方法がないので0
                }
                else
                {
                    // root 直下のノードの色の塗り方（root 以外の色 k-1 通り）
                    answer *= k - 1;

                    // root 以外のノードについて、子ノードの色の塗り方を乗算していく
                    var permutations = CalcPermutations(k - 2, maxChildCount);
                    foreach (var node in nodes)
                    {
                        // 子ノードを持たない末端ノード（root 含む）除外
                        if (node.ChildCount == 0) continue;

                        answer *= permutations[node.ChildCount];
                    }
                }
            }

            // 解答の出力
            Console.WriteLine(answer.X);
        }

        static ModNum[] CalcPermutations(int head, int count)
        {
            var array = new ModNum[count + 1];
            array[0] = 1;
            for (var i = 0; i < count; i++)
            {
                array[i + 1] = array[i] * (head - i);
            }
            return array;
        }
    }

    class Node
    {
        readonly List<Node> _neighbors = new List<Node>();

        public int NeighborCount { get { return _neighbors.Count; } }
        public int ChildCount { get { return _neighbors.Count - 1; } }

        public static void Unite(Node a, Node b)
        {
            a._neighbors.Add(b);
            b._neighbors.Add(a);
        }
    }

    public struct ModNum : IEquatable<ModNum>
    {
        const int Mod = 1000000007;
        public long X { get; }

        public ModNum(long x) { X = x % Mod; }
        public static implicit operator ModNum(long x) => new ModNum(x);

        public bool Equals(ModNum other) => X == other.X;
        public override bool Equals(object obj) => obj is ModNum && Equals((ModNum)obj);
        public override int GetHashCode() => X.GetHashCode();
        public static bool operator ==(ModNum a, ModNum b) => a.X == b.X;
        public static bool operator !=(ModNum a, ModNum b) => a.X != b.X;

        public static ModNum operator +(ModNum a, ModNum b) => a.X + b.X;
        public static ModNum operator -(ModNum a, ModNum b) => Mod + a.X - b.X;
        public static ModNum operator *(ModNum a, ModNum b) => a.X * b.X;
        public static ModNum operator /(ModNum a, ModNum b) => a.X * Pow(b, Mod - 2);

        public static ModNum Pow(ModNum baseNum, int exponent)
        {
            switch (exponent)
            {
                case 0:
                    return 1;
                case 1:
                    return baseNum;
                default:
                    var pow = Pow(baseNum, exponent / 2);
                    return (exponent % 2) == 0 ? pow * pow : pow * pow * baseNum;
            }
        }
    }
}
