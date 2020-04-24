using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("OrderLine", Schema = "sales")]
    public class OrderLine : DbObject
    {
        /// <summary>
        /// Create a new order line
        /// </summary>
        public OrderLine()
        {

        }

        /// <summary>
        /// Creates a new order line for the given order and adds the line to the order.
        /// </summary>
        /// <param name="order"></param>
        public OrderLine(Order  order) : this()
        {            
            OrderId = order.Id;
            order.OrderLines.Add(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LineNbr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double ListPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Discount { get; set; }
    }
}
