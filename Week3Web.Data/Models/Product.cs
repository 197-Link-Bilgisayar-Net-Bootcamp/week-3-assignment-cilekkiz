using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Web.Data.Shared;

namespace Week3Web.Data.Models
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //navigation property for Category (1-n)
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        //navigation property for ProductFeature (1-1)
        public ProductFeature ProductFeature { get; set; }

    }
}
