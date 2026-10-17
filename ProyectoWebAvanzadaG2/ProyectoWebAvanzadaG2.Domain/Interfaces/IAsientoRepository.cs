using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Domain.Interfaces
{
    public interface IAsientoRepository
    {
        Task<IEnumerable<Asiento>> ObtenerPorEventoAsync(int eventoId);
        Task<Asiento?> ObtenerPorIdAsync(int id);
        Task AgregarRangoAsync(IEnumerable<Asiento> asientos); //Para guardar los 100 asientos de golpe
        Task ActualizarAsync(Asiento asiento);
    }
}
