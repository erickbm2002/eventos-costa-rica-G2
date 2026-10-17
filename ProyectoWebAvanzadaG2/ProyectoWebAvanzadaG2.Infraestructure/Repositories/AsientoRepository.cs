using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProyectoWebAvanzadaG2.Domain.Entities;
using ProyectoWebAvanzadaG2.Domain.Interfaces;
using ProyectoWebAvanzadaG2.Infraestructure.Data;

namespace ProyectoWebAvanzadaG2.Infraestructure.Repositories
{
    public class AsientoRepository(ApplicationDbContext context) : IAsientoRepository
    {
        public async Task<IEnumerable<Asiento>> ObtenerPorEventoAsync(int eventoId)
        {
            return await context.Asientos
                .Where(a => a.EventoId == eventoId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Asiento?> ObtenerPorIdAsync(int id)
        {
            return await context.Asientos.FindAsync(id);
        }

        public async Task AgregarRangoAsync(IEnumerable<Asiento> asientos)
        {
            await context.Asientos.AddRangeAsync(asientos);
            await context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Asiento asiento)
        {
            context.Asientos.Update(asiento);
            await context.SaveChangesAsync();
        }
    }
}
