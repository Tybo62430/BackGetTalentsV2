using BackGetTalentsV2.Business.Address;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Controllers
{
    [Route("addresses")]
    [ApiController]
    public class AddressesController : Controller
    {
        private IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult CreateAddress([FromBody] AddressDTO addressDTO)
        {
            Address address = AddressHelper.ConvertAddressDTO(addressDTO);

            _addressService.AddAddress(address);

            return Created(nameof(CreateAddress), address);
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            IList<Address> addresses = _addressService.GetAllAddresses();

            List<AddressDTO> addressesDTO = AddressHelper.ConvertAddresses(addresses.ToList());

            return Ok(addressesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAddressById([FromRoute] int id)
        {
            try
            {
                Address address = _addressService.GetAddressById(id);

                AddressDTO addressDTO = AddressHelper.ConvertAddress(address);

                return Ok(addressDTO);
            }
            catch (AddressNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        public IActionResult GetAllAddressesForUser([FromRoute] int userId)
        {
            try
            {
                IList<Address> addresses = _addressService.GetAllAddressesForUser(userId);

                List<AddressDTO> addressesDTO = AddressHelper.ConvertAddresses(addresses.ToList());

                return Ok(addressesDTO);
            }
            catch (AddressNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAddress([FromRoute] int id)
        {
            try
            {
                _addressService.DeleteAddress(id);

                return NoContent();
            }
            catch (AddressNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateAddress([FromRoute] int id, [FromBody] AddressDTO addressDTO)
        {
            try
            {
                Address address = AddressHelper.ConvertAddressDTO(addressDTO);

                _addressService.UpdateAddress(id, address);

                return NoContent();
            }
            catch (AddressNotFoundException)
            {
                return NotFound();
            }
        }
    }
}