using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Data.Models
{
    public class ProductDetails
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public int Cost { get; set; }
        public int StockCount { get; set; }
    }
}
