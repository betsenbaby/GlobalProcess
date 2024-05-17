using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? WorkflowId { get; set; }
        public Workflow Workflow { get; set; }
        public int? StepId { get; set; }
        public Step Step { get; set; }
        public int? ActionItemId { get; set; }
        public ActionItem ActionItem { get; set; }
    }
}
