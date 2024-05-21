using GlobalProcess.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalProcess.Application.ViewModels
{
    public class StepViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StepTypeId { get; set; }
        public int WorkflowId { get; set; }
        public int FormId { get; set; }
    }


}
