using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
