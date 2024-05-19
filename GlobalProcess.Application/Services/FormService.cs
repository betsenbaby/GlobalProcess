using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalProcess.Application.Services
{
    public class FormService
    {
        private readonly IRepository<DynamicForm> _formRepository;

        public FormService(IRepository<DynamicForm> formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<IEnumerable<DynamicForm>> GetAllFormsAsync()
        {
            try
            {
                return await _formRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving all forms.");
                throw;
            }
        }

        public async Task<DynamicForm> GetFormByIdAsync(int id)
        {
            try
            {
                return await _formRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving form with ID {id}.");
                throw;
            }
        }

        public async Task AddFormAsync(DynamicForm form)
        {
            try
            {
                await _formRepository.AddAsync(form);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding form.");
                throw;
            }
        }

        public async Task UpdateFormAsync(DynamicForm form)
        {
            try
            {
                await _formRepository.UpdateAsync(form);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating form with ID {form.Id}.");
                throw;
            }
        }

        public async Task DeleteFormAsync(int id)
        {
            try
            {
                await _formRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting form with ID {id}.");
                throw;
            }
        }

        public async Task AddFieldToFormAsync(int formId, DynamicField field)
        {
            try
            {
                var form = await _formRepository.GetByIdAsync(formId);
                if (form != null)
                {
                    field.FormId = formId; // Set the FormId
                    form.Fields.Add(field);
                    await _formRepository.UpdateAsync(form);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error adding field to form with ID {formId}.");
                throw;
            }
        }

    }
}
