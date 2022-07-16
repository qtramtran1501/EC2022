using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
        }

        [Key]
        [Column("AttributeID")]
        public int AttributeId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(AttributesPrice.Attribute))]
        public virtual ICollection<AttributesPrice> AttributesPrices { get; set; }
    }
}
