using HierarchyAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
            Role toDelte = await _roleRepository.GetSingle(roleId);
            List<Role> Children = await _roleRepository.GetAllChildren(roleId);
            if ( ((Children).Count != 0))
            {
                foreach(var child in Children)
                {
                    child.ParentId = toDelte.ParentId;
                    child.Parent = toDelte.Parent;
                    _roleRepository.Update((Guid)child.Id,child);
                }
            }
            return await _roleRepository.Remove(roleId);
        }
        [HttpDelete("DeleteRecursive")]
        public async Task<ActionResult<Role>> RemoveRecursive(Guid roleId)
        {
            Role toDelte = await _roleRepository.GetSingle(roleId);
            List<Role> Children = await _roleRepository.GetAllChildren(roleId);
            if (((Children).Count != 0))
            {
                foreach (var child in Children)
                {
                    RemoveRecursive((Guid)child.Id);
                }
            }
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
        [HttpGet("Tree")]
        public async Task<string> Tree(Guid roleId)
        {
            List<Role> roles = await _roleRepository.GetAllRoles();
            return await GenerateTree(roles,"", roleId);
        }
        [NonAction]
        // Problem : tree has a lot of cost and database calls 
        // Solution1 :  Save in the database
        //      Problem : Inconsistency                 
        //          Solution : Have a version tracking everytime there is an update change
        //                      the version of the to outdated add a condition everytime the tree
        //                      is requested to get
        // Solution2 :  
        //      
        // Solution3 :  
        public async Task<string> GenerateTree(List<Role> roles,string spacing,Guid roleId)
        {
            string tree = "";
            tree += (roles.Find(r=>r.Id.Equals(roleId))).Name;
            List<Role> Children = roles.FindAll(r=>r.ParentId.Equals(roleId));
            foreach(var child in Children)
            {
                tree += "\n";
                tree += spacing+ "├── ";
                tree += await GenerateTree(roles,spacing+ "│   ", (Guid)child.Id );
            }

            return tree;
        }

    }
}
