using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class GoodDTO
    {
        [Key]
        public int GoodId { get; set; }

        [Required]
        [StringLength(100)]
        public string GoodName { get; set; }

        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GoodCount { get; set; }
    }
}
