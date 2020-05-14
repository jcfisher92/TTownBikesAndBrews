/*
 * 
 */
using BikesAndBrews.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository.Rest
{
    public class RestProductRepository : IProductRepository
    {
        private readonly HttpHelper _http;

        /// <summary>
        /// Creates the repository instance
        /// </summary>
        /// <param name="baseUrl">The URL for the REST services</param>
        public RestProductRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        /// <summary>
        /// Deletes a product based on the ID
        /// </summary>
        /// <param name="id">The product ID</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            await _http.DeleteAsync("product", id);
        }

        /// <summary>
        /// Gets all the product as a list.
        /// </summary>
        /// <returns>The list of products as objects</returns>
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _http.GetAsync<IEnumerable<Product>>("product");
        }

        /// <summary>
        /// Gets a list of products based on a search term.
        /// </summary>
        /// <param name="search">The search terms</param>
        /// <returns>The list of product objects returned by the search</returns>
        public async Task<IEnumerable<Product>> GetAsync(string search)
        {
            return await _http.GetAsync<IEnumerable<Product>>($"product/search?value={search}");
        }

        /// <summary>
        /// Gets a specific product based on the ID.
        /// </summary>
        /// <param name="id"> The product ID number</param>
        /// <returns>The product object</returns>
        public async Task<Product> GetAsync(int id)
        {
            return await _http.GetAsync<Product>($"product/{id}");
        }

        /// <summary>
        /// Inserts a new product into the database
        /// </summary>
        /// <param name="product">The product object</param>
        /// <returns>The newly created object</returns>
        public async Task<Product> InsertAsync(Product product)
        {
            return await _http.PostAsync<Product, Product>("product", product);
        }

        /// <summary>
        /// Updates a product object
        /// </summary>
        /// <param name="product">The product object to update</param>
        /// <returns></returns>
        public async Task<Product> UpdateAsync(Product product)
        {
            return await _http.PutAsync<Product, Product>("product", product);
        }
    }
}
