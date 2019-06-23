using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力を取得
            var n = long.Parse(Console.ReadLine());
            var inputsA = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var inputsB = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var storeA = new Store(inputsA);
            var storeB = new Store(inputsB);

            var maxAcornAtoB = OneWayResale(n, storeA, storeB);
            var maxAcorn = OneWayResale(maxAcornAtoB, storeB, storeA);

            // 解答の出力
            Console.WriteLine(maxAcorn);
        }

        static long OneWayResale(long acorn, Store seller, Store buyer)
        {
            var higherG = seller.Gold < buyer.Gold;
            var higherS = seller.Silver < buyer.Silver;
            var higherB = seller.Bronze < buyer.Bronze;
            var pseudoSeller = seller.GeneratePseudoStore(higherG, higherS, higherB);
            var pseudoBuyer = buyer.GeneratePseudoStore(higherG, higherS, higherB);

            var gold = new JewelPrice(pseudoSeller.Gold, pseudoBuyer.Gold);
            var silver = new JewelPrice(pseudoSeller.Silver, pseudoBuyer.Silver);
            var bronze = new JewelPrice(pseudoSeller.Bronze, pseudoBuyer.Bronze);

            var jewelPrices = new[] { gold, silver, bronze };
            jewelPrices = jewelPrices.OrderByDescending(p => p.InterestRate).ToArray();

            var high = jewelPrices[0];
            var middle = jewelPrices[1];
            var low = jewelPrices[2];

            // 最高利率の貴金属でドングリを使いきれるならば、それが１番利益が発生する
            if (acorn % high.SellerPrice == 0)
            {
                return acorn + high.Profit * (acorn / high.SellerPrice);
            }

            var maxAcorns = acorn;
            for (var i = acorn / high.SellerPrice; 0 <= i; i--)
            {
                var remain = acorn - high.SellerPrice * i;
                if (remain % middle.SellerPrice == 0)
                {
                    var acornCount = acorn + high.Profit * i + middle.Profit * (remain / middle.SellerPrice);
                    return maxAcorns < acornCount ? acornCount : maxAcorns;
                }

                for (var j = remain / middle.SellerPrice; 0 <= j; j--)
                {
                    var lowCount = (remain - middle.SellerPrice * j) / low.SellerPrice;
                    var acornCount = acorn + high.Profit * i + middle.Profit * j + low.Profit * lowCount;
                    if (acornCount > maxAcorns) maxAcorns = acornCount;
                }
            }
            return maxAcorns;
        }

        struct Store
        {
            public readonly long Gold, Silver, Bronze;

            public Store(long[] prices)
            {
                Gold = prices[0];
                Silver = prices[1];
                Bronze = prices[2];
            }

            Store(long gold, long silver, long bronze)
            {
                Gold = gold;
                Silver = silver;
                Bronze = bronze;
            }

            public Store GeneratePseudoStore(bool stayGold, bool staySilver, bool stayBronze)
            {
                var gold = stayGold ? Gold : long.MaxValue;
                var silver = staySilver ? Silver : long.MaxValue;
                var bronze = stayBronze ? Bronze : long.MaxValue;
                return new Store(gold, silver, bronze);
            }
        }

        struct JewelPrice
        {
            public readonly long SellerPrice, BuyerPrice;

            public JewelPrice(long seller, long buyer)
            {
                SellerPrice = seller;
                BuyerPrice = buyer;
            }

            public float InterestRate
            {
                get { return (float)Profit / SellerPrice; }
            }

            public long Profit
            {
                get { return BuyerPrice - SellerPrice; }
            }
        }
    }
}
