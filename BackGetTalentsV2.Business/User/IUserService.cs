
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public interface IUserService
    {
        void AddUser(User user);
        IList<User> GetAllUsers();
        IList<User> GetUsersBySkillId(int skillId);
        IList<User> GetUsersByCategoryId(int categoryId);
        User GetUserById(int id);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}