using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }     
        public DateTime LastModifiedDateTime { get; set; }
        public string LastModifiedByUserId { get; set; }
    }
}
