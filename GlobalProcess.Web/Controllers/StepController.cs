
using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
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
            var steps = await _stepService.GetStepsByWorkflowIdAsync(workflowId);
            ViewBag.WorkflowId = workflowId;
            return View(steps);
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
                await _stepService.AddStepAsync(step);
                return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
            }
            ViewBag.WorkflowId = step.WorkflowId;
            return View(step);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var step = await _stepService.GetStepByIdAsync(id);
            if (step == null)
            {
                return NotFound();
            }
            return View(step);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Step step)
        {
            if (ModelState.IsValid)
            {
                await _stepService.UpdateStepAsync(step);
                return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
            }
            return View(step);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var step = await _stepService.GetStepByIdAsync(id);
            if (step == null)
            {
                return NotFound();
            }
            return View(step);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var step = await _stepService.GetStepByIdAsync(id);
            if (step != null)
            {
                await _stepService.DeleteStepAsync(id);
                return RedirectToAction(nameof(Index), new { workflowId = step.WorkflowId });
            }
            return NotFound();
        }

        public async Task<IActionResult> FieldPermissions(int stepId)
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
                await _stepService.AddFieldPermissionAsync(permission);
                return RedirectToAction(nameof(FieldPermissions), new { stepId = permission.StepId });
            }
            ViewBag.StepId = permission.StepId;
            return View(permission);
        }

        public async Task<IActionResult> UserGroupPermissions(int stepId)
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
                await _stepService.AddUserGroupPermissionAsync(permission);
                return RedirectToAction(nameof(UserGroupPermissions), new { stepId = permission.StepId });
            }
            ViewBag.StepId = permission.StepId;
            return View(permission);
        }
    }
}
