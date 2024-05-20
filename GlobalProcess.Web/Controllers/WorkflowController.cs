using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
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
            try
            {
                var workflows = await _workflowService.GetAllWorkflowsAsync();
                return View(workflows);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving workflows.");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.BusinessProcesses = new SelectList(await _workflowService.GetAllBusinessProcessesAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _workflowService.AddWorkflowAsync(workflow);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error creating workflow.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.BusinessProcesses = new SelectList(await _workflowService.GetAllBusinessProcessesAsync(), "Id", "Name");
            return View(workflow);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var workflow = await _workflowService.GetWorkflowByIdAsync(id);
                if (workflow == null)
                {
                    return NotFound();
                }
                ViewBag.BusinessProcesses = new SelectList(await _workflowService.GetAllBusinessProcessesAsync(), "Id", "Name", workflow.BusinessProcessId);
                return View(workflow);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving workflow with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _workflowService.UpdateWorkflowAsync(workflow);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating workflow with ID {workflow.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.BusinessProcesses = new SelectList(await _workflowService.GetAllBusinessProcessesAsync(), "Id", "Name", workflow.BusinessProcessId);
            return View(workflow);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var workflow = await _workflowService.GetWorkflowByIdAsync(id);
                if (workflow == null)
                {
                    return NotFound();
                }
                return View(workflow);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving workflow with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _workflowService.DeleteWorkflowAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting workflow with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
