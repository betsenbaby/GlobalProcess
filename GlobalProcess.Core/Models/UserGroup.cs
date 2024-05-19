using System.Collections.Generic;

namespace GlobalProcess.Core.Models
{
    public class UserGroup : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserGroupPermission> UserGroupPermissions { get; set; }
    }
}
