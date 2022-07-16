using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Shipper
    {
        [Key]
        [Column("ShipperID")]
        public int ShipperId { get; set; }
        [StringLength(150)]
        public string ShipperName { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        [StringLength(150)]
        public string Company { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
    }
}
