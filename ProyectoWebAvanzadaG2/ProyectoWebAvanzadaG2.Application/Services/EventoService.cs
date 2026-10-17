using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProyectoWebAvanzadaG2.Application.Interfaces;
using ProyectoWebAvanzadaG2.Domain.Entities;
using ProyectoWebAvanzadaG2.Domain.Interfaces;

namespace ProyectoWebAvanzadaG2.Application.Services
{
    //Se inyecta el servicio de asientos junto con el repositorio de eventos
    public class EventoService(IEventoRepository eventoRepository, IAsientoService asientoService) : IEventoService
    {
        public async Task<IEnumerable<Evento>> ObtenerTodosLosEventosAsync()
        {
            return await eventoRepository.ObtenerTodos().ToListAsync();
        }

        public async Task<Evento?> ObtenerEventoPorIdAsync(int id)
        {
            return await eventoRepository.ObtenerPorIdAsync(id);
        }

        public async Task CrearEventoAsync(Evento evento)
        {
            //1. Primero guardamos el evento en la base de datos.
            //Al hacer esto, Entity Framework le asigna automáticamente su 'Id'.
            await eventoRepository.AgregarAsync(evento);

            //2. Ahora que el evento ya tiene Id, le pedimos al servicio de asientos 
            //que genere la matriz de 10x10 asientos de forma automática.
            await asientoService.GenerarAsientosParaEventoAsync(evento.Id);
        }

        public async Task ActualizarEventoAsync(Evento evento)
        {
            await eventoRepository.ActualizarAsync(evento);
        }

        public async Task EliminarEventoAsync(int id)
        {
            await eventoRepository.EliminarAsync(id);
        }
    }
}