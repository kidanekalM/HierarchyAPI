using MediatR;
namespace HierarchyAPI.Models.Commands
{
    public class DeleteByCandidateCommand:IRequest<Role>
    {
        public Guid Deleted {  get; set; }
        public Guid Candidate { get; set; }
    }
}
