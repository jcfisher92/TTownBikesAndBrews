using BikesAndBrews.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikesAndBrews.Repository
{
    /// <summary>
    /// Defines methods for interacting with the app backend.
    /// </summary>
    public interface IBikesAndBrewsRepository
    {
        /// <summary>
        /// Returns the customers repository.
        /// </summary>
        ICustomerRepository Customers { get; }

        /// <summary>
        /// Returns the Orders repository.
        /// </summary>
        IOrderRepository Orders { get; }

        /// <summary>
        /// Returns the Products repository.
        /// </summary>
        IProductRepository Products { get; }
    }
}
