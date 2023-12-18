using Endpoint.Controllers;
using Endpoint.Model;
using Infratructure.Repositories;
using Infratructure.Services;
using System.Diagnostics;

namespace TestAPI
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var commandRepo = new CommandRepository();
            var controller = new EndpointController(commandRepo);
            object[] args = { "TMP1" };
            var model = new GameActionModel() { IdGame = 11, IdObject = 1, IdOperation = 1, args = args };

            controller.Get(model);

            Assert.False(commandRepo.IsEmpty());
        }

        [Fact]
        public async Task Test2()
        {
            var commandRepo = new CommandRepository();
            var controller = new EndpointController(commandRepo);
            object[] args = { "TMP1" };
            var model = new GameActionModel() { IdGame = 11, IdObject = 1, IdOperation = 1, args = args };

            controller.Get(model);
            StartService startService = new StartService(commandRepo);
            startService.Execute();

            Assert.True(commandRepo.IsEmpty());
        }
    }
}