using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikesAndBrews.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the app backend using 
    /// SQL via Entity Framework Core. 
    /// </summary>
    public class SqlBikesAndBrewsRepository : IBikesAndBrewsRepository
    {
        private readonly DbContextOptions<BikesAndBrewsContext> _dbOptions;

        public SqlBikesAndBrewsRepository(DbContextOptionsBuilder<BikesAndBrewsContext> dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
        }

        public ICustomerRepository Customers => new SqlCustomerRepository(new BikesAndBrewsContext(_dbOptions));

        public IOrderRepository Orders => new SqlOrderRepository(new BikesAndBrewsContext(_dbOptions));

        public IProductRepository Products => new SqlProductRepository(new BikesAndBrewsContext(_dbOptions));
    }
}
