using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetProviders.Models;

namespace NetProviders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController: ControllerBase
    {
        private readonly PostDbContext _DbContext;

        public ProviderController(PostDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var providers = await _DbContext.Providers.ToListAsync();
            return Ok(providers);
        }

        [HttpGet]
        [Route("get-provider-by-id")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _DbContext.Providers.FindAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Provider provider)
        {
            _DbContext.Providers.Add(provider);
            await _DbContext.SaveChangesAsync();
            return Created($"/get-provider-by-id?id={provider.Id}", provider);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Provider providerToUpdate)
        {
            _DbContext.Providers.Update(providerToUpdate);
            await _DbContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var providerToDelete = await _DbContext.Providers.FindAsync(id);
            if (providerToDelete == null)
            {
                return NotFound();
            }
            _DbContext.Providers.Remove(providerToDelete);
            await _DbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
