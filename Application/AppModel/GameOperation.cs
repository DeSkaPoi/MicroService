using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppModel
{
    public class GameOperation
    {
        public int Id { get; set; }
        public Action<object[]> Operation { get; set; }
    }
}
