
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public TestController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task AddAsync()
        {
            await _productWriteRepository.AddAsync(new Product { ProductName = "Computer", Price = 15000, Stock = 70 });
            //var result=await _productWriteRepository.AddAsync(new List<Product> { new Product { Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Price = 5000, ProductName = "Phone", Stock = 50 } });
            
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("[action]")]
        public async Task Update()
        {
            var product = _productReadRepository.GetWhere(x => x.ProductName == "Computer").FirstOrDefault();
            product.Price = 17000;
            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("[action]")]
        public IActionResult GetProducts()
        {
            var products = _productReadRepository.GetAll();
            return Ok(products);
        }
    }
}
