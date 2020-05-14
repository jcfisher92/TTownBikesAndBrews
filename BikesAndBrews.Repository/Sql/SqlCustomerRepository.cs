using BikesAndBrews.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikesAndBrews.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the customers backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly BikesAndBrewsContext _db;

        public SqlCustomerRepository(BikesAndBrewsContext db)
        {
            _db = db;
        }
                
        async Task<bool> ICustomerRepository.DeleteAsync(int id)
        {
            bool result = false;
            var customer = await _db.Customer.FirstOrDefaultAsync(_customer => _customer.Id == id);
            if (customer != null)
            {                
                _db.Customer.Remove(customer);
                result = await _db.SaveChangesAsync() > 0;
            }

            return result;
        }

        async Task<int> ICustomerRepository.DeleteRangeAsync(List<int> idList)
        {
            int count = 0;

            foreach (int id in idList)
            {
                var customer = await _db.Customer.FirstOrDefaultAsync(_customer => _customer.Id == id);
                if (customer != null)
                {                    
                    _db.Customer.Remove(customer);
                    count += await _db.SaveChangesAsync();
                }
            }

            return count;
        }

        async Task<IEnumerable<Customer>> ICustomerRepository.GetAsync()
        {
            return await _db.Customer
                .AsNoTracking()
                .ToListAsync();                
        }

        async Task<IEnumerable<Customer>> ICustomerRepository.GetAsync(string search)
        {
            string[] parameters = search.Split(' ');

            return await _db.Customer
                .Where(customer => 
                    parameters.Any(parameter =>
                        customer.FirstName.StartsWith(parameter) ||
                        customer.LastName.StartsWith(parameter) ||
                        customer.Email.StartsWith(parameter)
                    )
                )
                .AsNoTracking()
                .ToListAsync();
        }

        async Task<Customer> ICustomerRepository.GetAsync(int id)
        {
            return await _db.Customer
                .AsNoTracking()
                .FirstOrDefaultAsync(customer => customer.Id == id);
        }

        async Task<Customer> ICustomerRepository.InsertAsync(Customer customer)
        {
            var current = await _db.Customer.FirstOrDefaultAsync(_customer => _customer.Id == customer.Id);
            if (current == null)
            {
                _db.Customer.Add(customer);
            }
            
            await _db.SaveChangesAsync();
            return customer;
        }

        async Task<Customer> ICustomerRepository.UpdateAsync(Customer customer)
        {
            var current = await _db.Customer.FirstOrDefaultAsync(_customer => _customer.Id == customer.Id);
            if (current != null)
            {
                _db.Entry(current).CurrentValues.SetValues(customer);
            }
            
            await _db.SaveChangesAsync();
            return customer;
        }
    }
}
