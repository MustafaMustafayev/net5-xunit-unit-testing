using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.DTOs;

namespace test.Services
{
    public interface IRoleService
    {
        Task Add(RoleToAddDTO roleToAddDTO);
        Task<List<RoleToListDTO>> Get();
        Task<RoleToListDTO> Get(int roleId);
    }
}
