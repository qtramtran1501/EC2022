using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("CatID")]
        public int CatId { get; set; }
        [StringLength(250)]
        public string CatName { get; set; }
        public string Description { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool Published { get; set; }
        [StringLength(250)]
        public string Thumb { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Alias { get; set; }
        [StringLength(250)]
        public string MetaDesc { get; set; }
        [StringLength(250)]
        public string MetaKey { get; set; }
        [StringLength(255)]
        public string Cover { get; set; }
        public string SchemaMarkup { get; set; }

        [InverseProperty(nameof(Product.Cat))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
