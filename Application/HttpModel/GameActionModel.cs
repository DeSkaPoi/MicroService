namespace Endpoint.Model
{
    public class GameActionModel
    {
        public Guid IdGame { get; set; }
        public Guid IdObject { get; set; }
        public int IdOperation { get; set; }
        public string Token { get; set; }
        public object[] args { get; set; }
    }
}