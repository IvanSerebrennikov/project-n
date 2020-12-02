using System;
using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Domain.Exceptions;
using Niagara.Domain.Mapping;
using Niagara.Domain.Models;
using Niagara.Domain.Services.Interfaces;

namespace Niagara.Domain.Services
{
    public class InventoryMaterialTicketService : IInventoryMaterialTicketService
    {
        private readonly IInventoryMaterialTicketRepository _inventoryMaterialTicketRepository;
        private readonly IMaterialLogRepository _materialLogRepository;

        public InventoryMaterialTicketService(
            IInventoryMaterialTicketRepository inventoryMaterialTicketRepository,
            IMaterialLogRepository materialLogRepository)
        {
            _materialLogRepository = materialLogRepository;
            _inventoryMaterialTicketRepository = inventoryMaterialTicketRepository;
        }

        public IReadOnlyList<InventoryMaterialTicketModel> GetAllByLotNumber(string lotNumber)
        {
            return _inventoryMaterialTicketRepository.GetAllByMaterialLogId(lotNumber).OrderByDescending(x => x.DateCreated)
                .Select(x => x.ToModel()).ToList();
        }

        public InventoryMaterialTicketModel GetById(int ticketId)
        {
            return _inventoryMaterialTicketRepository.GetById(ticketId).ToModel();
        }

        public InventoryMaterialTicketModel Create(InventoryMaterialTicketModel model)
        {
            var materialLog = _materialLogRepository.GetById(model.MaterialLogLotNumber);

            if (materialLog == null)
            {
                throw new InventoryMaterialTicketCreateException("Related Material Log was not found.");
            }

            if (materialLog.Quantity < model.QuantityIssued)
            {
                throw new InventoryMaterialTicketCreateException(
                    $"Related Material Log has only {materialLog.Quantity} quantity.");
            }

            var entity = new InventoryMaterialTicket();

            entity.MapFromModel(model);
            entity.DateCreated = DateTime.Now.Date;

            entity.JobTrackNumber = $"JT{new Random(1000).Next(1000, 9999)}"; // temp
            entity.CreatedBy = "LoggedIn User"; // temp
            
            _inventoryMaterialTicketRepository.Create(entity);

            materialLog.Quantity -= model.QuantityIssued;

            _materialLogRepository.Update(materialLog);

            return entity.ToModel();
        }
    }
}