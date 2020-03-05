using RegisterProducts.Models;
using RegisterProducts.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
namespace RegisterProducts.Services
{
    public class ProductService{
        
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task <int> Create(ProductDto productDto)
        {
            var product = new Product(productDto.Description);
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            foreach (var itemDto in productDto.Items)
            {
                var item = new Item(itemDto.Description,product.Id);
                _context.Item.Add(item);
            }
            await _context.SaveChangesAsync();
            return product.Id;
        }
        public async Task<ProductDto> GetById(int productId)
        {
            try
            {
                var product = await _context.Product
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == productId); 

                var listItems = await  _context.Item
                .AsNoTracking()
                .AsQueryable()
                .Where(x => x.ProductId == productId)
                .ToListAsync();

                List<ItemDto> itemsDto = new List<ItemDto>();
                foreach(var item in listItems)
                {
                    var itemDto = new ItemDto(item.Id, item.Description);
                    itemsDto.Add(itemDto);
                }
                var productDto = new ProductDto(product.Id, product.Description,itemsDto);
                return productDto;

            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }
    }
}