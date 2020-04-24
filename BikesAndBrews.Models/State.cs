using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("State", Schema ="sales")]
    public class State : DbObject
    {
        /// <summary>
        /// Creates a new state object
        /// </summary>
        public State()
        {

        }

        /// <summary>
        /// The name of the state
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The state abreviation
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// The sales tax rate for the state
        /// </summary>
        public decimal SalesTax { get; set; }
    }
}
