using BikesAndBrews.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository
{
    /// <summary>
    /// Defines methods for interacting with the customer backend data.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<IEnumerable<Customer>> GetAsync();

        /// <summary>
        /// Returns all customers with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Customer>> GetAsync(string search);

        /// <summary>
        /// Returns the customer with the given id. 
        /// </summary>
        Task<Customer> GetAsync(int id);

        /// <summary>
        /// Adds a new customer if the customer does not exist.
        /// </summary>
        Task<Customer> InsertAsync(Customer customer);

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        Task<Customer> UpdateAsync(Customer customer);

        /// <summary>
        /// Deletes a customer by ID.
        /// </summary>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Delets a range of customers based on the IDs passed in
        /// 
        /// </summary>
        /// <param name="idList">The list of customer IDs to remove</param>
        /// <returns>The number of customers that were removed from the database.</returns>
        Task<int> DeleteRangeAsync(List<int> idList);
    }
}
