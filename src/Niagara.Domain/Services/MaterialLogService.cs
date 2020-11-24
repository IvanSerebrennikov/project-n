﻿using System;
using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Domain.Mapping;
using Niagara.Domain.Models;
using Niagara.Domain.Services.Interfaces;

namespace Niagara.Domain.Services
{
    public class MaterialLogService : IMaterialLogService
    {
        private readonly IMaterialLogRepository _repository;

        public MaterialLogService(IMaterialLogRepository repository)
        {
            _repository = repository;
        }

        public MaterialLogModel GetByLotNumber(string lotNumber)
        {
            return _repository.GetById(lotNumber).ToModel();
        }

        public IReadOnlyList<MaterialLogModel> GetAll()
        {
            return _repository.GetAll().Select(x => x.ToModel()).ToList();
        }

        public MaterialLogModel Create(MaterialLogModel model)
        {
            var entity = new MaterialLog();

            entity.MapFromModel(model);
            entity.DateCreated = DateTime.Now.Date;

            _repository.Create(entity);

            return entity.ToModel();
        }

        public MaterialLogModel Update(MaterialLogModel model)
        {
            var entity = _repository.GetById(model.LotNumber);

            if (entity == null)
                return null;

            entity.MapFromModel(model);
            entity.DateUpdated = DateTime.Now.Date;

            _repository.Update(entity);

            return entity.ToModel();
        }
    }
}