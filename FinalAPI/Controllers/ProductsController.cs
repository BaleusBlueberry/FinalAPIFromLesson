using DAL.Data;
using FinalAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductsRepository repository, CategoryRepository categoryRepository) : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(repository.GetAll().Select(p=>p.ToDto()));
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            var product = repository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToDto());
        }

        [HttpPost("add")]
        [Authorize(Roles = "admin")]
        public ActionResult AddProduct(CreateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                var category = categoryRepository.GetById(dto.CategoryId);
                if (category == null)
                {
                    return BadRequest(new {message = "invalid Category"});
                }
                var product = dto.ToProduct();

                repository.Add(product);
                product.Category = category;
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product.ToDto());
            }

            return BadRequest(ModelState);
        }
    }
}
