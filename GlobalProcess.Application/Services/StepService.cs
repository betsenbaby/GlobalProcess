using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalProcess.Application.Services
{
    public class StepService
    {
        private readonly IRepository<Step> _stepRepository;
        private readonly IRepository<FieldPermissions> _fieldPermissionsRepository;
        private readonly IRepository<UserGroupPermission> _userGroupPermissionRepository;

        public StepService(
            IRepository<Step> stepRepository,
            IRepository<FieldPermissions> fieldPermissionsRepository,
            IRepository<UserGroupPermission> userGroupPermissionRepository)
        {
            _stepRepository = stepRepository;
            _fieldPermissionsRepository = fieldPermissionsRepository;
            _userGroupPermissionRepository = userGroupPermissionRepository;
        }

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

        public async Task<IEnumerable<FieldPermissions>> GetFieldPermissionsByStepIdAsync(int stepId)
        {
            try
            {
                return await _fieldPermissionsRepository.FindAsync(fp => fp.StepId == stepId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field permissions for step ID {stepId}.");
                throw;
            }
        }

        public async Task<FieldPermissions> GetFieldPermissionByIdAsync(int id)
        {
            try
            {
                return await _fieldPermissionsRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field permission with ID {id}.");
                throw;
            }
        }

        public async Task AddFieldPermissionAsync(FieldPermissions permission)
        {
            try
            {
                await _fieldPermissionsRepository.AddAsync(permission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding field permission.");
                throw;
            }
        }

        public async Task UpdateFieldPermissionAsync(FieldPermissions permission)
        {
            try
            {
                await _fieldPermissionsRepository.UpdateAsync(permission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating field permission with ID {permission.Id}.");
                throw;
            }
        }

        public async Task DeleteFieldPermissionAsync(int id)
        {
            try
            {
                await _fieldPermissionsRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting field permission with ID {id}.");
                throw;
            }
        }

        public async Task<IEnumerable<UserGroupPermission>> GetUserGroupPermissionsByStepIdAsync(int stepId)
        {
            try
            {
                return await _userGroupPermissionRepository.FindAsync(ugp => ugp.StepId == stepId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving user group permissions for step ID {stepId}.");
                throw;
            }
        }

        public async Task<UserGroupPermission> GetUserGroupPermissionByIdAsync(int id)
        {
            try
            {
                return await _userGroupPermissionRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving user group permission with ID {id}.");
                throw;
            }
        }

        public async Task AddUserGroupPermissionAsync(UserGroupPermission permission)
        {
            try
            {
                await _userGroupPermissionRepository.AddAsync(permission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding user group permission.");
                throw;
            }
        }

        public async Task UpdateUserGroupPermissionAsync(UserGroupPermission permission)
        {
            try
            {
                await _userGroupPermissionRepository.UpdateAsync(permission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating user group permission with ID {permission.Id}.");
                throw;
            }
        }

        public async Task DeleteUserGroupPermissionAsync(int id)
        {
            try
            {
                await _userGroupPermissionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting user group permission with ID {id}.");
                throw;
            }
        }
    }
}
