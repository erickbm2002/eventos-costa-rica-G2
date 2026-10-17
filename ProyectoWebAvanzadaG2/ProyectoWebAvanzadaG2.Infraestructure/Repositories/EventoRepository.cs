using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProyectoWebAvanzadaG2.Domain.Entities;
using ProyectoWebAvanzadaG2.Domain.Interfaces;
using ProyectoWebAvanzadaG2.Infraestructure.Data;

namespace ProyectoWebAvanzadaG2.Infraestructure.Repositories
{
    public class EventoRepository(ApplicationDbContext context) : IEventoRepository
    {
        public IQueryable<Evento> ObtenerTodos()
        {
            //AsNoTracking para mejorar el rendimiento en consultas de solo lectura
            return context.Eventos.AsNoTracking();
        }

        public async Task<Evento?> ObtenerPorIdAsync(int id)
        {
            return await context.Eventos.FindAsync(id);
        }

        public async Task AgregarAsync(Evento evento)
        {
            await context.Eventos.AddAsync(evento);
            await context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Evento evento)
        {
            context.Eventos.Update(evento);
            await context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var evento = await context.Eventos.FindAsync(id);
            if (evento != null)
            {
                context.Eventos.Remove(evento);
                await context.SaveChangesAsync();
            }
        }
    }
}