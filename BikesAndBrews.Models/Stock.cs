using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("Stock", Schema = "production")]
    public class Stock : DbObject
    {
        /// <summary>
        /// creates a new stock object.
        /// </summary>
        public Stock()
        {
            ;
        }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }
    }
}
