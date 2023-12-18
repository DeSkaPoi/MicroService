using Application.AppModel;
using Application.HttpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IHelperService
    {
        public Game CreateGame(List<GameObject> gameObjects, string name);
        public string GetToket(AuthPlayer authPlayer);
    }
}
