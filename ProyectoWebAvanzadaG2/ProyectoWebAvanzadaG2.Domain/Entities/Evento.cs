using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoWebAvanzadaG2.Domain.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string BannerPath { get; set; } = string.Empty; //Ruta de la imagen
        public bool EstaVendido { get; set; } = false; //Controla si el evento ya se vendió por completo

        // Relaciones
        public ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();
        public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
    }
}