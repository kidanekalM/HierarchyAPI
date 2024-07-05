using HierarchyAPI.Models;
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
            Role toDelte = await _roleRepository.GetSingle(roleId);
            List<Role> Children = await _roleRepository.GetAllChildren(roleId);
            if (((Children).Count != 0))
            {
                foreach (var child in Children)
                {
                    child.ParentId = toDelte.ParentId;
                    child.Parent = toDelte.Parent;
                    _roleRepository.Update((Guid)child.Id, child);
                }
            }
            return await _roleRepository.Remove(roleId);
        }
        [HttpDelete("DeleteRecursive")]
        public async Task<ActionResult<Role>> RemoveRecursive(Guid roleId)
        {
            return await _roleRepository.RemoveRecursive(roleId);
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
        public async Task<TreeNode> Tree(Guid roleId)
        {
            List<Role> roles = await _roleRepository.GetAllRoles();
            return await GenerateTree(roles, roleId);
        }
        [NonAction]
        public async Task<TreeNode> GenerateTree(List<Role> roles, Guid? roleId)
        {
            TreeNode RootNode;
            if (roleId == null)
            {
                var Root = roles.Find(r => r.ParentId == null);
                roleId = Root.Id;
                RootNode = new TreeNode(Root.Id, Root.Name);
            }
            else
            {
                var Root = roles.Find(r => r.Id == roleId);
                RootNode = new TreeNode(Root.Id, Root.Name);
            }
            List<Role> Children = roles.FindAll(r => r.ParentId == roleId);
            RootNode.Children = new List<TreeNode>();
            foreach (var child in Children)
            {
                TreeNode childNode = await GenerateTree(roles, (Guid)child.Id);
                RootNode.Children.Add(childNode);
            }
            return RootNode;
        }
    }
}
