﻿using Data.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICartService
    {
        void Add(int id);
        void Delete(int id);
        void Clear();
        IEnumerable<int> GetIds();
        IEnumerable<Product> GetProducts();
        IEnumerable<ProductModel> GetProductDtos();
    }
}
