using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreFacade.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
