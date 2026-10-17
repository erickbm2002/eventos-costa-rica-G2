using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Application.Interfaces
{
    public interface IAsientoService
    {
        //Esta función será la encargada de fabricar la matriz de 100 asientos
        Task GenerarAsientosParaEventoAsync(int eventoId);
        Task<IEnumerable<Asiento>> ObtenerAsientosPorEventoAsync(int eventoId);
        Task<Asiento?> ObtenerAsientoPorIdAsync(int id);
    }
}