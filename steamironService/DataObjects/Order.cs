using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace steamironService.DataObjects
{
    public class Order : EntityData
    {
        public Cart Cart { get; set; }
        public Customer Customer { get; set; }
        public Merchant Merchant { get; set; }
        public string DeliveryAddress { get; set; }
        public double AmountToBePaid { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        CustomerOrdered,    // When Customer First Made and Order
        MerchantViewed,     // Order was made, but merchant didnt read this - Will be used when filtering NON-VIEWED Orders for Merchant
        MerchantVerified,   // Merchant checked the order and stock - Order can be delivered
        MerchantRefused,    // Merchant checked the stock and was not sufficient
        OrderPreparing,     // Order is being prepared by the delivery boy
        DeliveryPending,    // Basket is ready at shop
        DeliveryOnTheWay,   // Delivery boys is on his way to customer
        Delivered           // Order delivered and payment made by customer
    }
}