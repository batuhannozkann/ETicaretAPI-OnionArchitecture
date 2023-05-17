
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ValuesController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {
            var result=await _productWriteRepository.AddAsync(new List<Product> { new Product { Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Price = 5000, ProductName = "Phone", Stock = 50 } });
            await _productWriteRepository.SaveAsync();
            return Ok(result);
        }
        [HttpGet("[action]")]
        public IActionResult GetProducts()
        {
            var products = _productReadRepository.GetAll();
            return Ok(products);
        }
    }
}
