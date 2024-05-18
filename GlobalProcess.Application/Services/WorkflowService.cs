using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Serilog;
using System;
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
            try
            {
                return await _workflowRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving all workflows.");
                throw;
            }
        }

        public async Task<Workflow> GetWorkflowByIdAsync(int id)
        {
            try
            {
                return await _workflowRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving workflow with ID {id}.");
                throw;
            }
        }

        public async Task AddWorkflowAsync(Workflow workflow)
        {
            try
            {
                await _workflowRepository.AddAsync(workflow);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding workflow.");
                throw;
            }
        }

        public async Task UpdateWorkflowAsync(Workflow workflow)
        {
            try
            {
                await _workflowRepository.UpdateAsync(workflow);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating workflow with ID {workflow.Id}.");
                throw;
            }
        }

        public async Task DeleteWorkflowAsync(int id)
        {
            try
            {
                await _workflowRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting workflow with ID {id}.");
                throw;
            }
        }

        // Step methods
        public async Task<IEnumerable<Step>> GetStepsByWorkflowIdAsync(int workflowId)
        {
            try
            {
                return await _stepRepository.FindAsync(s => s.WorkflowId == workflowId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving steps for workflow ID {workflowId}.");
                throw;
            }
        }

        public async Task<Step> GetStepByIdAsync(int id)
        {
            try
            {
                return await _stepRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving step with ID {id}.");
                throw;
            }
        }

        public async Task AddStepAsync(Step step)
        {
            try
            {
                await _stepRepository.AddAsync(step);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding step.");
                throw;
            }
        }

        public async Task UpdateStepAsync(Step step)
        {
            try
            {
                await _stepRepository.UpdateAsync(step);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating step with ID {step.Id}.");
                throw;
            }
        }

        public async Task DeleteStepAsync(int id)
        {
            try
            {
                await _stepRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting step with ID {id}.");
                throw;
            }
        }

        // ActionItem methods
        public async Task<IEnumerable<ActionItem>> GetActionItemsByStepIdAsync(int stepId)
        {
            try
            {
                return await _actionItemRepository.FindAsync(ai => ai.StepId == stepId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving action items for step ID {stepId}.");
                throw;
            }
        }

        public async Task<ActionItem> GetActionItemByIdAsync(int id)
        {
            try
            {
                return await _actionItemRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving action item with ID {id}.");
                throw;
            }
        }

        public async Task AddActionItemAsync(ActionItem actionItem)
        {
            try
            {
                await _actionItemRepository.AddAsync(actionItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding action item.");
                throw;
            }
        }

        public async Task UpdateActionItemAsync(ActionItem actionItem)
        {
            try
            {
                await _actionItemRepository.UpdateAsync(actionItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating action item with ID {actionItem.Id}.");
                throw;
            }
        }

        public async Task DeleteActionItemAsync(int id)
        {
            try
            {
                await _actionItemRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting action item with ID {id}.");
                throw;
            }
        }
    }
}
