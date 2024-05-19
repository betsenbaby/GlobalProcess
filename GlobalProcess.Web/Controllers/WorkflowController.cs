using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GlobalProcess.Web.Controllers
{
    public class WorkflowController : Controller
    {
        private readonly WorkflowService _workflowService;

        public WorkflowController(WorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<IActionResult> Index()
        {
            var workflows = await _workflowService.GetAllWorkflowsAsync();
            return View(workflows);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                await _workflowService.AddWorkflowAsync(workflow);
                return RedirectToAction(nameof(Index));
            }
            return View(workflow);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var workflow = await _workflowService.GetWorkflowByIdAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }
            return View(workflow);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                await _workflowService.UpdateWorkflowAsync(workflow);
                return RedirectToAction(nameof(Index));
            }
            return View(workflow);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var workflow = await _workflowService.GetWorkflowByIdAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }
            return View(workflow);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _workflowService.DeleteWorkflowAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
