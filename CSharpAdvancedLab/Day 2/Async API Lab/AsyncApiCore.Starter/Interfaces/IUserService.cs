using AsyncApiCore.Starter.Models;
using System.Collections.Generic;

namespace AsyncApiCore.Starter.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
    }
}