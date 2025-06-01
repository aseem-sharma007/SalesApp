using FluorSalesApp.Models;


namespace FluorSalesApp.Service.Interfaces
{
    public interface ISalesRepService
    {
        Task<IEnumerable<SalesRepresentative>> GetAllAsync(string? platform, string? region);
        Task<SalesRepresentative?> GetByIdAsync(int id);
        Task<SalesRepresentative> CreateAsync(SalesRepresentative rep);
        Task UpdateAsync(SalesRepresentative rep);
        Task DeleteAsync(int id);
    }
}
