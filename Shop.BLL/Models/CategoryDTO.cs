using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class CategoryDTO
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }

    }
}
