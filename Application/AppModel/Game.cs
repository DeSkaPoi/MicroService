using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppModel
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public List<GameObject> GameObjects { get; set; }
        public List<GameOperation> GameOperation { get; set; }
    }
}
