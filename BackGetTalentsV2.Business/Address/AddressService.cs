using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Address
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void AddAddress(Address address)
        {
            _addressRepository.Create(address);
        }

        public void DeleteAddress(int id)
        {
            Address address = _addressRepository.GetAddressById(id);

            if (address == null)
            {
                throw new AddressNotFoundException();
            }

            _addressRepository.Delete(address);
        }

        public Address GetAddressById(int id)
        {
            Address address = _addressRepository.GetAddressById(id);

            if (address == null)
            {
                throw new AddressNotFoundException();
            }

            return address;
        }

        public IList<Address> GetAllAddresses()
        {
            return _addressRepository.GetAllAddresses();
        }

        public IList<Address> GetAllAddressesForUser(int userId)
        {
            return _addressRepository.GetAllAddressesForUser(userId);
        }

        public void UpdateAddress(int id, Address address)
        {
            Address tempAddress = _addressRepository.GetAddressById(id);

            if (tempAddress == null)
            {
                throw new AddressNotFoundException();
            }

            _addressRepository.Update(address);
        }
    }
}