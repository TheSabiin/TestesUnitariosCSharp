using System;
using System.Threading.Tasks;
using TodoMvc.Data;
using TodoMvc.Models;
using ToDoMvc.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ToDoMvc.UnitTests
{
    class ToDoItemServiceShould
    {
        [Fact]
        public async Task AddNewItemAsIncompleteWithDueDate()
        {
           var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_AddNewItem")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var service = new ToDoItemService(context);

                var fakeUser = new ApplicationUser
                {
                    Id = "fake-000",
                    UserName = "fake@example.com"
                };

                await service.AddItemAsync(new NewToDoItem
                {
                    Title = "Testing?",
                    DueAt = DateTimeOffset.Now.AddDays(3)
                }, fakeUser);
            }
        }
        
    }
}
