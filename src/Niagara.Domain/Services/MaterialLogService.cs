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
    public class MaterialLogService : IMaterialLogService
    {
        private readonly IMaterialLogRepository _materialLogRepository;
        private readonly IPartNumberRepository _partNumberRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMaterialLogNoteRepository _materialLogNoteRepository;

        public MaterialLogService(
            IMaterialLogRepository materialLogRepository,
            IPartNumberRepository partNumberRepository,
            ISupplierRepository supplierRepository,
            IMaterialLogNoteRepository materialLogNoteRepository)
        {
            _materialLogRepository = materialLogRepository;
            _partNumberRepository = partNumberRepository;
            _supplierRepository = supplierRepository;
            _materialLogNoteRepository = materialLogNoteRepository;
        }

        public MaterialLogModel GetByLotNumber(string lotNumber)
        {
            return _materialLogRepository.GetById(lotNumber).ToModel();
        }

        public IReadOnlyList<MaterialLogReducedModel> GetAllReduced(int? skip = null, int? take = null)
        {
            return _materialLogRepository.GetAllReduced(skip, take)
                .Select(x => x.ToReducedModel()).ToList();
        }

        public int Count()
        {
            return _materialLogRepository.Count();
        }

        public MaterialLogModel Create(MaterialLogModel model, string partNumberValue, string supplierValue, IReadOnlyList<string> newNotes)
        {
            var entity = new MaterialLog();

            entity.MapFromModel(model);
            entity.DateCreated = DateTime.Now.Date;

            SetCustomSelectableOptionsWithCreateNewOneIfNeeded(entity, partNumberValue, supplierValue);

            entity.PONumber = $"PO{new Random(1000).Next(1000, 9999)}"; // temp
            entity.CreatedBy = "LoggedIn User"; // temp
            
            _materialLogRepository.Create(entity);

            CreateNotes(entity.Id, newNotes);

            return entity.ToModel();
        }

        public MaterialLogModel Update(MaterialLogModel model, string partNumberValue, string supplierValue, IReadOnlyList<string> newNotes)
        {
            var entity = _materialLogRepository.GetById(model.DefaultProperties.LotNumber);

            if (entity == null)
                throw new MaterialLogUpdateException("Material Log was not found.");

            entity.MapFromModel(model);
            entity.DateUpdated = DateTime.Now.Date;

            SetCustomSelectableOptionsWithCreateNewOneIfNeeded(entity, partNumberValue, supplierValue);

            _materialLogRepository.Update(entity);

            CreateNotes(entity.Id, newNotes);

            return entity.ToModel();
        }

        public IReadOnlyList<MaterialLogNoteModel> GetNotes(string lotNumber)
        {
            return _materialLogNoteRepository.GetAllByMaterialLogId(lotNumber).OrderByDescending(x => x.DateTimeCreated)
                .Select(x => x.ToModel()).ToList();
        }

        #region private

        #region Custom selectable options

        private void SetCustomSelectableOptionsWithCreateNewOneIfNeeded(MaterialLog materialLogEntity, string partNumberValue, string supplierValue)
        {
            var partNumber =
                _partNumberRepository.GetByValue(partNumberValue) ??
                CreatePartNumber(partNumberValue);

            materialLogEntity.PartNumberId = partNumber.Id;

            var supplier =
                _supplierRepository.GetByValue(supplierValue) ??
                CreateSupplier(supplierValue);

            materialLogEntity.SupplierId = supplier.Id;
        }

        private PartNumber CreatePartNumber(string value)
        {
            var entity = new PartNumber
            {
                Value = value
            };

            _partNumberRepository.Create(entity);

            return entity;
        }

        private Supplier CreateSupplier(string value)
        {
            var entity = new Supplier
            {
                Value = value
            };

            _supplierRepository.Create(entity);

            return entity;
        }

        #endregion

        #region Notes

        private void CreateNotes(string materialLogId, IReadOnlyList<string> notes)
        {
            foreach (var note in notes)
            {
                if (string.IsNullOrWhiteSpace(note))
                    continue;

                CreateNote(materialLogId, note);
            }
        }

        private void CreateNote(string materialLogId, string text)
        {
            var entity = new MaterialLogNote();

            entity.MaterialLogId = materialLogId;
            entity.Text = text;
            entity.DateTimeCreated = DateTime.Now;

            entity.CreatedBy = "LoggedIn User"; // temp

            _materialLogNoteRepository.Create(entity);
        }

        #endregion

        #endregion
    }
}