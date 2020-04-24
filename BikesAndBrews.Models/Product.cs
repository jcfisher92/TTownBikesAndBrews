using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("Product", Schema = "production")]
    public class Product : DbObject
    {
        /// <summary>
        /// 
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short ModelYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ListPirce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Cost { get; set; }
    }
}
