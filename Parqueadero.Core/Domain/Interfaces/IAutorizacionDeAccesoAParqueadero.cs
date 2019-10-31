using System;
namespace Parqueadero.Core.Domain.Interfaces
{
    public interface IAutorizacionDeAccesoAParqueadero
    {
        Boolean ValidarAutorizacionParaAccederAlParqueadero(string placa);
    }
}
