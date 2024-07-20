using MediatR;

using System.Windows.Input;

namespace HierarchyAPI.Models.Commands
{
    public class InsertCommand:IRequest<Role>
    {
        public Role Role { get; set; }
    }
}
