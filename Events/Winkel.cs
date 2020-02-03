using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Winkel
    {
        //define delegate
        //define event based on delegate
        //raise event
        //public delegate void WinkelverkoopEventHandler(object source, WinkelEventArgs args);
        //public event WinkelverkoopEventHandler Winkelverkoop;

        public event EventHandler<WinkelEventArgs> Winkelverkoop;

        public void VerkoopProduct(Bestelling p)
        {
            Console.WriteLine($"verkoopproduct - {p}");
            OnWinkelverkoop(p);
        }
        protected virtual void OnWinkelverkoop(Bestelling p)
        {
            if (Winkelverkoop != null)
            {
                Winkelverkoop(this, new WinkelEventArgs { bestelling = p });
            }
        }
    }
}
