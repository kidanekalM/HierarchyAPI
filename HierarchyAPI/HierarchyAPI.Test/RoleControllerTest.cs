using HierarchyAPI.Controllers;
using HierarchyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HierarchyAPI.Test
{
    public class RoleControllerTest
    {
        RoleController _roleController;
        Mock<IRoleRepository> _roleRepositoryMock;
        public RoleControllerTest()
        {
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _roleController = new RoleController(_roleRepositoryMock.Object);
            
        }
        [Fact]
        public async Task TestAddRole()
        {
            var newRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Release Manager",
                Description = "Manages Releases",
                ParentId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afc4"),
                Parent = null
            };
            var result = await _roleController.Insert(newRole);
            Assert.Equal("", "");  
            //Assert.IsType<Task<Role>>(result);
            //Assert.ThrowsAsync<Exception>(() => _roleRepositoryMock.Object.GetSingle((Guid)newRole.Id));
            var addedRole = await _roleRepositoryMock.Object.GetSingle((Guid)newRole.Id);
            //Assert.NotNull(addedRole);
            
            Assert.Equal(newRole.Name, addedRole.Name);
        }

    }
}