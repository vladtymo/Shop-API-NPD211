using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_NPD211.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(
        IMapper mapper,
        ShopDbContext context,
        IProductsService productsService
        //IFilesService filesService
        ) : ControllerBase
    {
        // [C]reate
        // [R]ead
        // [U]pdate
        // [D]elete

        //[HttpGet("all")]      // root/api/products/all
        //[HttpGet("/all")]     // root/all
        [HttpGet]               // root/api/products
        public IActionResult Get()
        {
            var items = context.Products.Include(x => x.Category).ToList();
            var result = mapper.Map<IEnumerable<ProductModel>>(items);

            return Ok(result); // 200
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(productsService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateProductModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = mapper.Map<Product>(model);

            // save file to server
            //if (model.Image != null)
                //entity.ImageUrl = await filesService.SaveProductImage(model.Image);

            context.Products.Add(entity);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditProductModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = mapper.Map<Product>(model);

            context.Products.Update(entity);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = context.Products.Find(id);

            if (product == null) throw new Exception($"Product with id {id} not found!");

            //if (product.ImageUrl != null)
            //await filesService.DeleteProductImage(product.ImageUrl);

            context.Products.Remove(product);
            context.SaveChanges();

            return Ok();
        }
    }
}
