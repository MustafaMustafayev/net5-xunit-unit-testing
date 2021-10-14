using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.Models;

namespace test.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> Get();
        Task<Role> Get(int roleId);
        Task Add(Role role);
    }
}
