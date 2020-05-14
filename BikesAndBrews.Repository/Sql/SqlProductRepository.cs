using BikesAndBrews.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository.Sql
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly BikesAndBrewsContext _db;

        public SqlProductRepository(BikesAndBrewsContext db)
        {
            _db = db;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        async public Task<IEnumerable<Product>> GetAsync()
        {
            return await _db.Product
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Searches for and returns a list of orders matching the search terms.
        /// TODO: figure out how to search on non-string fields.        
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        async public Task<IEnumerable<Product>> GetAsync(string search)
        {
            string[] parameters = search.Split(' ');

            return await _db.Product
                .Where(product =>
                    parameters.Any(parameter =>
                        product.ProductName.StartsWith(parameter)
                    )
                )
                .AsNoTracking()
                .ToListAsync();
        }

        async public Task<Product> GetAsync(int id)
        {
            return await _db.Product
                .AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == id);
        }

        async public Task<Product> InsertAsync(Product product)
        {
            var current = await _db.Product.FirstOrDefaultAsync(_product => _product.Id == product.Id);
            if (current == null)
            {
                _db.Product.Add(product);
            }

            await _db.SaveChangesAsync();
            return product;
        }

        async public Task<Product> UpdateAsync(Product product)
        {
            var current = await _db.Product.FirstOrDefaultAsync(_product => _product.Id == product.Id);
            if (current != null)
            {
                _db.Entry(current).CurrentValues.SetValues(product);
            }

            await _db.SaveChangesAsync();
            return product;
        }
    }
}
