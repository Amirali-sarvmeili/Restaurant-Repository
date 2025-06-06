using crud.Dtos;
using crud.Models;

namespace crud.Services;

public abstract class IComestibleService
{
    public abstract Task<List<ComestibleDto>> GetAllAsync();
    public abstract Task<Comestible> GetByIdAsync(int id);
    public abstract Task<Category> FindCategoryAsync(int categoryId);
    public abstract Task<bool> CreateAsync(ComestibleDto dto);
    public abstract Task<bool> UpdateAsync(int id, ComestibleDto dto);
    public abstract Task<bool> DeleteAsync(int id);
    private IComestibleService _comestibleService;

    public void ComestibleController(IComestibleService comestibleService)
    {
        _comestibleService = comestibleService;
    }
}