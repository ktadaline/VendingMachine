using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public interface IProduct
    {

        int QuantityStart{ get; }
        int QuantitySold { get; set; }
        int QuantityLeft { get;}
        string ProductName { get; }
        string SlotLocation { get; }
        decimal Price { get; }

        string Message { get; }



    }
}
