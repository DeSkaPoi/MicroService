using Application.AppModel;
using Application.HttpModel;
using Endpoint.Model;
using Infratructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infratructure.Fabrics
{
    public static class Fabrics
    {
        public static List<Game> games = new();
        public static Game CreateGame(string name, List<GameObject> gameObjects, List<GameOperation> gameOperation)
        {
            return new Game { Id = Guid.NewGuid(), Name = name, GameObjects = gameObjects, GameOperation = gameOperation };
        }

        public static GameObject CreateObjects(Guid id)
        {
            return new GameObject { Id = id };
        }

        public static Action<object[]> CreateOperations(Guid IdGame, int IdOperation)
        {
            var game = games.FirstOrDefault(g => g.Id == IdGame);
            var operation = game.GameOperation.FirstOrDefault(o => o.Id == IdOperation);
            return operation.Operation;
        }

        public static InetrpretCommand CreateInetrpretCommand(GameActionModel gameObject) => new InetrpretCommand(gameObject);
    }
}
