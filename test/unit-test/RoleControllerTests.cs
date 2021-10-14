using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using test.Controllers;
using test.DTOs;
using test.Services;
using unit_test.MemberData;
using Xunit;
using FluentAssertions;
using test.Models;

namespace unit_test
{
    public class RoleControllerFixture : IDisposable
    {
        public readonly Mock<IRoleService> _roleService;
        public RoleControllerFixture()
        {
            _roleService = new Mock<IRoleService>();
        }
        public void Dispose()
        {
            //
        }

        internal RoleController roleController => new RoleController(_roleService.Object);
    }

    public class RoleControllerTests : IClassFixture<RoleControllerFixture>
    {
        private readonly RoleController _roleController;
        private readonly Mock<IRoleService> _roleService;
        public RoleControllerTests(RoleControllerFixture roleControllerFixture)
        {
            _roleController = roleControllerFixture.roleController;
            _roleService = roleControllerFixture._roleService;
        }

        [Theory]
        [MemberData(nameof(RoleMemberData.GetById), MemberType = typeof(RoleMemberData))]
        public async Task GetRoleById(int roleId)
        {
            RoleToListDTO roleToListDTO = new RoleToListDTO()
            {
                RoleId = 1,
                RoleKey = "admin",
                RoleName = "Admin"
            };
            _roleService.Setup(m => m.Get(roleId)).ReturnsAsync(roleToListDTO).Verifiable();

            var actual = await _roleController.Get(roleId);

            _roleService.Verify();
            var okObject = actual as OkObjectResult;
            RoleToListDTO role = okObject.Value as RoleToListDTO;
            Assert.NotNull(role);
            Assert.Equal(roleId, role.RoleId);
            actual.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetRoles()
        {
            var actual = await _roleController.Get();
            Assert.NotNull(actual);
            actual.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [MemberData(nameof(RoleMemberData.AddRole), MemberType = typeof(RoleMemberData))]
        public async Task AddRole(RoleToAddDTO roleToAddDTO)
        {
            var actual = await _roleController.Post(roleToAddDTO);
            actual.Should().BeOfType<OkResult>();
        }
    }
}
