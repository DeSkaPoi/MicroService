using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface ICommandRepository
    {
        public void Enqueue(ICommand command);
        public ICommand PeekAndDeque();
        public bool IsEmpty();
    }
}
