using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluorSalesApp.Models;

namespace FluorSalesApp.Repository.Interfaces
{
    public interface ISalesRepRepository
    {
        Task<IEnumerable<SalesRepresentative>> GetAllAsync(string? platform, string? region);
        Task<SalesRepresentative?> GetByIdAsync(int id);
        Task<SalesRepresentative> AddAsync(SalesRepresentative rep);
        Task UpdateAsync(SalesRepresentative rep);
        Task DeleteAsync(int id);
    }
}
