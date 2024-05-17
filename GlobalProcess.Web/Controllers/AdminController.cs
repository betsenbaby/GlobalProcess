using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalProcess.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<BusinessProcess> _processRepository;
        private readonly IRepository<Workflow> _workflowRepository;
        private readonly IRepository<Step> _stepRepository;
        private readonly IRepository<DynamicForm> _formRepository;
        private readonly IRepository<DynamicField> _fieldRepository;
        private readonly IRepository<FieldPermissions> _fieldPermissionsRepository;

        public AdminController(
            IRepository<BusinessProcess> processRepository,
            IRepository<Workflow> workflowRepository,
            IRepository<Step> stepRepository,
            IRepository<DynamicForm> formRepository,
            IRepository<DynamicField> fieldRepository,
            IRepository<FieldPermissions> fieldPermissionsRepository)
        {
            _processRepository = processRepository;
            _workflowRepository = workflowRepository;
            _stepRepository = stepRepository;
            _formRepository = formRepository;
            _fieldRepository = fieldRepository;
            _fieldPermissionsRepository = fieldPermissionsRepository;
        }

        public async Task<IActionResult> CreateBusinessProcess()
        {
            var form = new DynamicForm
            {
                Name = "Correspondence Form",
                Fields = new List<DynamicField>
            {
                new DynamicField { Name = "ReferenceNumber", Label = "Reference Number", FieldType = "Text", IsRequired = true },
                new DynamicField { Name = "LetterDate", Label = "Letter Date", FieldType = "Date", IsRequired = true },
                new DynamicField { Name = "ReceivedFrom", Label = "Received From", FieldType = "Text", IsRequired = true },
                // Add other fields as necessary
            }
            };

            await _formRepository.AddAsync(form);

            var process = new BusinessProcess
            {
                Name = "Correspondence Handling",
                Description = "Process for handling incoming and outgoing correspondences",
                Workflows = new List<Workflow>
            {
                new Workflow
                {
                    Name = "Correspondence Workflow",
                    Description = "Workflow for handling correspondences",
                    Steps = new List<Step>
                    {
                        new Step
                        {
                            Name = "Initial Step",
                            Description = "Collect initial data",
                            FormId = form.Id,
                            FieldPermissions = new List<FieldPermissions>
                            {
                                new FieldPermissions { FieldId = form.Fields.First(f => f.Name == "ReferenceNumber").Id, IsVisible = true, IsEditable = true },
                                new FieldPermissions { FieldId = form.Fields.First(f => f.Name == "LetterDate").Id, IsVisible = true, IsEditable = true },
                                new FieldPermissions { FieldId = form.Fields.First(f => f.Name == "ReceivedFrom").Id, IsVisible = true, IsEditable = true },
                                // Set permissions for other fields as necessary
                            }
                        },
                        // Define other steps as necessary
                    }
                }
            }
            };

            await _processRepository.AddAsync(process);
            return Ok();
        }
    }

}
