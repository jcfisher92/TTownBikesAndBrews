using BikesAndBrews.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Returns all orders. 
        /// </summary>
        Task<IEnumerable<Order>> GetAsync();

        /// <summary>
        /// Returns all customers with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Order>> GetAsync(string search);

        /// <summary>
        /// Returns the order with the given id. 
        /// </summary>
        Task<Order> GetAsync(int id);

        /// <summary>
        /// Adds a new order
        /// </summary>
        Task<Order> InsertAsync(Order order);

        /// <summary>
        /// Updates an existing order
        /// </summary>
        Task<Order> UpdateAsync(Order order);

        /// <summary>
        /// Deletes an order.
        /// </summary>
        Task DeleteAsync(int id);
    }
}
