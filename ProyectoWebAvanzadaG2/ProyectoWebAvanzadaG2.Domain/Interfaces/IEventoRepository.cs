using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Domain.Interfaces
{
    public interface IEventoRepository
    {
        //Se utiliza IQueryable en lugar de IEnumerable por el rendimiento
        IQueryable<Evento> ObtenerTodos();

        //métodos asíncronos
        Task<Evento?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Evento evento);
        Task ActualizarAsync(Evento evento);
        Task EliminarAsync(int id);
    }
}
