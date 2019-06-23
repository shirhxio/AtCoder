using System;
using System.Linq;

namespace DEvenRelation
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            
            var edges = new Edge[n];
            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                edges[i] = new Edge(inputs[0], inputs[1], inputs[2]);
            }
        }

        class Edge
        {
            public readonly int _vertexU, _vertexV, _length;

            public Edge(int u, int v, int w)
            {
                _vertexU = u;
                _vertexV = v;
                _length = w;
            }
        }
    }
}
