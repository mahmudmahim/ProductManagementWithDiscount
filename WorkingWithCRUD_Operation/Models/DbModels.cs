using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkingWithCRUD_Operation.Models
{
    public class Product
    {
        // [Key] //if we don't mention the entity id as productID or id then we need to define this key;
        //so that it understand it as a primary key
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //it use for identity the id property

        [Display(Name ="Product ID")]
        public int ProductId { get; set; }

        [Required, StringLength(40, ErrorMessage = "Invalid String Length"), Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required,Column(TypeName ="money"),Display(Name ="Unit Price"),DisplayFormat(DataFormatString="{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal UnitPrice { get; set; }

        [Required,Column(TypeName = "money"),Display(Name = "Discount Rate"),DisplayFormat(DataFormatString ="{0:0.00}",ApplyFormatInEditMode = true)]
        public decimal Discount { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
    }
}