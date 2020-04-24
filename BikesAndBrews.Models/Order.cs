using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("Order", Schema ="sales")]
    public class Order : DbObject
    {
        /// <summary>
        /// Creates a new order.
        /// </summary>
        public Order()
        { }

        /// <summary>
        /// Creates a new order for the given customer.
        /// </summary>
        public Order(Customer customer) : this()
        {
            CustomerId = customer.Id;
        }

        /// <summary>
        /// Gets or sets the id of the customer placing the order.
        /// </summary>
        public int CustomerId { get; set; }

        ///// <summary>
        ///// Gets or sets the customer placing the order.  Convienence refrence to provide info.
        ///// </summary>
        //public Customer Customer { 
        //    get { return this.Customer; }

        //    set
        //    {
        //        this.Customer = value;
        //        this.CustomerId = value.Id;
        //    } 
        //}

        /// <summary>
        /// Gets or sets the order's status.
        /// </summary>
        public byte OrderStatus { get; set; }// = (short)OrderStatus.Open;

        /// <summary>
        /// Gets or sets when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets when the order is required.
        /// </summary>
        public DateTime? RequiredDate { get; set; } = null;

        /// <summary>
        /// Gets or sets when the order was shipped.
        /// </summary>
        public DateTime? ShippedDate { get; set; } = null;
        
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        public int? InvoiceId { get; set; } = 0;

        /// <summary>
        /// Gets or sets the order lines in the order.
        /// </summary>
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }

    /// <summary>
    /// Represents the term for an order.
    /// </summary>
    public enum Term
    {
        Net1,
        Net5,
        Net15,
        Net30
    }

    /// <summary>
    /// Represents the payment status for an order.
    /// </summary>
    public enum PaymentStatus
    {
        Unpaid,
        Paid
    }

    /// <summary>
    /// Represents the status of an order.
    /// </summary>
    public enum OrderStatus
    {
        Open,
        Filled,
        Cancelled
    }
}
