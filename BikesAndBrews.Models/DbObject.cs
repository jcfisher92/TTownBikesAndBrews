using System;
using System.Collections.Generic;
using System.Text;

namespace BikesAndBrews.Models
{
    /// <summary>
    /// Base class for database entities.
    /// </summary>
    public class DbObject
    {      
        /// <summary>
        /// Gets or sets the database id.
        /// </summary>
        public int Id { get; set; }
    }
}
