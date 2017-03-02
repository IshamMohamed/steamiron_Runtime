using Microsoft.Azure.Mobile.Server;
using System.ComponentModel.DataAnnotations.Schema;


namespace steamironService.DataObjects
{
    public class ProductItem : EntityData
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }

        #region Relationships
        public string MerchantId { get; set; }
        #endregion
    }
}