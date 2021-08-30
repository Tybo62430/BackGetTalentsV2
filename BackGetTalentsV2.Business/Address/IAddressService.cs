using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Address
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        IList<Address> GetAllAddresses();
        Address GetAddressById(int id);
        IList<Address> GetAllAddressesForUser(int userId);
        void UpdateAddress(int id, Address address);
        void DeleteAddress(int id);
    }
}