/*
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using BikesAndBrews.Models;

namespace BikesAndBrews.Repository.Rest
{
    public class RestOrderRepository : IOrderRepository
    {
        private readonly HttpHelper _http;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        public RestOrderRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            await _http.DeleteAsync("order", id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _http.GetAsync<IEnumerable<Order>>("order");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetAsync(string search)
        {
            return await _http.GetAsync<IEnumerable<Order>>($"order/search?value={search}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetAsync(int id)
        {
            return await _http.GetAsync<Order>($"order/{id}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> InsertAsync(Order order)
        {
            return await _http.PostAsync<Order, Order>("order", order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> UpdateAsync(Order order)
        {
            return await _http.PutAsync<Order, Order>("order", order);
        }
    }
}
