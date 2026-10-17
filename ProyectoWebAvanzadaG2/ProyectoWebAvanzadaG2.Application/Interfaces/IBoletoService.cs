using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Application.Interfaces
{
    public interface IBoletoService
    {
        //Orquesta la lógica de apartar el asiento y generar el tiquete
        Task ComprarBoletoAsync(int eventoId, int asientoId, string usuarioId);
        Task<IEnumerable<Boleto>> ObtenerBoletosDeUsuarioAsync(string usuarioId);
    }
}