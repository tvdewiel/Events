using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Groothandelaar
    {
        private List<Dictionary<ProductType, int>> voorraadBestelling;

        public Groothandelaar()
        {
            voorraadBestelling = new List<Dictionary<ProductType, int>>();
        }

        public void OnStockbestelling(object source, StockbeheerEventArgs args)
        {
            Console.WriteLine("groothandelaar - onstockbestelling");
            foreach (var x in args.groothandelbestelling)
            {
                Console.WriteLine($"GHB:{x.Key},{x.Value}");
            }
            voorraadBestelling.Add(args.groothandelbestelling);
        }
        public void ShowVoorraadBestelling()
        {
            foreach(var x in voorraadBestelling)
            {
                foreach(var y in x)
                {
                    Console.WriteLine($"Voorraadbestelling : {y.Key},{y.Value}");
                }
            }
        }
        public Dictionary<ProductType, int> GeefLaatsteBestelling()
        {
            return voorraadBestelling[voorraadBestelling.Count-1];
        }
    }
}
