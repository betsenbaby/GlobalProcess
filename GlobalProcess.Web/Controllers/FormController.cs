using GlobalProcess.Application.Services;
using GlobalProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
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
            try
            {
                var forms = await _formService.GetAllFormsAsync();
                return View(forms);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving forms.");
                return StatusCode(500, "Internal server error");
            }
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
                try
                {
                    await _formService.AddFormAsync(form);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error creating form.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(form);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var form = await _formService.GetFormByIdAsync(id);
                if (form == null)
                {
                    return NotFound();
                }
                return View(form);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving form with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DynamicForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _formService.UpdateFormAsync(form);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating form with ID {form.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(form);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var form = await _formService.GetFormByIdAsync(id);
                if (form == null)
                {
                    return NotFound();
                }
                return View(form);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving form with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _formService.DeleteFormAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting form with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> AddField(int formId)
        {
            try
            {
                var form = await _formService.GetFormByIdAsync(formId);
                if (form == null)
                {
                    return NotFound();
                }
                ViewBag.FormId = formId;
                return View(new DynamicField { FormId = formId });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving form with ID {formId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddField(DynamicField field)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _formService.AddFieldToFormAsync(field.FormId, field);
                    return RedirectToAction(nameof(Edit), new { id = field.FormId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error adding field to form with ID {field.FormId}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            ViewBag.FormId = field.FormId;
            return View(field);
        }

        public async Task<IActionResult> EditField(int fieldId)
        {
            try
            {
                var field = await _formService.GetFieldByIdAsync(fieldId);
                if (field == null)
                {
                    return NotFound();
                }
                return View(field);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field with ID {fieldId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditField(DynamicField field)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _formService.UpdateFieldAsync(field);
                    return RedirectToAction(nameof(Edit), new { id = field.FormId });
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error updating field with ID {field.Id}.");
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(field);
        }

        public async Task<IActionResult> DeleteField(int fieldId)
        {
            try
            {
                var field = await _formService.GetFieldByIdAsync(fieldId);
                if (field == null)
                {
                    return NotFound();
                }
                return View(field);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving field with ID {fieldId}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, ActionName("DeleteField")]
        public async Task<IActionResult> DeleteFieldConfirmed(int fieldId)
        {
            try
            {
                var field = await _formService.GetFieldByIdAsync(fieldId);
                if (field != null)
                {
                    await _formService.DeleteFieldAsync(fieldId);
                    return RedirectToAction(nameof(Edit), new { id = field.FormId });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting field with ID {fieldId}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
