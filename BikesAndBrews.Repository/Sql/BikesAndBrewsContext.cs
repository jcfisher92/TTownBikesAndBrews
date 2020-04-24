using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BikesAndBrews.Models;

namespace BikesAndBrews.Repository.Sql
{
    public class BikesAndBrewsContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BikesAndBrewsContext() : base()
        {

        }

        /// <summary>
        /// Creates a new BikesAndBrews DbContext.
        /// </summary>
        public BikesAndBrewsContext(DbContextOptions<BikesAndBrewsContext> options) : base(options)
        { }

        /// <summary>
        /// Configure the BikesAndBrews DbContext.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(Constants.connStr);
        }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Brand> Brand { get; set; }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Category> Category { get; set; }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Customer> Customer { get; set; }

        /// <summary>
        /// Gets the customer address DbSet.
        /// </summary>
        public DbSet<CustomerAddress> CustomerAddress { get; set; }

        /// <summary>
        /// Gets the orders DbSet.
        /// </summary>
        public DbSet<Order> Order { get; set; }

        /// <summary>
        /// Gets the order line DbSet.
        /// </summary>
        public DbSet<OrderLine> OrderLine { get; set; }

        /// <summary>
        /// Gets the products DbSet.
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Gets the list of states DbSet.
        /// </summary>
        public DbSet<State> State { get; set; }

        /// <summary>
        /// Gets the product stock DbSet.
        /// </summary>
        public DbSet<Stock> Stock { get; set; }

    }
}
