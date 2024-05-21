using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class BusinessProcess : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Workflow>? Workflows { get; set; } = new List<Workflow>();
        public ICollection<Comment>? Comments { get; set; }= new List<Comment>();
    }

}
