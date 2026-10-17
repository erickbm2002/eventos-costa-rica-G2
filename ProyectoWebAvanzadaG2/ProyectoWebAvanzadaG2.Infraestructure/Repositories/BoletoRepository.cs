using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProyectoWebAvanzadaG2.Domain.Entities;
using ProyectoWebAvanzadaG2.Domain.Interfaces;
using ProyectoWebAvanzadaG2.Infraestructure.Data;

namespace ProyectoWebAvanzadaG2.Infraestructure.Repositories
{
    public class BoletoRepository(ApplicationDbContext context) : IBoletoRepository
    {
        public async Task<IEnumerable<Boleto>> ObtenerPorUsuarioAsync(string usuarioId)
        {
            //Se incluye el Evento y el Asiento para poder mostrar el detalle completo en la vista
            return await context.Boletos
                .Include(b => b.Evento)
                .Include(b => b.Asiento)
                .Where(b => b.UsuarioId == usuarioId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AgregarAsync(Boleto boleto)
        {
            await context.Boletos.AddAsync(boleto);
            await context.SaveChangesAsync();
        }
    }
}