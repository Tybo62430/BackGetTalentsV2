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
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.SkillIdskillNavigation)
                .ThenInclude(c => c.Category)
                .FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.Where(c => c.Id.Equals(id))
                .Include(p => p.Picture)
                .Include(u => u.Addresses)
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.SkillIdskillNavigation)
                .ThenInclude(c => c.Category)
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
                .Include(a => a.Picture)
                .Include(a => a.Addresses)
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.SkillIdskillNavigation)
                .ThenInclude(c => c.Category)
                .ToList();
        }

        public IList<User> GetUsersBySkillId(int skillId)
        {
            return _dbContext.Users
                .Where(a => a.UserHasSkills.Any(b => b.SkillIdskill.Equals(skillId)))
                .Include(a => a.Picture)
                .Include(a => a.Addresses)
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.SkillIdskillNavigation)
                .ThenInclude(c => c.Category)
                .ToList();
        }

        public IList<User> GetUsersByCategoryId(int categoryId)
        {
            return _dbContext.Users
                .Where(a => a.UserHasSkills.Any(b => b.SkillIdskillNavigation.CategoryId.Equals(categoryId)))
                .Include(a => a.Picture)
                .Include(a => a.Addresses)
                .Include(a => a.UserHasSkills)
                .ThenInclude(b => b.SkillIdskillNavigation)
                .ThenInclude(c => c.Category)
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
                userTemp.Email = user.Email;
                userTemp.Birthday = user.Birthday;
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