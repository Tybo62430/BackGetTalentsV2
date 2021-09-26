using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Address
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public float? Lng { get; set; }
        public float? Lat { get; set; }
        public int UserId { get; set; }

        public virtual User.User User { get; set; }
    }
}
