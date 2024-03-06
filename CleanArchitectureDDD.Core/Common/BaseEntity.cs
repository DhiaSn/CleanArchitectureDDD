using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.Core.Common
{
    public class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
