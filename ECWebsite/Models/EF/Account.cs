using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Account
    {
        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(10)]
        public string Salt { get; set; }
        public bool Active { get; set; }
        [StringLength(150)]
        public string FullName { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Accounts")]
        public virtual Role Role { get; set; }
    }
}
