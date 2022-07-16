using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Location
    {
        [Key]
        [Column("LocationID")]
        public int LocationId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? Parent { get; set; }
        public int? Levels { get; set; }
        [StringLength(100)]
        public string Slug { get; set; }
        [StringLength(100)]
        public string NameWithType { get; set; }
        [StringLength(10)]
        public string Type { get; set; }
    }
}
