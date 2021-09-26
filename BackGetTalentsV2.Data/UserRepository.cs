using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.User;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BackGetTalentsV2.Data
{
    public class UserRepository : IUserRepository
    {
        private gettalentsContext _dbContext;

        public UserRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetUserById(string id)
        {
            User user = _dbContext.Users.Where(c => c.FirebaseUid.Equals(id))
                .Include(p => p.Picture)
                .Include(u => u.Addresses)
                .FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public IList<User> GetAllUsers()
        {
            return _dbContext.Users
                .Include(p => p.Picture)
                .Include(u => u.Addresses)
                .ToList();
        }

        public void Update(string id, User user)
        {
            User userTemp = _dbContext.Users.Where(c => c.FirebaseUid.Equals(id)).FirstOrDefault();

            if (userTemp == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (userTemp != null)
            {
                userTemp.Pseudo = user.Pseudo;
                userTemp.RegistrationDate = user.RegistrationDate;
                userTemp.Status = user.Status;
                userTemp.Email = user.Email;
                userTemp.Phone = user.Phone;
                userTemp.Presentation = user.Presentation;
                userTemp.Birthday = user.Birthday;
                userTemp.Role = user.Role;
                userTemp.Picture = user.Picture;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (GetUserById(user.FirebaseUid) != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}