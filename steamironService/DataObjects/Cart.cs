using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace steamironService.DataObjects
{
    public class Cart : EntityData
    {
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }
        public virtual ICollection<ProductItem> Product { get; set; }
        public int Count { get; set; }

        #region Relationships
        public string CustomerId { get; set; }
        public string MerchantId { get; set; }
        #endregion
    }
}