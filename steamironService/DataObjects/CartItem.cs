using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace steamironService.DataObjects
{
    public class CartItem : EntityData
    {
        [ForeignKey("ProductId")]
        public ProductItem Product { get; set; }
        public int Count { get; set; }

        #region Relationships
        public string ProductId { get; set; }
        #endregion
    }
}