using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class UserGroupPermission : BaseEntity
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public int StepId { get; set; }
        public Step Step { get; set; }
        public string Action { get; set; } // e.g., View, Edit, Approve

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
    }
}
