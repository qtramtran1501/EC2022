using System;

#nullable disable

namespace OnlineMarket.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Review1 { get; set; }
        public DateTime? CreateDay { get; set; }
    }
}
