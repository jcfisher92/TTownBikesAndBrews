using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("CustomerAddress", Schema = "sales")]
    public class CustomerAddress : DbObject
    {        
        public CustomerAddress() { }
        
        /// <summary>
        /// Creates a new address for a given customer
        /// </summary>
        /// <param name="customer"> The customer that is associated with the new address</param>
        CustomerAddress(Customer customer) : this()
        {
            this.CustomerId = customer.Id;
            customer.CustomerAddresses.Add(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// 
        /// 
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }
    }
}
