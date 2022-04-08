using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppList.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double PriceProduct { get; set; }
        public int QuantyProduct { get; set; }
        public string Description { get; set; }

    }
}
