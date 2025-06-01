using FluorSalesApp.Models;
using FluorSalesApp.Repository;
using FluorSalesApp.Repository.Interfaces;
using FluorSalesApp.Service.Interfaces;

namespace FluorSalesApp.Service
{
    public class SalesRepService : ISalesRepService
    {
        private readonly ISalesRepRepository _repository;

        public SalesRepService(ISalesRepRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalesRepresentative>> GetAllAsync(string? platform, string? region)
        {
            return await _repository.GetAllAsync(platform, region);
        }

        public Task<SalesRepresentative?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<SalesRepresentative> CreateAsync(SalesRepresentative rep) => _repository.AddAsync(rep);

        public Task UpdateAsync(SalesRepresentative rep) => _repository.UpdateAsync(rep);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
