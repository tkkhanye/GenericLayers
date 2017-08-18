using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Models
{
    public class LookupModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public int? ParentId { get; set; }
    }
}
