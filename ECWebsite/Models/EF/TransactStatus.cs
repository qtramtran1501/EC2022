using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    [Table("TransactStatus")]
    public partial class TransactStatus
    {
        public TransactStatus()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("TransactStatusID")]
        public int TransactStatusId { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(Order.TransactStatus))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
