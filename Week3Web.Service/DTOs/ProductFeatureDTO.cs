using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Web.Data.DTOs
{
    public class ProductFeatureDTO
    {
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ProductDTO Product { get; set; }
    }
}
