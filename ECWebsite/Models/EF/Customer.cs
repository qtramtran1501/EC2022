using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [StringLength(255)]
        public string FullName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }
        [StringLength(255)]
        public string Avatar { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [Column("LocationID")]
        public int? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(8)]
        public string Salt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
