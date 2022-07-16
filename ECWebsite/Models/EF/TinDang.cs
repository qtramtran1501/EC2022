using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class TinDang
    {
        [Key]
        [Column("PostID")]
        public int PostId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [Column("SContents")]
        [StringLength(255)]
        public string Scontents { get; set; }
        public string Contents { get; set; }
        [StringLength(255)]
        public string Thumb { get; set; }
        public bool Published { get; set; }
        [StringLength(255)]
        public string Alias { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        public string Tags { get; set; }
        [Column("CatID")]
        public int? CatId { get; set; }
        [Column("isHot")]
        public bool IsHot { get; set; }
        [Column("isNewfeed")]
        public bool IsNewfeed { get; set; }
        [StringLength(255)]
        public string MetaKey { get; set; }
        [StringLength(255)]
        public string MetaDesc { get; set; }
        public int? Views { get; set; }
    }
}
