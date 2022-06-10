using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Web.Data.Shared;

namespace Week3Web.Data.Models
{
    public class ProductFeature : BaseEntity<Guid>
    {
        public int Width { get; set; }
        public int Height { get; set; }

        //navigation property for Product (1-1)
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
