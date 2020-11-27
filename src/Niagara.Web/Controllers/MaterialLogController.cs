using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niagara.Domain.Models;
using Niagara.Domain.Services.Interfaces;
using Niagara.Web.Models;

namespace Niagara.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialLogController : ControllerBase
    {
        private readonly IMaterialLogService _materialLogService;
        private readonly ISelectableOptionService _selectableOptionService;

        public MaterialLogController(IMaterialLogService materialLogService, ISelectableOptionService selectableOptionService)
        {
            _materialLogService = materialLogService;
            _selectableOptionService = selectableOptionService;
        }

        [HttpGet("all")]
        public IEnumerable<MaterialLogReducedModel> GetAll()
        {
            return _materialLogService.GetAllReduced();
        }

        [HttpGet("single/{lotNumber}")]
        public IActionResult Get(string lotNumber)
        {
            var materialLogModel = _materialLogService.GetByLotNumber(lotNumber);

            if (materialLogModel == null)
            {
                return BadRequest("Material Log was not found.");
            }

            return Ok(materialLogModel);
        }

        [HttpGet("selectableOptions")]
        public IActionResult GetSelectableOptions()
        {
            var unitOfMeasures = _selectableOptionService.GetUnitOfMeasures();
            var partNumbers = _selectableOptionService.GetPartNumbers();
            var suppliers = _selectableOptionService.GetSuppliers();
            var shapes = _selectableOptionService.GetShapes();
            var materialLogTypes = _selectableOptionService.GetMaterialLogTypes();

            return Ok(new
            {
                unitOfMeasures, 
                partNumbers, 
                suppliers, 
                shapes, 
                materialLogTypes
            });
        }

        [HttpPost]
        public IActionResult Create(MaterialLogSaveRequest request)
        {
            var materialLogModel = request.MaterialLog;

            materialLogModel.DefaultProperties.PartNumberId =
                GetPartNumberIdWithCreateNewOneIfNeeded(request.PartNumber);
            materialLogModel.DefaultProperties.SupplierId =
                GetSupplierIdWithCreateNewOneIfNeeded(request.Supplier);

            var createdMaterialLogModel = _materialLogService.Create(materialLogModel);

            return Ok(createdMaterialLogModel);
        }

        [HttpPut]
        public IActionResult Update(MaterialLogSaveRequest request)
        {
            var materialLogModel = request.MaterialLog;

            materialLogModel.DefaultProperties.PartNumberId =
                GetPartNumberIdWithCreateNewOneIfNeeded(request.PartNumber);
            materialLogModel.DefaultProperties.SupplierId =
                GetSupplierIdWithCreateNewOneIfNeeded(request.Supplier);

            var updatedMaterialLogModel = _materialLogService.Update(materialLogModel);

            if (updatedMaterialLogModel == null)
            {
                return BadRequest("Material Log was not found.");
            }

            return Ok();
        }

        private int GetPartNumberIdWithCreateNewOneIfNeeded(string partNumberValue)
        {
            var partNumber =
                _selectableOptionService.GetPartNumberByValue(partNumberValue) ??
                _selectableOptionService.CreatePartNumber(partNumberValue);

            return partNumber.Id;
        }

        private int GetSupplierIdWithCreateNewOneIfNeeded(string supplierValue)
        {
            var supplier =
                _selectableOptionService.GetPartNumberByValue(supplierValue) ??
                _selectableOptionService.CreatePartNumber(supplierValue);

            return supplier.Id;
        }
    }
}
