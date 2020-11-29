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
        private readonly IMaterialLogNoteService _materialLogNoteService;
        private readonly IInventoryMaterialTicketService _inventoryMaterialTicketService;

        public MaterialLogController(
            IMaterialLogService materialLogService, 
            ISelectableOptionService selectableOptionService,
            IMaterialLogNoteService materialLogNoteService,
            IInventoryMaterialTicketService inventoryMaterialTicketService)
        {
            _materialLogService = materialLogService;
            _selectableOptionService = selectableOptionService;
            _materialLogNoteService = materialLogNoteService;
            _inventoryMaterialTicketService = inventoryMaterialTicketService;
        }

        [HttpGet]
        public IEnumerable<MaterialLogReducedModel> GetAll()
        {
            return _materialLogService.GetAllReduced();
        }

        [HttpGet("{lotNumber}")]
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

        [HttpGet("{lotNumber}/notes")]
        public IEnumerable<MaterialLogNoteModel> GetNotes(string lotNumber)
        {
            return _materialLogNoteService.GetAllByLotNumber(lotNumber);
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

            CreateNotes(createdMaterialLogModel.DefaultProperties.LotNumber, request.NewNotes);

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

            CreateNotes(updatedMaterialLogModel.DefaultProperties.LotNumber, request.NewNotes);

            return Ok();
        }

        [HttpGet("{lotNumber}/inventoryMaterialTickets")]
        public IEnumerable<InventoryMaterialTicketModel> GetInventoryMaterialTickets(string lotNumber)
        {
            return _inventoryMaterialTicketService.GetAllByLotNumber(lotNumber);
        }

        [HttpGet("{lotNumber}/inventoryMaterialTickets/{ticketId}")]
        public IActionResult GetInventoryMaterialTicket(string lotNumber, int ticketId)
        {
            var ticket = _inventoryMaterialTicketService.GetById(ticketId);

            if (ticket == null)
            {
                return BadRequest("Inventory Material Ticket was not found.");
            }

            if (ticket.MaterialLogLotNumber != lotNumber)
            {
                return BadRequest("Inventory Material Ticket belongs to another Material Log.");
            }

            return Ok(ticket);
        }

        [HttpPost("{lotNumber}/inventoryMaterialTickets")]
        public IActionResult Create(InventoryMaterialTicketModel model)
        {
            

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
                _selectableOptionService.GetSupplierByValue(supplierValue) ??
                _selectableOptionService.CreateSupplier(supplierValue);

            return supplier.Id;
        }

        private void CreateNotes(string materialLogLotNumber, IReadOnlyList<string> notes)
        {
            foreach (var note in notes)
            {
                if (string.IsNullOrWhiteSpace(note))
                    continue;

                _materialLogNoteService.Create(materialLogLotNumber, note);
            }
        }
    }
}
