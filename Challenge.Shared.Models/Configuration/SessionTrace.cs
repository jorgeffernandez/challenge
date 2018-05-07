namespace Challenge.Shared.Models.Configuration
{
    using System;
   
    public class SessionTrace
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string Action { get; set; }
        public string Segmento { get; set; }
        public string DireccionIp { get; set; }
        public string TipoImplementacion { get; set; }
        public string Entorno { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
