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
    public class ImageRepo : IImageRepo
    {
        private readonly ApplicationDbContext _context;

        public ImageRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async  Task AddImageAsync(Image image)
        {

            await _context.Images.AddAsync(image);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Image>> GetAllImageAsync()
         =>  await _context.Images.ToListAsync();
        

        public async Task<Image> GetImageByIdAsync(int id)
        =>  await _context.Images.FindAsync(id);
       
         
        

        public async Task UpdateImageAsync(Image image)
        {
            _context.Images.Update(image);
           await  _context.SaveChangesAsync();
        }
    }


}
