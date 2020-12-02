using System.Collections.Generic;
using System.Linq;
using Niagara.Data.Common.Entities;
using Niagara.Data.Common.RepositoryInterfaces;
using Niagara.Domain.Mapping;
using Niagara.Domain.Models;
using Niagara.Domain.Services.Interfaces;

namespace Niagara.Domain.Services
{
    public class SelectableOptionService : ISelectableOptionService
    {
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IPartNumberRepository _partNumberRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IShapeRepository _shapeRepository;
        private readonly IMaterialLogTypeRepository _materialLogTypeRepository;

        public SelectableOptionService(
            IUnitOfMeasureRepository unitOfMeasureRepository,
            IPartNumberRepository partNumberRepository,
            ISupplierRepository supplierRepository,
            IShapeRepository shapeRepository,
            IMaterialLogTypeRepository materialLogTypeRepository
            )
        {
            _unitOfMeasureRepository = unitOfMeasureRepository;
            _partNumberRepository = partNumberRepository;
            _supplierRepository = supplierRepository;
            _shapeRepository = shapeRepository;
            _materialLogTypeRepository = materialLogTypeRepository;
        }

        public IReadOnlyList<SelectableOptionModel> GetUnitOfMeasures()
        {
            return _unitOfMeasureRepository.GetAll().Select(x => x.ToModel()).ToList();
        }

        public IReadOnlyList<SelectableOptionModel> GetPartNumbers()
        {
            return _partNumberRepository.GetAll().Select(x => x.ToModel()).ToList();
        }

        public IReadOnlyList<SelectableOptionModel> GetSuppliers()
        {
            return _supplierRepository.GetAll().Select(x => x.ToModel()).ToList();
        }

        public IReadOnlyList<SelectableOptionModel> GetShapes()
        {
            return _shapeRepository.GetAll().Select(x => x.ToModel()).ToList();
        }

        public IReadOnlyList<SelectableOptionModel> GetMaterialLogTypes()
        {
            return _materialLogTypeRepository.GetAll().Select(x => x.ToModel()).ToList();
        }
    }
}