using System;
namespace Parqueadero.Core.Domain.Exceptions
{
    [Serializable]
    public class ParkingAccessException : Exception
    {
        public ParkingAccessException() { }

        public ParkingAccessException(string message) : base(message)
        {
        }

    }
}
