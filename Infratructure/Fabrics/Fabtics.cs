using Application.Model;
using Endpoint.Model;
using Infratructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infratructure.Fabrics
{
    public static class Fabtics
    {
        static Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>() { { 1, new GameObject("1") }, { 2, new GameObject("2") } };
        static Dictionary<int, Action<object[]>> operation = new Dictionary<int, Action<object[]>>() { { 1, (objects) => Console.WriteLine(objects[0]) }, { 2, (objects) => Console.WriteLine(objects[1]) } };

        private static Dictionary<int, Dictionary<int, GameObject>> gameObjects = new() { { 11, objects } };
        private static Dictionary<int, Dictionary<int, Action<object[]>>> gameOperations = new() { { 11, operation } };

        public static GameObject CreateObjects(int IdGame, int IdObject)
        {
            gameObjects.TryGetValue(IdGame, out var objects);
            objects.TryGetValue(IdObject, out var objectGame);
            return objectGame;
        }

        public static Action<object[]> CreateOperations(int IdGame, int IdOperation)
        {
            gameOperations.TryGetValue(IdGame, out var objects);
            objects.TryGetValue(IdOperation, out var objectGame);
            return objectGame;
        }

        public static InetrpretCommand CreateInetrpretCommand(GameActionModel gameObject) => new InetrpretCommand(gameObject);
    }
}
