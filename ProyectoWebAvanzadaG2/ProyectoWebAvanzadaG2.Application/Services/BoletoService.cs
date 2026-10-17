using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Application.Interfaces;
using ProyectoWebAvanzadaG2.Domain.Entities;
using ProyectoWebAvanzadaG2.Domain.Interfaces;

namespace ProyectoWebAvanzadaG2.Application.Services
{
    //Inyectamos ambos repositorios porque la compra requiere actualizar el asiento y crear el boleto
    public class BoletoService(IBoletoRepository boletoRepository, IAsientoRepository asientoRepository) : IBoletoService
    {
        public async Task ComprarBoletoAsync(int eventoId, int asientoId, string usuarioId)
        {
            //1. Validar que el asiento exista y no esté ocupado
            var asiento = await asientoRepository.ObtenerPorIdAsync(asientoId);
            if (asiento == null || asiento.EstaOcupado)
            {
                throw new InvalidOperationException("El asiento seleccionado ya no está disponible.");
            }

            //2. Marcar el asiento como ocupado para que nadie más pueda tomarlo
            asiento.EstaOcupado = true;
            await asientoRepository.ActualizarAsync(asiento);

            //3. Generar el boleto oficial
            var boleto = new Boleto
            {
                EventoId = eventoId,
                AsientoId = asientoId,
                UsuarioId = usuarioId,
                FechaCompra = DateTime.Now
            };

            await boletoRepository.AgregarAsync(boleto);
        }

        public async Task<IEnumerable<Boleto>> ObtenerBoletosDeUsuarioAsync(string usuarioId)
        {
            return await boletoRepository.ObtenerPorUsuarioAsync(usuarioId);
        }
    }
}