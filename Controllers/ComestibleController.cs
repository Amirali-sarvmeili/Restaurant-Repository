using crud.Dtos;
using crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComestibleController : ControllerBase
    {
        private readonly ComestibleService _comestibleService;


        public ComestibleController(ComestibleService service) => _comestibleService = service;

// Read all
        [HttpGet("Menu")]
        public async Task<IActionResult> GetAll()
        {

            var comestible = await _comestibleService.GetAllAsync();
            return Ok(comestible);
        }

// Read by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comestible = await _comestibleService.GetByIdAsync(id);
            return comestible == null ? NotFound("ایتمی با این ایدی پیدا نشد") : Ok(comestible);
        }

// Create
        [HttpPost]
        public async Task<IActionResult> Create([FromHeader(Name = "Pin")] string Pin,
            [FromBody] ComestibleDto comestible)
        {
            if (Pin != "1234")
                return Unauthorized("رمز اشتباه است.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _comestibleService.CreateAsync(comestible);

            return Ok($"اطلاعات ایتم با {comestible.id} وارد شد");

        }

// Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromHeader(Name = "Pin")] string Pin, int id,
            [FromBody] ComestibleDto dto)
        {
            if (Pin != "1234")
                return Unauthorized("رمز اشتباه است.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _comestibleService.UpdateAsync(id, dto);
            if (!updated) return NotFound("ایتمی یافت نشد):");

            return Ok("ایتم آپدیت شد");
        }

// delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromHeader(Name = "Pin")] string Pin, int id)
        {
            if (Pin != "1234")
                return Unauthorized("رمز اشتباه است.");
            var deleted = await _comestibleService.DeleteAsync(id);
            if (!deleted) return NotFound("ایتمی یافت نشد):");

            return Ok("ایتم حذف شد");
        }

    }
}