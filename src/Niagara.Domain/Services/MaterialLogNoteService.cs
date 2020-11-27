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
    public class MaterialLogNoteService : IMaterialLogNoteService
    {
        private readonly IMaterialLogNoteRepository _repository;

        public MaterialLogNoteService(IMaterialLogNoteRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<MaterialLogNoteModel> GetAllByLotNumber(string lotNumber)
        {
            return _repository.GetAllByMaterialLogId(lotNumber).OrderByDescending(x => x.DateTimeCreated)
                .Select(x => x.ToModel()).ToList();
        }

        public MaterialLogNoteModel Create(string materialLogLotNumber, string text)
        {
            var entity = new MaterialLogNote();

            entity.MaterialLogId = materialLogLotNumber;
            entity.Text = text;
            entity.DateTimeCreated = DateTime.Now;

            entity.CreatedBy = "LoggedIn User"; // temp
            
            _repository.Create(entity);

            return entity.ToModel();
        }
    }
}