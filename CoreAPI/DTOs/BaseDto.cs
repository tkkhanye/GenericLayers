using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.DTOs
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
    }
}
