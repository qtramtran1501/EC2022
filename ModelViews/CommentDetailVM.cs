using OnlineMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.ModelViews
{
    public class CommentDetailVM
    {
        public Product product { get; set; }
        public List<Comment> lscomments { get; set; }
    }
}
