using Application.Repositories;
using Domain.Models;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProperityRepository : IProperityRepo
    {
        private readonly ApplicationDbContext _context;

        public ProperityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async  Task DeleteAsync(Property property)
        {

            _context.Properties.Remove(property);
           await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Property>> GetAllAsync()
        {
            var properities =await  _context.Properties.ToListAsync();
            return properities;

        }

        public async Task<Property> GetByIdAsync(int id)
        {
            var properity = await _context.Properties.FindAsync(id);

            return properity;
        }

        public async Task UPdateAsync(Property property)
        {

             _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }
    }
}
