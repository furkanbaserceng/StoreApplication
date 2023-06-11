﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage ="name is required!")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Line 1 is required!")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();



    }
}
