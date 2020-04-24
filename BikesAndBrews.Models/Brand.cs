using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikesAndBrews.Models
{
    [Table("Brand", Schema = "production")]
    public class Brand : DbObject
    {
        public Brand()
        {

        }

        public string BrandName { get; set; }
    }
}
