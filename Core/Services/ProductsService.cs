using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductsService(ShopDbContext context, IMapper mapper) : IProductsService
    {
        public ProductModel GetById(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) throw new Exception($"Product with id {id} not found!");

            context.Entry(product).Reference(x => x.Category).Load();

            return mapper.Map<ProductModel>(product);
        }
    }
}
