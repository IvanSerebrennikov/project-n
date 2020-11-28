using System;
using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Domain.Mapping;
using Niagara.Domain.Models;
using Niagara.Domain.Services.Interfaces;

namespace Niagara.Domain.Services
{
    public class InventoryMaterialTicketService : IInventoryMaterialTicketService
    {
        private readonly IInventoryMaterialTicketRepository _repository;

        public InventoryMaterialTicketService(IInventoryMaterialTicketRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<InventoryMaterialTicketModel> GetAllByLotNumber(string lotNumber)
        {
            return _repository.GetAllByMaterialLogId(lotNumber).OrderByDescending(x => x.DateCreated)
                .Select(x => x.ToModel()).ToList();
        }

        public InventoryMaterialTicketModel Create(InventoryMaterialTicketModel model)
        {
            var entity = new InventoryMaterialTicket();

            entity.MapFromModel(model);
            entity.DateCreated = DateTime.Now.Date;

            entity.JobTrackNumber = $"JT{new Random(1000).Next(1000, 9999)}"; // temp
            entity.CreatedBy = "LoggedIn User"; // temp
            
            _repository.Create(entity);

            return entity.ToModel();
        }
    }
}