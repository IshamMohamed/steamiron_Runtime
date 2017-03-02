using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace steamironService.DataObjects
{
    public class Cart : EntityData
    {
        public Customer Customer { get; set; }
        public Merchant Merchant { get; set; }
        public Dictionary <ProductItem, int> Product_Count { get; set; }
    }
}