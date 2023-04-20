using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    [Table("Products")]

    public class Products
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

           public int? ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDesc { get; set; }
            public int ProductPrice { get; set; }
        }
    }



