using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Stockbeheer        
    {
        private static readonly int stockgrootte=100;
        private static readonly int minimumstock = 25;
        private Dictionary<ProductType,int> stock;
        public event EventHandler<StockbeheerEventArgs> StockBestelling;

        public Stockbeheer()
        {
            this.stock = new Dictionary<ProductType, int>();
        }
        public void InitStock()
        {
            stock.Add(ProductType.Dubbel, stockgrootte);
            stock.Add(ProductType.Kriek, stockgrootte);
            stock.Add(ProductType.Pils, stockgrootte);
            stock.Add(ProductType.Tripel, stockgrootte);
        }

        public void OnWinkelverkoop(object source, WinkelEventArgs args)
        {
            Console.WriteLine("stockbeheer - onwinkelverkoop");
            Console.WriteLine(args.bestelling);
            stock[args.bestelling.product] -= args.bestelling.aantal;
            if (stock[args.bestelling.product] < minimumstock) maakGroothandelaarBestelling();
        }
        private void maakGroothandelaarBestelling()
        {
            Dictionary<ProductType, int> GHB=new Dictionary<ProductType, int>();
            foreach (var s in stock)
            {
                if (s.Value<stockgrootte)
                {
                    GHB.Add(s.Key, stockgrootte - s.Value);
                }
            }
            OnStockBestelling(GHB);
        }
        public void ShowStock()
        {
            foreach(var p in stock)
            {
                Console.WriteLine($"[stock:{p.Key}, {p.Value}]");
            }
        }
        protected virtual void OnStockBestelling(Dictionary<ProductType, int> GHB)
        {
            if (StockBestelling!=null)
            {
                StockBestelling(this,new StockbeheerEventArgs(GHB));
            }
        }
        public void VulStockAan(Dictionary<ProductType, int> stock)
        {
            foreach(var x in stock)
            {
                this.stock[x.Key] += x.Value;
            }
        }
    }
}
