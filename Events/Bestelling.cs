using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Bestelling
    {
       public Bestelling(ProductType product, double prijs, int aantal, string adres)
        {
            this.product = product;
            this.prijs = prijs;
            this.aantal = aantal;
            this.adres = adres;
        }

        public ProductType product { get; set; }
        public double prijs { get; set; }
        public int aantal { get; set; }
        public string adres { get; set; }
        public override string ToString()
        {
            return $"{product},{prijs},{aantal}";
        }
    }
}
