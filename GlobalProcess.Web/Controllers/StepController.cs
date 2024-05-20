using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace GlobalProcess.Web.Controllers
{
    public class StepController : Controller
    {
        private readonly StepService _stepService;

        public StepController(StepService stepService)
        {
            _stepService = stepService;
        }

        public async Task<IActionResult> Index(int workflowId)
        {
            try
            {
                var steps = await _stepService.GetStepsByWorkflowIdAsync(workflowId);
                ViewBag.WorkflowId = workflowId;
                return View(steps);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving steps for workflow ID {workflowId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult Create(int workflowId)
        {
            ViewBag.WorkflowId = workflowId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Step step)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stepService.AddStepAsync(step);
                    return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error creating step for workflow ID {step.WorkflowId}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.WorkflowId = step.WorkflowId;
            return View(step);
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
                return View(step);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving step with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Step step)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stepService.UpdateStepAsync(step);
                    return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating step with ID {step.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(step);
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