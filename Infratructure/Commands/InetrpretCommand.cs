using Application.Abstraction;
using Endpoint.Model;
using Infratructure.Fabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.Commands
{
    public class InetrpretCommand : ICommand
    {
        private readonly GameActionModel _gameActionModel;
        public InetrpretCommand(GameActionModel gameActionModel)
        {
            _gameActionModel = gameActionModel;
        }
        public void Execute()
        {
            var gameObject = Fabtics.CreateObjects(_gameActionModel.IdGame, _gameActionModel.IdObject);
            var gameOperation = Fabtics.CreateOperations(_gameActionModel.IdGame, _gameActionModel.IdOperation);

            gameOperation.Invoke(_gameActionModel.args);
        }
    }
}
