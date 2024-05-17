using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class BusinessProcessInstance : BaseEntity
    {
        public int BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
        public int CurrentStepId { get; set; }
        public Step CurrentStep { get; set; }
        public ICollection<FieldValue> FieldValues { get; set; }
    }

}
