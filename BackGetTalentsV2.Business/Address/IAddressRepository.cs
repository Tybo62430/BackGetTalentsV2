using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Address
{
    public interface IAddressRepository
    {
        void Create(Address address);
        IList<Address> GetAllAddresses();
        Address GetAddressById(int id);
        IList<Address> GetAllAddressesForUser(int userId);
        void Update(Address address);
        void Delete(Address address);
    }
}