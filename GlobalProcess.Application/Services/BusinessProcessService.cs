using GlobalProcess.Core.Interfaces;
using GlobalProcess.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalProcess.Application.Services
{
    public class BusinessProcessService
    {
        private readonly IRepository<BusinessProcess> _businessProcessRepository;

        public BusinessProcessService(IRepository<BusinessProcess> businessProcessRepository)
        {
            _businessProcessRepository = businessProcessRepository;
        }

        public async Task<IEnumerable<BusinessProcess>> GetAllBusinessProcessesAsync()
        {
            try
            {
                return await _businessProcessRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving all business processes.");
                throw;
            }
        }

        public async Task<BusinessProcess> GetBusinessProcessByIdAsync(int id)
        {
            try
            {
                return await _businessProcessRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving business process with ID {id}.");
                throw;
            }
        }

        public async Task AddBusinessProcessAsync(BusinessProcess businessProcess)
        {
            try
            {
                await _businessProcessRepository.AddAsync(businessProcess);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding business process.");
                throw;
            }
        }

        public async Task UpdateBusinessProcessAsync(BusinessProcess businessProcess)
        {
            try
            {
                await _businessProcessRepository.UpdateAsync(businessProcess);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error updating business process with ID {businessProcess.Id}.");
                throw;
            }
        }

        public async Task DeleteBusinessProcessAsync(int id)
        {
            try
            {
                await _businessProcessRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error deleting business process with ID {id}.");
                throw;
            }
        }
    }
}
