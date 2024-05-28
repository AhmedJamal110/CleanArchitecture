using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IImageRepo
    {

        Task AddImageAsync(Image image);
        Task UpdateImageAsync(Image image);
        Task DeleteImageAsync(Image image);

        Task<Image> GetImageByIdAsync(int id);
        Task<IReadOnlyList<Image>> GetAllImageAsync();

    }
}
