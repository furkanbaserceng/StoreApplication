using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}
