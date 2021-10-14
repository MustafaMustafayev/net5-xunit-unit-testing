using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Models;

namespace test.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApiDbContext _apiDbContext;
        public RoleRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task Add(Role role)
        {
            await _apiDbContext.Roles.AddAsync(role);
            await _apiDbContext.SaveChangesAsync();
        }

        public async Task<List<Role>> Get()
        {
            return await _apiDbContext.Roles.ToListAsync();
        }

        public async Task<Role> Get(int roleId)
        {
            return await _apiDbContext.Roles.FindAsync(roleId);
        }
    }
}
