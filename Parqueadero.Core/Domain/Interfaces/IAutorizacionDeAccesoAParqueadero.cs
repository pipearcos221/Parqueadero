namespace Parqueadero.Core.Domain.Interfaces
{
    public interface IAutorizacionDeAccesoAParqueadero
    {
        bool ValidarAutorizacionParaAccederAlParqueadero(string placa);
    }
}
