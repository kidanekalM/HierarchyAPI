using HierarchyAPI.Controllers;
using HierarchyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HierarchyAPI.Test
{
    public class RoleControllerTest:IClassFixture<RoleController>
    {
        RoleController _roleController;
        IRoleRepository _roleRepository;
        public RoleControllerTest(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _roleController = new RoleController(roleRepository);
        }
        [Fact]
        public async Task TestAddRole()
        {
            // Arrange: Create a new Role
            var newRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Release Manager",
                Description = "Manages Releases",
                ParentId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afc4")
            };

            var result = await _roleController.Insert(newRole);

            Assert.IsType<CreatedAtActionResult>(result);
            var addedRole = await _roleRepository.GetSingle((Guid)newRole.Id);
            Assert.NotNull(addedRole);
            Assert.Equal(newRole.Name, addedRole.Name);
        }

    }
}