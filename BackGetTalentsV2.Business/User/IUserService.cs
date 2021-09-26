
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
        User GetUserById(int id);
        User GetUserById(string id);
        void UpdateUser(string id, User user);
        void DeleteUser(string id);
        IList<User> GetUsersBySkillId(int skillId);
        IList<User> GetUsersByCategoryId(int categoryId);
    }
}