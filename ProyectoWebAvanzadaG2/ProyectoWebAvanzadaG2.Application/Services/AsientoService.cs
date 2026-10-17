using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Application.Interfaces;
using ProyectoWebAvanzadaG2.Domain.Entities;
using ProyectoWebAvanzadaG2.Domain.Interfaces;

namespace ProyectoWebAvanzadaG2.Application.Services
{
    public class AsientoService(IAsientoRepository asientoRepository) : IAsientoService
    {
        public async Task GenerarAsientosParaEventoAsync(int eventoId)
        {
            var asientos = new List<Asiento>();

            //Requerimiento del sistema: distribución de 100 personas, 10 filas x 10 asientos
            for (int fila = 1; fila <= 10; fila++)
            {
                for (int numero = 1; numero <= 10; numero++)
                {
                    asientos.Add(new Asiento
                    {
                        EventoId = eventoId,
                        Fila = fila,
                        Numero = numero,
                        EstaOcupado = false
                    });
                }
            }

            //Usamos el método de guardar en rango para mejor rendimiento
            await asientoRepository.AgregarRangoAsync(asientos);
        }

        public async Task<IEnumerable<Asiento>> ObtenerAsientosPorEventoAsync(int eventoId)
        {
            return await asientoRepository.ObtenerPorEventoAsync(eventoId);
        }

        public async Task<Asiento?> ObtenerAsientoPorIdAsync(int id)
        {
            return await asientoRepository.ObtenerPorIdAsync(id);
        }
    }
}