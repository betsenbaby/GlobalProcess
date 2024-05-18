using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; }
        public int? BusinessProcessInstanceId { get; set; }
        public BusinessProcessInstance BusinessProcessInstance { get; set; }
        public int? StepId { get; set; }
        public Step Step { get; set; }
        public int? ActionItemId { get; set; }
        public ActionItem ActionItem { get; set; }
    }

}
