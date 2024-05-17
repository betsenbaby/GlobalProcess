using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalProcess.Application.Services
{
    public class WorkflowService
    {
        private readonly IRepository<Workflow> _workflowRepository;
        private readonly IRepository<Step> _stepRepository;
        private readonly IRepository<ActionItem> _actionItemRepository;

        public WorkflowService(IRepository<Workflow> workflowRepository, IRepository<Step> stepRepository, IRepository<ActionItem> actionItemRepository)
        {
            _workflowRepository = workflowRepository;
            _stepRepository = stepRepository;
            _actionItemRepository = actionItemRepository;
        }

        public async Task<IEnumerable<Workflow>> GetAllWorkflowsAsync()
        {
            return await _workflowRepository.GetAllAsync();
        }

        public async Task<Workflow> GetWorkflowByIdAsync(int id)
        {
            return await _workflowRepository.GetByIdAsync(id);
        }

        public async Task AddWorkflowAsync(Workflow workflow)
        {
            await _workflowRepository.AddAsync(workflow);
        }

        public async Task UpdateWorkflowAsync(Workflow workflow)
        {
            await _workflowRepository.UpdateAsync(workflow);
        }

        public async Task DeleteWorkflowAsync(int id)
        {
            await _workflowRepository.DeleteAsync(id);
        }

        // Step methods
        public async Task<IEnumerable<Step>> GetStepsByWorkflowIdAsync(int workflowId)
        {
            return await _stepRepository.FindAsync(s => s.WorkflowId == workflowId);
        }

        public async Task<Step> GetStepByIdAsync(int id)
        {
            return await _stepRepository.GetByIdAsync(id);
        }

        public async Task AddStepAsync(Step step)
        {
            await _stepRepository.AddAsync(step);
        }

        public async Task UpdateStepAsync(Step step)
        {
            await _stepRepository.UpdateAsync(step);
        }

        public async Task DeleteStepAsync(int id)
        {
            await _stepRepository.DeleteAsync(id);
        }

        // ActionItem methods
        public async Task<IEnumerable<ActionItem>> GetActionItemsByStepIdAsync(int stepId)
        {
            return await _actionItemRepository.FindAsync(ai => ai.StepId == stepId);
        }

        public async Task<ActionItem> GetActionItemByIdAsync(int id)
        {
            return await _actionItemRepository.GetByIdAsync(id);
        }

        public async Task AddActionItemAsync(ActionItem actionItem)
        {
            await _actionItemRepository.AddAsync(actionItem);
        }

        public async Task UpdateActionItemAsync(ActionItem actionItem)
        {
            await _actionItemRepository.UpdateAsync(actionItem);
        }

        public async Task DeleteActionItemAsync(int id)
        {
            await _actionItemRepository.DeleteAsync(id);
        }
    }
}
