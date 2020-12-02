using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niagara.Domain.Exceptions;
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
        private readonly IInventoryMaterialTicketService _inventoryMaterialTicketService;

        public MaterialLogController(
            IMaterialLogService materialLogService, 
            ISelectableOptionService selectableOptionService,
            IInventoryMaterialTicketService inventoryMaterialTicketService)
        {
            _materialLogService = materialLogService;
            _selectableOptionService = selectableOptionService;
            _inventoryMaterialTicketService = inventoryMaterialTicketService;
        }

        [HttpGet]
        public IEnumerable<MaterialLogReducedModel> GetAll(int? skip = null, int? take = null)
        {
            return _materialLogService.GetAllReduced(skip, take);
        }

        [HttpGet("count")]
        public int GetCount()
        {
            return _materialLogService.Count();
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
            return _materialLogService.GetNotes(lotNumber);
        }

        [HttpPost]
        public IActionResult Create(MaterialLogSaveRequest request)
        {
            var materialLogModel = request.MaterialLog;

            try
            {
                var createdMaterialLogModel = _materialLogService.Create(materialLogModel, request.PartNumber, request.Supplier, request.NewNotes);

                return Ok(createdMaterialLogModel);
            }
            catch (Exception e)
            {
                return BadRequest("Error during Material Log creating.");
            }
        }

        [HttpPut]
        public IActionResult Update(MaterialLogSaveRequest request)
        {
            var materialLogModel = request.MaterialLog;

            try
            {
                var updatedMaterialLogModel = _materialLogService.Update(materialLogModel, request.PartNumber,
                    request.Supplier, request.NewNotes);

                return Ok();
            }
            catch (MaterialLogUpdateException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Error during Material Log updating.");
            }
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
            try
            {
                var createdInventoryMaterialTicket = _inventoryMaterialTicketService.Create(model);

                return Ok(createdInventoryMaterialTicket);
            }
            catch (InventoryMaterialTicketCreateException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Error during Inventory Material Ticket updating.");
            }
        }
    }
}
