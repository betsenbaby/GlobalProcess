using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class DynamicForm : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<DynamicField> Fields { get; set; }
    }

}
