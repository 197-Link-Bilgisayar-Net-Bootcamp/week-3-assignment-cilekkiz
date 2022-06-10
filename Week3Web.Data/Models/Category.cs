using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Web.Data.Shared;

namespace Week3Web.Data.Models
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }

        //navigation property for Product (1-n)
        public List<Product> Products { get; set; }
    }
}
