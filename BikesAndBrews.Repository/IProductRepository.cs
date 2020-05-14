using BikesAndBrews.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// Returns all products. 
        /// </summary>
        Task<IEnumerable<Product>> GetAsync();

        /// <summary>
        /// Returns all products with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Product>> GetAsync(string search);

        /// <summary>
        /// Returns the product with the given id. 
        /// </summary>
        Task<Product> GetAsync(int id);

        /// <summary>
        /// Adds a new product if the product does not exist.
        /// </summary>
        Task<Product> InsertAsync(Product product);

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        Task<Product> UpdateAsync(Product product);

        /// <summary>
        /// Deletes a product.
        /// </summary>
        Task DeleteAsync(int id);
    }
}
