using BikesAndBrews.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository.Sql
{
    class SqlOrderRepository : IOrderRepository
    {
        private readonly BikesAndBrewsContext _db;

        public SqlOrderRepository(BikesAndBrewsContext db)
        {
            _db = db;
        }

        async Task IOrderRepository.DeleteAsync(int id)
        {
            var order = await _db.Order.FirstOrDefaultAsync(_order => _order.Id == id);
            if (order != null)
            {                
                _db.Order.Remove(order);
                await _db.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Order>> IOrderRepository.GetAsync()
        {
            return await _db.Order
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Search for an order by different fields.
        /// TODO: need to figure out how to search for the different values since they order header doesn't have strings
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        async Task<IEnumerable<Order>> IOrderRepository.GetAsync(string search)
        {
            string[] parameters = search.Split(' ');

            return await _db.Order
                .Where(order =>
                    parameters.Any(parameter =>
                        order.CustomerId.Equals(Convert.ToInt32(parameter))   
                    )
                )
                .AsNoTracking()
                .ToListAsync();
        }

        async Task<Order> IOrderRepository.GetAsync(int id)
        {
            return await _db.Order
                .AsNoTracking()
                .FirstOrDefaultAsync(order => order.Id == id);
        }

        async Task<Order> IOrderRepository.InsertAsync(Order order)
        {
            var current = await _db.Order.FirstOrDefaultAsync(_order => _order.Id == _order.Id);
            if (current == null)
            {
                _db.Order.Add(order);
            }

            await _db.SaveChangesAsync();
            return order;
        }

        async Task<Order> IOrderRepository.UpdateAsync(Order order)
        {
            var current = await _db.Order.FirstOrDefaultAsync(_order => _order.Id == order.Id);
            if (current != null)
            {
                _db.Entry(current).CurrentValues.SetValues(order);
            }

            await _db.SaveChangesAsync();
            return order;
        }
    }
}
