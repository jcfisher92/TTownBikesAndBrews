using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("Customer", Schema = "sales")]
    public class Customer : DbObject
    {
        public Customer()
        {

        }
                
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Phone { get; set; }
        public string Email { get; set; }
        
        public List<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
    }
}
