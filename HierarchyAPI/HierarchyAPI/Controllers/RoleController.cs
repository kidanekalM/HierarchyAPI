using HierarchyAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HierarchyAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpPost("Insert")]
        public async Task<Role> Insert(Role role)
        {
            return await _roleRepository.Insert(role);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Role>> Update(Guid roleId, Role role)
        {
            return await _roleRepository.Update(roleId, role);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<Role>> Remove(Guid roleId)
        {
            return await _roleRepository.Remove(roleId);
        }
        [HttpGet("GetAllChildren")]
        public async Task<ActionResult<List<Role>>> GetAllChildren(Guid roleId)
        {
            return await _roleRepository.GetAllChildren(roleId);
        }
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            return await _roleRepository.GetAllRoles();
        }
        [HttpGet("GetSingle")]
        public async Task<Role> GetSingle(Guid roleId)
        {
            return await _roleRepository.GetSingle(roleId);
        }

    }
}
