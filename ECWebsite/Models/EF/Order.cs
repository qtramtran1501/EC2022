using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECWebsite.Models.EF
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        [Column("TransactStatusID")]
        public int TransactStatusId { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        public int TotalMoney { get; set; }
        [Column("PaymentID")]
        public int? PaymentId { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        [Column("LocationID")]
        public int? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(TransactStatusId))]
        [InverseProperty("Orders")]
        public virtual TransactStatus TransactStatus { get; set; }
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
