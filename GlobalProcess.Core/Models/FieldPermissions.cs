using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class FieldPermissions : BaseEntity
    {
        public int StepId { get; set; }
        public Step Step { get; set; }
        public int FieldId { get; set; }
        public DynamicField Field { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEditable { get; set; }
    }

}
