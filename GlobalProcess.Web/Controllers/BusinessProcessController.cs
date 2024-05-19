using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
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
            var businessProcesses = await _businessProcessService.GetAllBusinessProcessesAsync();
            return View(businessProcesses);
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
                await _businessProcessService.AddBusinessProcessAsync(businessProcess);
                return RedirectToAction(nameof(Index));
            }
            return View(businessProcess);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var businessProcess = await _businessProcessService.GetBusinessProcessByIdAsync(id);
            if (businessProcess == null)
            {
                return NotFound();
            }
            return View(businessProcess);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BusinessProcess businessProcess)
        {
            if (ModelState.IsValid)
            {
                await _businessProcessService.UpdateBusinessProcessAsync(businessProcess);
                return RedirectToAction(nameof(Index));
            }
            return View(businessProcess);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var businessProcess = await _businessProcessService.GetBusinessProcessByIdAsync(id);
            if (businessProcess == null)
            {
                return NotFound();
            }
            return View(businessProcess);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _businessProcessService.DeleteBusinessProcessAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
