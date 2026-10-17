using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoWebAvanzadaG2.Domain.Entities
{
    public class Boleto
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }

        public int AsientoId { get; set; }
        public Asiento? Asiento { get; set; }

        public string UsuarioId { get; set; } = string.Empty;

        public DateTime FechaCompra { get; set; }
    }
}
