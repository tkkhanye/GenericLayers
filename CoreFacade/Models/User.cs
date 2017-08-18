using CoreFacade.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Models
{
    public class User : AuditedBaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int LoginAttempts { get; set; }
        public DateTime LastSuccessfulLogin { get; set; }
        public EstablishmentType EstablishmentType { get; set; }
    }
}
