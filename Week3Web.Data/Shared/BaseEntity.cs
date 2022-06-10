using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Web.Data.Shared
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}
