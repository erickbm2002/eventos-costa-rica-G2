using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoWebAvanzadaG2.Domain.Entities
{
    public class Asiento
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }

        public int Fila { get; set; } 
        public int Numero { get; set; }
        public bool EstaOcupado { get; set; } = false;
    }
}
