using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProperityRepo
    {
        Task AddAsync(Property property);
        Task UPdateAsync(Property property);
        Task DeleteAsync(Property property);

        Task<IReadOnlyList<Property>> GetAllAsync();

        Task<Property> GetByIdAsync(int id);

    }
}
