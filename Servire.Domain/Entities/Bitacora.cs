namespace Servire.Domain.Entities
{
    public class Bitacora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Username { get; set; } = "";
        public string Accion { get; set; } = "";
        public string Mensaje { get; set; } = "";
    }
}