using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Core.Models
{
    public class DynamicField : BaseEntity
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string FieldType { get; set; } // e.g., Text, Date, Dropdown
        public string Options { get; set; } // JSON string for dropdown options
        public bool IsRequired { get; set; }
    }

}
