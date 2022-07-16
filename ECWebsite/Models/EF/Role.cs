using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(Account.Role))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
