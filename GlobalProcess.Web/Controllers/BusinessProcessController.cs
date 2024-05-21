using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using GlobalProcess.Core.ViewModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace GlobalProcess.Web.Controllers
{
    [Authorize]
    public class BusinessProcessController : Controller
    {
        private readonly BusinessProcessService _businessProcessService;
        private readonly IMapper _mapper;

        public BusinessProcessController(BusinessProcessService businessProcessService, IMapper mapper)
        {
            _businessProcessService = businessProcessService;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(BusinessProcessEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var businessProcess = _mapper.Map<BusinessProcessEditModel, BusinessProcess>(model);
                    businessProcess.CreatedByUserId = User.Identity.Name;
                    businessProcess.CreatedDateTime = DateTime.Now;
                    businessProcess.LastModifiedByUserId = User.Identity.Name;
                    businessProcess.LastModifiedDateTime = DateTime.Now;

                    await _businessProcessService.AddBusinessProcessAsync(businessProcess);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error creating business process.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(model);
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
                var model = businessProcess.Adapt<BusinessProcessEditModel>();
                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving business process with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BusinessProcessEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing entity from the database
                    var existingBusinessProcess = await _businessProcessService.GetBusinessProcessByIdAsync(model.Id);

                    if (existingBusinessProcess == null)
                    {
                        return NotFound();
                    }

                    // Map the updated values from the model to the existing entity
                    _mapper.Map(model, existingBusinessProcess);

                    // Set required properties
                    existingBusinessProcess.LastModifiedByUserId = User.Identity.Name;
                    existingBusinessProcess.LastModifiedDateTime = DateTime.Now;

                    // Update the entity in the database
                    await _businessProcessService.UpdateBusinessProcessAsync(existingBusinessProcess);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating business process with ID {model.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(model);
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
