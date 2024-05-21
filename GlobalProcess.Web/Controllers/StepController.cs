using GlobalProcess.Application.Services;
using GlobalProcess.Application.ViewModels;
using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
using System.Threading.Tasks;

namespace GlobalProcess.Web.Controllers
{
    public class StepController : Controller
    {
        private readonly StepService _stepService;
        private readonly IRepository<StepType> _stepTypeRepository;

        public StepController(StepService stepService, IRepository<StepType> stepTypeRepository)
        {
            _stepService = stepService;
            _stepTypeRepository = stepTypeRepository;
        }

        private async Task PopulateStepTypes()
        {
            ViewBag.StepTypes = (await _stepTypeRepository.GetAllAsync())
                .Select(st => new SelectListItem
                {
                    Text = st.Name,
                    Value = st.Id.ToString()
                }).ToList();
        }

        public async Task<IActionResult> Create(int workflowId)
        {
            await PopulateStepTypes();
            ViewBag.WorkflowId = workflowId;
            return View(new StepViewModel { WorkflowId = workflowId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(StepViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var step = model.Adapt<Step>();
                    step.CreatedByUserId = User.Identity.Name;
                    step.CreatedDateTime = DateTime.Now;
                    step.LastModifiedByUserId = User.Identity.Name;
                    step.LastModifiedDateTime = DateTime.Now;

                    await _stepService.AddStepAsync(step);
                    return RedirectToAction(nameof(Index), new { workflowId = model.WorkflowId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error creating step for workflow ID {model.WorkflowId}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            await PopulateStepTypes();
            ViewBag.WorkflowId = model.WorkflowId;
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var step = await _stepService.GetStepByIdAsync(id);
                if (step == null)
                {
                    return NotFound();
                }
                await PopulateStepTypes();
                return View(step.Adapt<StepViewModel>());
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving step with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StepViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var step = model.Adapt<Step>();
                    step.LastModifiedByUserId = User.Identity.Name;
                    step.LastModifiedDateTime = DateTime.Now;
                    await _stepService.UpdateStepAsync(step);
                    return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating step with ID {model.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            await PopulateStepTypes();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var step = await _stepService.GetStepByIdAsync(id);
                if (step == null)
                {
                    return NotFound();
                }
                return View(step);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving step with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var step = await _stepService.GetStepByIdAsync(id);
                if (step != null)
                {
                    await _stepService.DeleteStepAsync(id);
                    return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting step with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> FieldPermissions(int stepId)
        {
            try
            {
                var step = await _stepService.GetStepByIdAsync(stepId);
                if (step == null)
                {
                    return NotFound();
                }
                var fieldPermissions = await _stepService.GetFieldPermissionsByStepIdAsync(stepId);
                ViewBag.StepId = stepId;
                return View(fieldPermissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field permissions for step ID {stepId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult AddFieldPermission(int stepId)
        {
            ViewBag.StepId = stepId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFieldPermission(FieldPermissions permission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stepService.AddFieldPermissionAsync(permission);
                    return RedirectToAction(nameof(FieldPermissions), new { stepId = permission.StepId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error adding field permission for step ID {permission.StepId}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.StepId = permission.StepId;
            return View(permission);
        }

        public async Task<IActionResult> EditFieldPermission(int id)
        {
            try
            {
                var fieldPermission = await _stepService.GetFieldPermissionByIdAsync(id);
                if (fieldPermission == null)
                {
                    return NotFound();
                }
                ViewBag.StepId = fieldPermission.StepId;
                return View(fieldPermission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field permission with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditFieldPermission(FieldPermissions permission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stepService.UpdateFieldPermissionAsync(permission);
                    return RedirectToAction(nameof(FieldPermissions), new { stepId = permission.StepId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating field permission with ID {permission.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.StepId = permission.StepId;
            return View(permission);
        }

        public async Task<IActionResult> DeleteFieldPermission(int id)
        {
            try
            {
                var fieldPermission = await _stepService.GetFieldPermissionByIdAsync(id);
                if (fieldPermission == null)
                {
                    return NotFound();
                }
                return View(fieldPermission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field permission with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("DeleteFieldPermission")]
        public async Task<IActionResult> DeleteFieldPermissionConfirmed(int id)
        {
            try
            {
                var fieldPermission = await _stepService.GetFieldPermissionByIdAsync(id);
                if (fieldPermission != null)
                {
                    await _stepService.DeleteFieldPermissionAsync(id);
                    return RedirectToAction(nameof(FieldPermissions), new { stepId = fieldPermission.StepId });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting field permission with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> UserGroupPermissions(int stepId)
        {
            try
            {
                var step = await _stepService.GetStepByIdAsync(stepId);
                if (step == null)
                {
                    return NotFound();
                }
                var userGroupPermissions = await _stepService.GetUserGroupPermissionsByStepIdAsync(stepId);
                ViewBag.StepId = stepId;
                return View(userGroupPermissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving user group permissions for step ID {stepId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult AddUserGroupPermission(int stepId)
        {
            ViewBag.StepId = stepId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserGroupPermission(UserGroupPermission permission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stepService.AddUserGroupPermissionAsync(permission);
                    return RedirectToAction(nameof(UserGroupPermissions), new { stepId = permission.StepId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error adding user group permission for step ID {permission.StepId}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.StepId = permission.StepId;
            return View(permission);
        }

        public async Task<IActionResult> EditUserGroupPermission(int id)
        {
            try
            {
                var userGroupPermission = await _stepService.GetUserGroupPermissionByIdAsync(id);
                if (userGroupPermission == null)
                {
                    return NotFound();
                }
                ViewBag.StepId = userGroupPermission.StepId;
                return View(userGroupPermission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving user group permission with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUserGroupPermission(UserGroupPermission permission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stepService.UpdateUserGroupPermissionAsync(permission);
                    return RedirectToAction(nameof(UserGroupPermissions), new { stepId = permission.StepId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating user group permission with ID {permission.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.StepId = permission.StepId;
            return View(permission);
        }

        public async Task<IActionResult> DeleteUserGroupPermission(int id)
        {
            try
            {
                var userGroupPermission = await _stepService.GetUserGroupPermissionByIdAsync(id);
                if (userGroupPermission == null)
                {
                    return NotFound();
                }
                return View(userGroupPermission);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving user group permission with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("DeleteUserGroupPermission")]
        public async Task<IActionResult> DeleteUserGroupPermissionConfirmed(int id)
        {
            try
            {
                var userGroupPermission = await _stepService.GetUserGroupPermissionByIdAsync(id);
                if (userGroupPermission != null)
                {
                    await _stepService.DeleteUserGroupPermissionAsync(id);
                    return RedirectToAction(nameof(UserGroupPermissions), new { stepId = userGroupPermission.StepId });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting user group permission with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}