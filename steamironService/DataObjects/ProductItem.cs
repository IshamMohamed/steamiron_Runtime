using Microsoft.Azure.Mobile.Server;

namespace steamironService.DataObjects
{
    public class ProductItem : EntityData
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public Merchant Merchant { get; set; }
    }
}