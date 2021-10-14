using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.DTOs;
using test.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roleService.Get());
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> Get(int roleId)
        {
            return Ok(await _roleService.Get(roleId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RoleToAddDTO roleToAddDTO)
        {
            await _roleService.Add(roleToAddDTO);
            return Ok();
        }
    }
}
