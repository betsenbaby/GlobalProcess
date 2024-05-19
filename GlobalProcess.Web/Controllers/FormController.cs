using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GlobalProcess.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly FormService _formService;

        public FormController(FormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            var forms = await _formService.GetAllFormsAsync();
            return View(forms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DynamicForm form)
        {
            if (ModelState.IsValid)
            {
                await _formService.AddFormAsync(form);
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var form = await _formService.GetFormByIdAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DynamicForm form)
        {
            if (ModelState.IsValid)
            {
                await _formService.UpdateFormAsync(form);
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var form = await _formService.GetFormByIdAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _formService.DeleteFormAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddField(int formId)
        {
            var form = await _formService.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound();
            }
            ViewBag.FormId = formId;
            return View(new DynamicField { FormId = formId }); // Set the FormId
        }

        [HttpPost]
        public async Task<IActionResult> AddField(DynamicField field)
        {
            if (ModelState.IsValid)
            {
                await _formService.AddFieldToFormAsync(field.FormId, field);
                return RedirectToAction(nameof(Edit), new { id = field.FormId });
            }
            ViewBag.FormId = field.FormId;
            return View(field);
        }
    }
}
