using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace GlobalProcess.Web.Controllers
{
    public class BusinessProcessController : Controller
    {
        private readonly BusinessProcessService _businessProcessService;

        public BusinessProcessController(BusinessProcessService businessProcessService)
        {
            _businessProcessService = businessProcessService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var businessProcesses = await _businessProcessService.GetAllBusinessProcessesAsync();
                return View(businessProcesses);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving business processes.");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusinessProcess businessProcess)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _businessProcessService.AddBusinessProcessAsync(businessProcess);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error creating business process.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(businessProcess);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var businessProcess = await _businessProcessService.GetBusinessProcessByIdAsync(id);
                if (businessProcess == null)
                {
                    return NotFound();
                }
                return View(businessProcess);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving business process with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BusinessProcess businessProcess)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _businessProcessService.UpdateBusinessProcessAsync(businessProcess);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating business process with ID {businessProcess.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(businessProcess);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var businessProcess = await _businessProcessService.GetBusinessProcessByIdAsync(id);
                if (businessProcess == null)
                {
                    return NotFound();
                }
                return View(businessProcess);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving business process with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _businessProcessService.DeleteBusinessProcessAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting business process with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
