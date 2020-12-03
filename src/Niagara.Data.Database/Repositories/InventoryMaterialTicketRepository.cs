using System;
using System.Collections.Generic;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;

namespace Niagara.Data.Database.Repositories
{
    public class InventoryMaterialTicketRepository : IInventoryMaterialTicketRepository
    {
        public IReadOnlyList<InventoryMaterialTicket> GetAllByMaterialLogId(string materialLogId)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public InventoryMaterialTicket GetById(int id)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public IReadOnlyList<InventoryMaterialTicket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(InventoryMaterialTicket entity)
        {
            // TODO: Implement

            throw new NotImplementedException();
        }

        public void Update(InventoryMaterialTicket entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(InventoryMaterialTicket entity)
        {
            throw new NotImplementedException();
        }
    }
}