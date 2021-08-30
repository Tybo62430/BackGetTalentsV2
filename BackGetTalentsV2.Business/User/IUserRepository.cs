using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.User
{
    public interface IUserRepository
    {
        void Create(User user);
        IList<User> GetAllUsers();
        User GetUserById(int id);
        void Update(User user);
        void Delete(User user);
    }
}