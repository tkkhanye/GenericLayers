using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.DTOs
{
    public class PropertyDto :BaseDto
    {
        public int NumberOfBedrooms { get; set; }
        public AddressDto PhysicalAddress { get; set; } = new AddressDto();
        public AddressDto PostalAddress { get; set; } = new AddressDto();
    }
}
