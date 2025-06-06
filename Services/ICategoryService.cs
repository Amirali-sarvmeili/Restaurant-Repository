using crud.Dtos;
using crud.Models;

namespace crud.Services;

public interface ICategoryService
{
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<bool> CreateAsync(CategoryDto dto);
        Task<bool> UpdateAsync(int id, CategoryDto dto);
        Task<bool> DeleteAsync(int id);
}