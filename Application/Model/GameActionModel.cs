namespace Endpoint.Model
{
    public class GameActionModel
    {
        public int IdGame { get; set; }
        public int IdObject { get; set; }
        public int IdOperation { get; set; }
        public object[] args { get; set; }
    }
}