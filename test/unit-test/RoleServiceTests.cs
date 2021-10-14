using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using test.Core;
using test.DataContext;
using test.DTOs;
using test.Models;
using test.Repositories;
using test.Services;
using unit_test.MemberData;
using Xunit;

namespace unit_test
{
    public class RoleServiceFixture : IDisposable
    {
        public Mock<IRoleRepository> roleRepository;
        private readonly IMapper _mapper;
        public RoleServiceFixture()
        {
            roleRepository = new Mock<IRoleRepository>();
        }

        internal RoleService roleService => new RoleService(roleRepository.Object, _mapper);

        public void Dispose()
        {
            //
        }
    }

    public class RoleServicesTests : IClassFixture<RoleServiceFixture>
    {
        private readonly RoleService _roleService;

        private readonly Mock<IRoleRepository> _roleRepoMock;
        private readonly IMapper _mapperMock;
        public RoleServicesTests(RoleServiceFixture roleFixture)
        {
            _roleService = roleFixture.roleService;
            _roleRepoMock = roleFixture.roleRepository;
            
            if (_mapperMock == null)
            {
                // Auto Mapper Configurations
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new Automapper());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapperMock = mapper;
            }
            _roleService = new RoleService(_roleRepoMock.Object, _mapperMock);
            
        }

        [Theory]
        [MemberData(nameof(RoleMemberData.GetById), MemberType = typeof(RoleMemberData))]
        public async Task GetRoleById(int roleId)
        {
            //Arrange
            Role roleObj = new Role()
            {
                RoleId = roleId,
                RoleKey = "admin",
                RoleName = "Admin"
            };

            //verifiable using for verifying all setups is used in executing, if not test will fail
            _roleRepoMock.Setup(m => m.Get(roleId))
                .ReturnsAsync(roleObj).Verifiable("not executed");

            //Act
            var actual = await _roleService.Get(roleId);

            _roleRepoMock.Verify();
            //Assert
            //Assert.IsType<RoleToListDTO>(actual);
            Assert.Equal(roleId, actual.RoleId);
            actual.Should().BeOfType<RoleToListDTO>();
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task GetRoles()
        {
            List<Role> roleObjs = new List<Role>()
            {
                new Role()
                {
                    RoleId = 1,
                    RoleKey = "admin",
                    RoleName = "Admin"
                }
            };

            _roleRepoMock.Setup(m => m.Get()).ReturnsAsync(roleObjs);

            List<RoleToListDTO> acutal = await _roleService.Get();
            // Assert.IsType<List<RoleToListDTO>>(actual);
            acutal.Should().BeOfType<List<RoleToListDTO>>();
            Assert.NotNull(acutal);
        }

        [Theory]
        [MemberData(nameof(RoleMemberData.AddRole), MemberType = typeof(RoleMemberData))]
        public async Task AddRole(RoleToAddDTO roleToAddDTO)
        {
            Role role = _mapperMock.Map<Role>(roleToAddDTO);
            await _roleService.Add(roleToAddDTO);
        }
    }
}
