using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreFacade.Models
{
    public abstract class AuditedBaseModel : BaseModel
    {
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }

    }
}
