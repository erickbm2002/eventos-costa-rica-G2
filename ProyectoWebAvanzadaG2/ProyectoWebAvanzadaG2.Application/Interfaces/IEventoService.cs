using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Application.Interfaces
{
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> ObtenerTodosLosEventosAsync();
        Task<Evento?> ObtenerEventoPorIdAsync(int id);
        Task CrearEventoAsync(Evento evento);
        Task ActualizarEventoAsync(Evento evento);
        Task EliminarEventoAsync(int id);
    }
}
