﻿using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Domain.Repositories.Interfaces;
using ProjectAPI.Infra.Data.Context;

namespace ProjectAPI.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllASync(int pageNumber, int pageQuantity)
        {
            if (pageNumber < 0)
                pageNumber = 0;

            if (pageQuantity <= 0)
                pageQuantity = int.MaxValue;

            return await _context.Products
                    .Skip(pageNumber * pageQuantity)
                    .Take(pageQuantity)
                    .ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
