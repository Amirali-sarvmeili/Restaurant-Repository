using crud.Dtos;
using crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService service)
        {
            _categoryService= service;
        }

        [HttpGet("Menu")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result == null) return NotFound("دسته بندی یافت نشد ):");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromHeader(Name = "Pin")] string Pin, CategoryDto dto)
        {
            if (Pin != "1234")
                return Unauthorized("رمز اشتباه است.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _categoryService.CreateAsync(dto);
            return Ok("دسته بندی ساخته شد");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromHeader(Name = "Pin")] string Pin, int id, CategoryDto dto)
        {
            if (Pin != "1234")
                return Unauthorized("رمز اشتباه است.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _categoryService.UpdateAsync(id, dto);
            if (!updated) return NotFound("دسته بندی یافت نشد ):");

            return Ok("دسته بندی آپدیت شد");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromHeader(Name = "Pin")] string Pin, int id)
        {
            if (Pin != "1234")
                return Unauthorized("رمز اشتباه است.");
            var deleted = await _categoryService.DeleteAsync(id);
            if (!deleted) return NotFound("دسته بندی یافت نشد ):");

            return Ok("دسته بندی حذف شد");
        }
    }
}

