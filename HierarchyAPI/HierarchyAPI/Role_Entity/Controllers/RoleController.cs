using Microsoft.AspNetCore.Mvc;
using MediatR;   
using HierarchyAPI.Role_Entity.Models;
using HierarchyAPI.Role_Entity.Models.Commands;
using HierarchyAPI.Role_Entity.Models.Queries;
using HierarchyAPI.Role_Entity.Models.Repositories;
namespace HierarchyAPI.Role_Entity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public RoleController(IRoleQueryRepository roleQueryRepository, IMediator mediator,ILogger<RoleController> logger)
        {
            _roleQueryRepository = roleQueryRepository;
            _mediator = mediator;
            _logger = logger;
        }
        //Accept cmd
        [HttpPost("Insert")]
        public async Task<Role> Insert(InsertCommand insertCommand)
        {
            _logger.LogInformation("Insert Command", DateTime.UtcNow.ToLongTimeString());

            return await _mediator.Send(insertCommand);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Role>> Update(UpdateCommand updateCommand)
        {
            _logger.LogInformation("Update Command", DateTime.UtcNow.ToLongTimeString());

            return await _mediator.Send(updateCommand);
        }
        [HttpDelete("DeleteByCandidate")]
        public async Task<Role> DeleteByCandidate(DeleteByCandidateCommand deleteCommand)
        {
            _logger.LogInformation("Delete By Candidate Command", DateTime.UtcNow.ToLongTimeString());

            return await _mediator.Send(deleteCommand);
        }
        [HttpDelete("Delete")]
        public async Task<Role> Remove(DeleteCommand deleteCommand)
        {
            _logger.LogInformation("Remove Command", DateTime.UtcNow.ToLongTimeString());

            return await _mediator.Send(deleteCommand);
        }
        [HttpDelete("DeleteRecursive")]
        public async Task<ActionResult<Role>> RemoveRecursive(RemoveRecursiveCommand removeRecursiveCommand)
        {
            _logger.LogInformation("Remove Recursive Command", DateTime.UtcNow.ToLongTimeString());
            return await _mediator.Send(removeRecursiveCommand);
        }
        [HttpGet("GetAllChildren")]
        public async Task<List<Role>> GetAllChildren([FromQuery] GetAllChildrenQuery getAllChildrenQuery)
        {
            _logger.LogInformation("Query Children", DateTime.UtcNow.ToLongTimeString());
            var children = await _roleQueryRepository.GetAllChildren(getAllChildrenQuery.guid);
            return children;
        }
        [HttpGet("GetAllRoles")]
        public async Task<List<Role>> GetAllRoles()
        {
            _logger.LogInformation("Reading All Roles", DateTime.UtcNow.ToLongTimeString());
            var roles = await _roleQueryRepository.GetAllRoles();
            return roles;
        }
        [HttpGet("GetSingle")]
        public async Task<Role> GetSingle([FromQuery] GetSingleQuery getSingleQuery)
        {
            _logger.LogInformation("Reading Single", DateTime.UtcNow.ToLongTimeString());
            return await _roleQueryRepository.GetSingle(getSingleQuery.RoleId);
        }
        [HttpGet("GetCandidate")]
        public async Task<List<Role>> GetCandidates([FromQuery] GetCandidatesQuery getCandidatesQuery)
        {
            _logger.LogInformation("Reading Candidates", DateTime.UtcNow.ToLongTimeString());
            return await _roleQueryRepository.GetCandidates(getCandidatesQuery.RoleId);
        }
        [HttpGet("Tree")]
        public async Task<TreeNode> Tree(Guid roleId)
        {
            _logger.LogInformation("Reading Tree", DateTime.UtcNow.ToLongTimeString());
            return await _roleQueryRepository.Tree(roleId);
        }

    }
}
