using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Create(user);
        }

        public void DeleteUser(int id)
        {
            User user = _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _userRepository.Delete(user);
        }

        public User GetUserById(int id)
        {
            User user = _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IList<User> GetUsersBySkillId(int skillId)
        {
            return _userRepository.GetUsersBySkillId(skillId);
        }

        public IList<User> GetUsersByCategoryId(int categoryId)
        {
            return _userRepository.GetUsersByCategoryId(categoryId);
        }

        public void UpdateUser(int id, User user)
        {
            _userRepository.Update(user);
        }
    }
}