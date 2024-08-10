using HierarchyAPI.Role_Entity.Models;
using HierarchyAPI.Role_Entity.Controllers;
using HierarchyAPI.Role_Entity.Models.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Windows.Input;

namespace HierarchyAPI.Test
{
    public class RoleControllerTest
    {
        RoleController _roleController;
        Mock<IRoleQueryRepository> _roleQueryRepositoryMock;
        Mock<IRoleCommandsRepository> _rolecmdRepositoryMock;
        Mock<IMediator> _mediatorMock;


        public RoleControllerTest()
        {
            _roleQueryRepositoryMock = new Mock<IRoleQueryRepository>();
            _rolecmdRepositoryMock = new Mock<IRoleCommandsRepository>();
            _mediatorMock = new Mock<IMediator>();
            _roleController = new RoleController(_roleQueryRepositoryMock.Object,_rolecmdRepositoryMock.Object,_mediatorMock.Object);
            
        }
        [Fact]
        public async Task TestAddRole()
        {
            var newRole = new Role
            {
                Id = Guid.NewGuid(),
                Role_Name = "Release Manager",
                Role_Description = "Manages Releases",
                Parent_Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afc4"),
                Parent = null
            };
            var cmd = new Role_Entity.Models.Commands.InsertCommand()
            {
                Role_Name = "Release Manager",
                Role_Description = "Manages Releases",
                Parent_Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afc4"),
            };
            var result = await _roleController.Insert(cmd);
            Assert.Equal("", "");  
            //Assert.IsType<Task<Role>>(result);
            //Assert.ThrowsAsync<Exception>(() => _roleRepositoryMock.Object.GetSingle((Guid)newRole.Id));
            var addedRole = await _roleQueryRepositoryMock.Object.GetSingle((Guid)newRole.Id);
            //Assert.NotNull(addedRole);
            
            Assert.Equal(newRole.Role_Name, addedRole.Role_Name);
        }

    }
}