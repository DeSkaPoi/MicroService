using Application.Abstraction;
using Application.AppModel;
using Application.HttpModel;
using Endpoint.Controllers;
using Endpoint.Model;
using Infratructure.Repositories;
using Infratructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace TestAPI
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var commandRepo = new CommandRepository();
            var controller = new EndpointController(commandRepo, new HelperService());
            object[] args = { "TMP1" };
            var model = new List<GameObject>() { new GameObject { Id = Guid.Parse("0009098d-dae7-46cf-b17f-325a43005836") }, new GameObject { Id = Guid.Parse("9a7cc5f8-37a7-41ed-b778-d3ef48483239") } };

            ObjectResult game = (ObjectResult)controller.CreateGame(model);
            var res = (Guid)game.Value;

            Assert.False(res == Guid.Empty);
        }

        [Fact]
        public async Task Test2()
        {
            var commandRepo = new CommandRepository();
            var controller = new EndpointController(commandRepo, new HelperService());
            object[] args = { "TMP1" };
            var model = new List<GameObject>() { new GameObject { Id = Guid.Parse("0009098d-dae7-46cf-b17f-325a43005836") }, new GameObject { Id = Guid.Parse("9a7cc5f8-37a7-41ed-b778-d3ef48483239") } };

            ObjectResult game = (ObjectResult)controller.CreateGame(model);
            var res = (Guid)game.Value;

            ObjectResult auth = (ObjectResult)controller.AuthPlayer(new AuthPlayer { IdGame = res, IdObject = Guid.Parse("9a7cc5f8-37a7-41ed-b778-d3ef48483239") });

            var token = auth.Value.ToString();

            Assert.False(string.IsNullOrEmpty(token));
        }
    }
}