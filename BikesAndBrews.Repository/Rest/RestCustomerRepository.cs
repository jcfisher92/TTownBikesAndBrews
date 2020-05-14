using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using BikesAndBrews.Models;

namespace BikesAndBrews.Repository.Rest
{
    public class RestCustomerRepository : ICustomerRepository
    {
        private readonly HttpHelper _http;

        /// <summary>
        /// Creates the repository instance
        /// </summary>
        /// <param name="baseUrl">The URI for the REST service</param>
        public RestCustomerRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        /// <summary>
        /// Deletes a customer based on the customer id.
        /// </summary>
        /// <param name="id">The customer ID used to locate the customer.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            int count = await _http.DeleteAsync("customer", id);

            return count > 0;
        }

        /// <summary>
        /// Deletes a list of customers.  Note that this makes multiple HTTP calls so it's not efficient.
        /// </summary>
        /// <param name="idList">The list of customer IDs to delete.</param>
        /// <returns></returns>
        public async Task<int> DeleteRangeAsync(List<int> idList)
        {
            int count = 0;

            foreach (int id in idList)
            {
                count += await _http.DeleteAsync("customer", id);
            }

            return count;
        }

        /// <summary>
        /// Returns a list of all the customers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _http.GetAsync<IEnumerable<Customer>>("customer");
        }

        /// <summary>
        /// Gets a list of customers based on the search string.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAsync(string search)
        {
            return await _http.GetAsync<IEnumerable<Customer>>($"customer/search?value={search}");
        }

        /// <summary>
        /// Gets a specific customer based on customer ID.
        /// </summary>
        /// <param name="id">The customer ID to retrieve</param>
        /// <returns></returns>
        public async Task<Customer> GetAsync(int id)
        {
            return await _http.GetAsync<Customer>($"customer/{id}");
        }

        /// <summary>
        /// Inserts a new customer.
        /// </summary>
        /// <param name="customer">The customer data to add to the db</param>
        /// <returns></returns>
        public async Task<Customer> InsertAsync(Customer customer)
        {
            return await _http.PostAsync<Customer, Customer>("customer", customer);
        }

        /// <summary>
        /// Updates a customer
        /// </summary>
        /// <param name="customer">The updated customer information</param>
        /// <returns></returns>
        public async Task<Customer> UpdateAsync(Customer customer)
        {
            return await _http.PutAsync<Customer, Customer>("customer", customer);
        }
    }
}
