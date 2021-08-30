using BackGetTalentsV2.Business.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    public class AddressRepository : IAddressRepository
    {
        private gettalentsContext _dbContext;

        public AddressRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }

        public Address GetAddressById(int id)
        {
            Address address = _dbContext.Addresses.Where(c => c.Id.Equals(id)).FirstOrDefault();

            if (address == null)
            {
                throw new AddressNotFoundException();
            }

            return address;
        }

        public IList<Address> GetAllAddresses()
        {
            return _dbContext.Addresses.ToList();
        }

        public IList<Address> GetAllAddressesForUser(int userId)
        {
            return _dbContext.Addresses.Where(a => a.UserId.Equals(userId)).ToList();
        }

        public void Update(Address address)
        {
            Address addressTemp = _dbContext.Addresses.Where(c => c.Id.Equals(address.Id)).FirstOrDefault();

            if (addressTemp == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            if (addressTemp != null)
            {
                addressTemp.Number = address.Number;
                addressTemp.Street = address.Street;
                addressTemp.PostalCode = address.PostalCode;
                addressTemp.City = address.City;
                addressTemp.Lng = address.Lng;
                addressTemp.Lat = address.Lat;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            if (GetAddressById(address.Id) != null)
            {
                _dbContext.Addresses.Remove(address);
                _dbContext.SaveChanges();
            }
        }
    }
}