﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConcerns.Security
{
    public static class SecurityConcern
    {
        public static string PassPhrase => "you need to Sub this with your own.. hacker!";
        public static SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityConcern.PassPhrase));
    }
}
