using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMT4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
