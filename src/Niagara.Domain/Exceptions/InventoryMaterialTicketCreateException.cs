using System;

namespace Niagara.Domain.Exceptions
{
    public class InventoryMaterialTicketCreateException : Exception
    {
        public InventoryMaterialTicketCreateException(string message) : base(message)
        {

        }
    }
}