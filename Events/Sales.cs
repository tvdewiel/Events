using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Sales
    {
        private Dictionary<string, List<Bestelling>> rapport;

        public Sales()
        {
            rapport = new Dictionary<string, List<Bestelling>>();
        }

        public void OnWinkelverkoop(object source, WinkelEventArgs args)
        {
            Console.WriteLine("sales - onwinkelverkoop");
            Console.WriteLine(args.bestelling);
            if (!rapport.ContainsKey(args.bestelling.adres))
            {
                rapport.Add(args.bestelling.adres, new List<Bestelling>() { args.bestelling });
            }
            else
            {
                rapport[args.bestelling.adres].Add(args.bestelling);
            }
        }
        public void ShowRapport()
        {
            Console.WriteLine("Sales - rapport");
            foreach(var a in rapport)
            {
                Dictionary<ProductType, int> tmp=new Dictionary<ProductType, int>();
                Console.WriteLine(a.Key);
                foreach(var b in a.Value)
                {
                    if (tmp.ContainsKey(b.product)) tmp[b.product] += b.aantal;
                    else tmp.Add(b.product, b.aantal);
                }
                foreach(var x in tmp)
                {
                    Console.WriteLine($"   {x.Key},{x.Value}");
                }
            }
        }
    }
}
