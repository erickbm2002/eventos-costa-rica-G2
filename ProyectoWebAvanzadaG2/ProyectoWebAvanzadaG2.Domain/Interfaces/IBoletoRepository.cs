using System;
using System.Collections.Generic;
using System.Text;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Domain.Interfaces
{
    public interface IBoletoRepository
    {
        Task<IEnumerable<Boleto>> ObtenerPorUsuarioAsync(string usuarioId); //para la pantalla "Ver mis boletos"
        Task AgregarAsync(Boleto boleto);
    }
}