using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class FieldValue : BaseEntity
    {
        public int FormId { get; set; }
        public DynamicForm Form { get; set; }
        public int FieldId { get; set; }
        public DynamicField Field { get; set; }
        public string Value { get; set; }
        public int BusinessProcessInstanceId { get; set; }
        public BusinessProcessInstance BusinessProcessInstance { get; set; }
    }

}
