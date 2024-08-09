using HierarchyAPI.Models;
using HierarchyAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using HierarchyAPI.Models.Queries;
using HierarchyAPI.Models.Commands;
namespace HierarchyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly IRoleCommandsRepository _roleCommandsRepository;
        private readonly IMediator _mediator;
        public RoleController(IRoleQueryRepository roleQueryRepository,IRoleCommandsRepository roleCommandsRepository,IMediator mediator)
        {
            _roleQueryRepository = roleQueryRepository;
            _roleCommandsRepository = roleCommandsRepository;
            _mediator = mediator;
        }
        //Accept cmd
        [HttpPost("Insert")]
        public async Task<Role> Insert(InsertCommand insertCommand)
        {
            return await _mediator.Send(insertCommand);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Role>> Update(UpdateCommand updateCommand)
        {
            return await _mediator.Send(updateCommand);
        }
        [HttpDelete("DeleteByCandidate")]
        public async Task<Role> DeleteByCandidate(DeleteByCandidateCommand deleteCommand)
        {
            return await _mediator.Send(deleteCommand);
        }
        [HttpDelete("Delete")]
        public async Task<Role> Remove(DeleteCommand deleteCommand)
        {
            return await _mediator.Send(deleteCommand);
        }
        [HttpDelete("DeleteRecursive")]
        public async Task<ActionResult<Role>> RemoveRecursive(RemoveRecursiveCommand removeRecursiveCommand)
        {
            return await _mediator.Send(removeRecursiveCommand);
        }
        [HttpGet("GetAllChildren")]
        public async Task<List<Role>> GetAllChildren([FromQuery]GetAllChildrenQuery getAllChildrenQuery)
        {
            //var children = await _mediator.Send(getAllChildrenQuery);
            var children = await _roleQueryRepository.GetAllChildren(getAllChildrenQuery.guid); 
            return children;
        }
        [HttpGet("GetAllRoles")]
        public async Task<List<Role>> GetAllRoles()
        {
            //var roles =  await _mediator.Send(new GetAllRolesQuery());
            var roles = await _roleQueryRepository.GetAllRoles();
            return roles;
        }
        [HttpGet("GetSingle")]
        public async Task<Role> GetSingle([FromQuery]GetSingleQuery getSingleQuery)
        {
            //return await _mediator.Send(getSingleQuery);
            return await _roleQueryRepository.GetSingle(getSingleQuery.RoleId);
        }
        [HttpGet("GetCandidate")]
        public async Task<List<Role>> GetCandidates([FromQuery]GetCandidatesQuery getCandidatesQuery)
        {
            return await _roleQueryRepository.GetCandidates(getCandidatesQuery.RoleId); 
        }
        [HttpGet("Tree")]
        public async Task<TreeNode> Tree(Guid roleId)
        {
            return await _roleQueryRepository.Tree(roleId);
        }
        
    }
}
