using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Web.Service.DTOs
{
    public class CategoryUpdateDTO
    {
        public string Name { get; set; }
        public List<Guid> ProductIds { get; set; }
    }
}
