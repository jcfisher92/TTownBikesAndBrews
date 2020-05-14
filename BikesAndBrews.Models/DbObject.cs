using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
