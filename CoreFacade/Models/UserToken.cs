using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreFacade.Models
{
    public class UserToken
    {
        [Key]
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public Guid UserId { get; set; }
        public bool RequestSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
