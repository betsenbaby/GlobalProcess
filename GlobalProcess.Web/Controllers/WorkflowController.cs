using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalProcess.Web.Controllers
{
    public class WorkflowController : Controller
    {
        private readonly ILogger<WorkflowController> _logger;
        private readonly IRepository<BusinessProcessInstance> _instanceRepository;
        private readonly IRepository<Step> _stepRepository;
        private readonly IRepository<DynamicForm> _formRepository;
        private readonly IRepository<FieldValue> _fieldValueRepository;

        public WorkflowController(
            ILogger<WorkflowController> logger,
            IRepository<BusinessProcessInstance> instanceRepository,
            IRepository<Step> stepRepository,
            IRepository<DynamicForm> formRepository,
            IRepository<FieldValue> fieldValueRepository)
        {
            _logger = logger;
            _instanceRepository = instanceRepository;
            _stepRepository = stepRepository;
            _formRepository = formRepository;
            _fieldValueRepository = fieldValueRepository;
        }

        /// <summary>
        /// Executes a step in the workflow.
        /// </summary>
        /// <param name="instanceId">The ID of the business process instance.</param>
        /// <param name="stepId">The ID of the step to execute.</param>
        /// <param name="fieldValues">The values of the dynamic fields.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        public async Task<IActionResult> ExecuteStep(int instanceId, int stepId, Dictionary<string, string> fieldValues)
        {
            try
            {
                var instance = await _instanceRepository.GetByIdAsync(instanceId);
                var step = await _stepRepository.GetByIdAsync(stepId);
                var form = await _formRepository.GetByIdAsync(step.FormId);

                foreach (var kv in fieldValues)
                {
                    var field = form.Fields.First(f => f.Name == kv.Key);
                    var fieldValue = new FieldValue
                    {
                        FormId = form.Id,
                        FieldId = field.Id,
                        Value = kv.Value,
                        BusinessProcessInstanceId = instanceId
                    };

                    await _fieldValueRepository.AddAsync(fieldValue);
                }

                // Perform additional actions, e.g., advance to the next step
                instance.CurrentStepId = GetNextStepId(instance.CurrentStepId); // Implement GetNextStepId method
                await _instanceRepository.UpdateAsync(instance);

                _logger.LogInformation($"Step {stepId} executed successfully for instance {instanceId}.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error executing step {stepId} for instance {instanceId}.");
                return StatusCode(500, "Internal server error");
            }
        }


        private int GetNextStepId(int currentStepId)
        {
            // Logic to determine the next step ID
            // This is a placeholder; you'll need to implement the actual logic based on your workflow definition
            return currentStepId + 1;
        }
    }


}
