using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using steamironService.DataObjects;

namespace steamironService.Models
{
    public class steamironContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public steamironContext() : base(connectionStringName)
        {
        } 

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }

}
