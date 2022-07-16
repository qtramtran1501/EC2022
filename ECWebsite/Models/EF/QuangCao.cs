using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class QuangCao
    {
        [Key]
        [Column("QuangCaoID")]
        public int QuangCaoId { get; set; }
        [StringLength(150)]
        public string SubTitle { get; set; }
        [StringLength(150)]
        public string Title { get; set; }
        [Column("ImageBG")]
        [StringLength(250)]
        public string ImageBg { get; set; }
        [StringLength(250)]
        public string ImageProduct { get; set; }
        [StringLength(250)]
        public string UrlLink { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
