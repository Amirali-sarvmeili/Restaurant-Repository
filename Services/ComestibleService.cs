using crud.DbContext;
using crud.Dtos;
using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Services
{
    public class ComestibleService : IComestibleService
    {
        private readonly AppDbContext _context;

        public ComestibleService(AppDbContext context)
        {
            _context = context;
        }

        public override async Task<List<ComestibleDto>> GetAllAsync()
        {
            return await _context.Comestibles
                .Include(c => c.Category)
                .Select(c => new ComestibleDto
                {
                    Name = c.Name,
                    Description = c.Description,
                    CategoryName = c.CategoryName
                })
                .ToListAsync();
        }

        public override async Task<Comestible> GetByIdAsync(int id)
        {
            return await _context.Comestibles.FindAsync(id);
        }

        public override async Task<Category> FindCategoryAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }


        public override async Task<bool> CreateAsync(ComestibleDto dto)
        {
            var category = await _context.Categories.FindAsync(dto.CategoryName);
            if (category == null) return false;

            var comestible = new Comestible
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            _context.Comestibles.Add(comestible);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> UpdateAsync(int id, ComestibleDto dto)
        {
            var comestible = await _context.Comestibles.FindAsync(id);
            if (comestible == null) return false;

            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null) return false;

            comestible.Name = dto.Name;
            comestible.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var comestible = await _context.Comestibles.FindAsync(id);
            if (comestible == null) return false;

            _context.Comestibles.Remove(comestible);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}