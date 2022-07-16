using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class AttributesPrice
    {
        [Key]
        [Column("AttributesPriceID")]
        public int AttributesPriceId { get; set; }
        [Column("AttributeID")]
        public int? AttributeId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(AttributeId))]
        [InverseProperty("AttributesPrices")]
        public virtual Attribute Attribute { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("AttributesPrices")]
        public virtual Product Product { get; set; }
    }
}
