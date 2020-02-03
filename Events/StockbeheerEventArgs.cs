using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class StockbeheerEventArgs
    {
        public StockbeheerEventArgs(Dictionary<ProductType, int> groothandelbestelling)
        {
            this.groothandelbestelling = groothandelbestelling;
        }

        public Dictionary<ProductType,int> groothandelbestelling { get; set; }
    }
}
