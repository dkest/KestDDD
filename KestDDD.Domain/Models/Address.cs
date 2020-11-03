using System;
using Microsoft.EntityFrameworkCore;
using KestDDD.Domain.Core.Models;

namespace KestDDD.Domain.Models
{
    /// <summary>
    /// 地址
    /// </summary>
    [Owned]
    public class Address : ValueObject<Address>
    {
        public string Province { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string Street { get; private set; }

        public Address() { }
        public Address(string province, string city, string county, string street)
        {
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

