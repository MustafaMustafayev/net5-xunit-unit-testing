using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.DTOs;
using test.Models;
using test.Repositories;

namespace test.Services
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task Add(RoleToAddDTO roleToAddDTO)
        {
            await _roleRepository.Add(_mapper.Map<Role>(roleToAddDTO));
        }

        public async Task<List<RoleToListDTO>> Get()
        {
            return _mapper.Map<List<RoleToListDTO>>(await _roleRepository.Get());
        }

        public async Task<RoleToListDTO> Get(int roleId)
        {
            return _mapper.Map<RoleToListDTO>(await _roleRepository.Get(roleId));
        }
    }
}
