using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Address
{
    public class AddressHelper
    {
        public static List<AddressDTO> ConvertAddresses(List<Address> addresses)
        {
            return addresses.ConvertAll(address => ConvertAddress(address));
        }

        public static AddressDTO ConvertAddress(Address address)
        {
            AddressDTO addressDTO = new()
            {
                Id = address.Id,
                Number = address.Number,
                Street = address.Street,
                City = address.City,
                PostalCode = address.PostalCode,
                Country = address.Country,
                Lng = address.Lng,
                Lat = address.Lat,
                UserId = address.UserId
            };

            return addressDTO;
        }

        public static Address ConvertAddressDTO(AddressDTO addressDTO)
        {
            Address address = new()
            {
                Id = addressDTO.Id,
                Number = addressDTO.Number,
                Street = addressDTO.Street,
                City = addressDTO.City,
                PostalCode = addressDTO.PostalCode,
                Country = addressDTO.Country,
                Lng = addressDTO.Lng,
                Lat = addressDTO.Lat,
                UserId = addressDTO.UserId
            };

            return address;
        }
    }
}