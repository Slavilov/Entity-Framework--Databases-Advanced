using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public class CategoryInputModel
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string? Name { get; set; }
    }
}
