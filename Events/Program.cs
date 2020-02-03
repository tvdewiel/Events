using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Winkel w = new Winkel(); //publisher
            Stockbeheer sb = new Stockbeheer(10); //subscriber
            sb.InitStock();
            w.Winkelverkoop += sb.OnWinkelverkoop;

            Sales s = new Sales();
            w.Winkelverkoop += s.OnWinkelverkoop;

            Groothandelaar gh = new Groothandelaar();
            sb.StockBestelling += gh.OnStockbestelling;

            w.VerkoopProduct(new Bestelling(ProductType.Dubbel,3.99,35,"Dorpstraat 5, Lievegem" ));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 25, "Dorpstraat 5, Lievegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Kerkstraat 155, Zele"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 55, "Dorpstraat 5, Lievegem"));

            Console.WriteLine("-----------");
            sb.ShowStock();
            Console.WriteLine("-----------");
            s.ShowRapport();
            Console.WriteLine("-----------");
            gh.ShowVoorraadBestelling();
            Console.WriteLine("-----------");
            sb.VulStockAan(gh.GeefLaatsteBestelling());
            Console.WriteLine("-----------");
            sb.ShowStock();
            Console.WriteLine("-----------");
        }
    }
}
