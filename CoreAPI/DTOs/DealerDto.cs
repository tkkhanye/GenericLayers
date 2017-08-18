using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.DTOs
{
    public class DealerDto : BaseDto
    {
        public string Code { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
    }
}
