using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("Category", Schema = "production")]
    public class Category : DbObject
    {
        /// <summary>
        /// 
        /// </summary>
        public Category()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }
    }
}
