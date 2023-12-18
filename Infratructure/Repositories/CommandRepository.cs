using Application.Abstraction;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly ConcurrentQueue<ICommand> _commands;

        public CommandRepository()
        {
            _commands = new ConcurrentQueue<ICommand>();
        }

        public void Enqueue(ICommand command) 
        {
            _commands.Enqueue(command);
        }

        public bool IsEmpty()
        {
            return _commands.Count > 0 ? false : true;
        }

        public ICommand PeekAndDeque() 
        {
            _commands.TryPeek(out ICommand command);
            _commands.TryDequeue(out command);
            return command;
        }
    }
}
