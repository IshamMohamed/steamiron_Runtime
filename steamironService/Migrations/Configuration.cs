namespace steamironService.Migrations
{
    using DataObjects;
    using Microsoft.Azure.Mobile.Server.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<steamironService.Models.steamironContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }

        protected override void Seed(steamironService.Models.steamironContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);

            //context.Merchants.AddOrUpdate(
            //    m => m.Name,
            //    new Merchant { Id = Guid.NewGuid().ToString(), Name = "Alfardan Stores", Address = "Al Fardan Plaza Building, Al Sadd St, Doha 3188, Qatar.", Email = "store@alfardan.com", Phone = "+974 4436 7334" },
            //    new Merchant { Id = Guid.NewGuid().ToString(), Name = "Choice Center Qatar", Address = "Office No. 305, Choice Center Building, Al Difaf Street, Al Sadd Area, Near Al Sadd Mall, Doha, Qatar.", Email = "store@ccb.com", Phone = "+974 4436 5619" },
            //    new Merchant { Id = Guid.NewGuid().ToString(), Name = "Me And My Baby", Address = "24030, Al Sadd, Doha, Qatar.", Email = "store@ccb.com", Phone = "+974 4444 3313" }
            //);

            //context.Customers.AddOrUpdate(
            //    c => c.Name,
            //    new Customer { Id = Guid.NewGuid().ToString("N"), Name = "Alfred" , Address = "25468, Al Sadd, Doha, Qatar.", Email = "alfred@customer.com", Phone = "+974 5555 7859", Points = 1500.00, Verified = true }
            //);

            //ProductItem p = (ProductItem)context.ProductItems.Select(q => new ProductItem() { Id = "f4da9f21bd094a61bc9f82259dc99abf" }).FirstOrDefault();

            //List<CartItem> cartItems = new List<CartItem>
            //{
            //    new CartItem { Id = Guid.NewGuid().ToString("N"), ProductId = "ad46e731ba4044ccaa4d1a9925253d58", Count = 5 },
            //    new CartItem { Id = Guid.NewGuid().ToString("N"), ProductId = "f4da9f21bd094a61bc9f82259dc99abf", Count = 1 }
            //};
            //context.Set<CartItem>().AddRange(cartItems);

            //context.Carts.AddOrUpdate(
            //    c => c.Id,
            //    new Cart { Id = Guid.NewGuid().ToString("N"), CartItem = cartItems, CustomerId = "f2565d1471724176814cadba368f52fc", MerchantId = "aadb5706-50ea-4270-84b8-44f0db3a5d31" }
            //);

            //context.Orders.AddOrUpdate(
            //    o => o.Id,
            //    new Order { Id = Guid.NewGuid().ToString("N"), CartId = "674067f7383d47a9b8ac223628f8e83a", DeliveryAddress = "10, Al Sadd, Doha, Qatar.", OrderStatus = OrderStatus.DeliveryOnTheWay }
            //);
        }
    }
}
