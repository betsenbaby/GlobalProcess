using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class Step : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StepTypeId { get; set; }
        public StepType StepType { get; set; }
        public int WorkflowId { get; set; }
        public Workflow Workflow { get; set; }
        public int FormId { get; set; }
        public DynamicForm Form { get; set; }
        public ICollection<FieldPermissions> FieldPermissions { get; set; }
        public ICollection<UserGroupPermission> Permissions { get; set; }
    }
}
