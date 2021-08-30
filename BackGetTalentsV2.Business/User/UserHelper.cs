﻿using BackGetTalentsV2.Business.Address;
using BackGetTalentsV2.Business.Review;
using BackGetTalentsV2.Business.Picture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public class UserHelper
    {
        public static List<UserDTO> ConvertUsers(List<User> users)
        {
            return users.ConvertAll(user => ConvertUser(user));
        }

        public static UserDTO ConvertUser(User user)
        {
            UserDTO userDTO = new()
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                RegistrationDate = user.RegistrationDate,
                Status = user.Status,
                Email = user.Email,
                Phone = user.Phone,
                Presentation = user.Presentation,
                Birthday = user.Birthday,
                Role = user.Role,
                ProfilePicture = PictureHelper.ConvertPicture(user.Picture),
                Addresses = user.Addresses.ToList().ConvertAll(address => new AddressDTO
                {
                    Id = address.Id,
                    Number = address.Number,
                    Street = address.Street,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Lng = address.Lng,
                    Lat = address.Lat,
                    UserId = address.UserId
                })
            };

            return userDTO;
        }

        public static UserDTOMinimalist ConvertUserMinimalist(User user)
        {
            UserDTOMinimalist userDTO = new()
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                RegistrationDate = user.RegistrationDate,
                Status = user.Status,
                Email = user.Email,
                Phone = user.Phone,
                Presentation = user.Presentation,
                Birthday = user.Birthday,
                Role = user.Role,
                ProfilePicture = PictureHelper.ConvertPicture(user.Picture),
            };

            return userDTO;
        }

        public static User ConvertUserDTO(UserDTOMinimalist userDTO)
        {
            User user = new()
            {
                Id = userDTO.Id,
                Pseudo = userDTO.Pseudo,
                RegistrationDate = userDTO.RegistrationDate,
                Status = userDTO.Status,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                Presentation = userDTO.Presentation,
                Birthday = userDTO.Birthday,
                Role = userDTO.Role,
                Picture = PictureHelper.ConvertPictureDTO(userDTO.ProfilePicture)
            };

            return user;
        }
    }
}