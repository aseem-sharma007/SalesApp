using FluorSalesApp.Data;
using FluorSalesApp.Models;
using FluorSalesApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace FluorSalesApp.Repository
{
    public class SalesRepRepository : ISalesRepRepository
    {
        private readonly FluorAppDBContext _context;

        public SalesRepRepository(FluorAppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesRepresentative>> GetAllAsync(string? platform, string? region)
        {
            var query = _context.SalesRepresentatives.AsQueryable();

            if (!string.IsNullOrEmpty(platform))
                query = query.Where(r => r.Platform == platform); 

            if (!string.IsNullOrEmpty(region))
                query = query.Where(r => r.Region == region);

            return await query.ToListAsync();
        }

        public async Task<SalesRepresentative?> GetByIdAsync(int id)
        {
            return await _context.SalesRepresentatives.FindAsync(id);
        }

        public async Task<SalesRepresentative> AddAsync(SalesRepresentative rep)
        {
            _context.SalesRepresentatives.Add(rep);
            await _context.SaveChangesAsync();
            return rep;
        }

        public async Task UpdateAsync(SalesRepresentative rep)
        {
            _context.SalesRepresentatives.Update(rep);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rep = await _context.SalesRepresentatives.FindAsync(id);
            if (rep != null)
            {
                _context.SalesRepresentatives.Remove(rep);
                await _context.SaveChangesAsync();
            }
        }
    }
}
