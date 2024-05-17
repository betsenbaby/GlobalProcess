using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class Workflow : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
        public ICollection<Step> Steps { get; set; }
    }

}
