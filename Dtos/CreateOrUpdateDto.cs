using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Dtos
{
    public class CreateOrUpdateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}
