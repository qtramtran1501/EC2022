using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Product
    {
        public Product()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }
        [StringLength(255)]
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        [Column("CatID")]
        public int? CatId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        [StringLength(255)]
        public string Thumb { get; set; }
        [StringLength(255)]
        public string Video { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
        public bool BestSellers { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Alias { get; set; }
        [StringLength(255)]
        public string MetaDesc { get; set; }
        [StringLength(255)]
        public string MetaKey { get; set; }
        public int? UnitsInStock { get; set; }

        [ForeignKey(nameof(CatId))]
        [InverseProperty(nameof(Category.Products))]
        public virtual Category Cat { get; set; }
        [InverseProperty(nameof(AttributesPrice.Product))]
        public virtual ICollection<AttributesPrice> AttributesPrices { get; set; }
        [InverseProperty(nameof(OrderDetail.Product))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
