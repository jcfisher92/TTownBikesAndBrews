using System;
using System.Collections.Generic;
using System.Text;

namespace BikesAndBrews.Repository.Rest
{
    /// <summary>
    /// REST interface for getting information from the backend systems
    /// </summary>
    public class RestBikesAndBrewsRepository : IBikesAndBrewsRepository
    {
        private readonly string _url;

        public RestBikesAndBrewsRepository(string url)
        {
            _url = url;
        }

        public ICustomerRepository Customers => new RestCustomerRepository(_url);

        public IOrderRepository Orders => new RestOrderRepository(_url);

        public IProductRepository Products => new RestProductRepository(_url);

    }
}
