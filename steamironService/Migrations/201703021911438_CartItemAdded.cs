namespace steamironService.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CartItemAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductItems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.ProductItems", new[] { "Cart_Id" });
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        Count = c.Int(nullable: false),
                        ProductId = c.String(maxLength: 128),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                        Cart_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductItems", t => t.ProductId)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.ProductId)
                .Index(t => t.CreatedAt, clustered: true)
                .Index(t => t.Cart_Id);
            
            DropColumn("dbo.Carts", "Count");
            DropColumn("dbo.ProductItems", "Cart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductItems", "Cart_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Carts", "Count", c => c.Int(nullable: false));
            DropForeignKey("dbo.CartItems", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.ProductItems");
            DropIndex("dbo.CartItems", new[] { "Cart_Id" });
            DropIndex("dbo.CartItems", new[] { "CreatedAt" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropTable("dbo.CartItems",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
            CreateIndex("dbo.ProductItems", "Cart_Id");
            AddForeignKey("dbo.ProductItems", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
