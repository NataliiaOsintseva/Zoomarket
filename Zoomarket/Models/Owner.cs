using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zoomarket.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int PetsQuantity { get; set; }
    }
}