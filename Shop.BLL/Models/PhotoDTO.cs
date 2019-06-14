using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class PhotoDTO
    {
        [Key]
        public int PhotoId { get; set; }

        public int GoodId { get; set; }

        [Required]
        [StringLength(100)]
        public string PhotoPath { get; set; }

    }
}
