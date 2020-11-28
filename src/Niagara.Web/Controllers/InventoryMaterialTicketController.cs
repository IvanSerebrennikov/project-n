using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niagara.Domain.Models;
using Niagara.Domain.Services.Interfaces;

namespace Niagara.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryMaterialTicketController : ControllerBase
    {
        private readonly IMaterialLogService _materialLogService;
        private readonly IInventoryMaterialTicketService _inventoryMaterialTicketService;

        public InventoryMaterialTicketController(
            IMaterialLogService materialLogService, 
            IInventoryMaterialTicketService inventoryMaterialTicketService)
        {
            _materialLogService = materialLogService;
            _inventoryMaterialTicketService = inventoryMaterialTicketService;
        }

        [HttpGet("{lotNumber}")]
        public IEnumerable<InventoryMaterialTicketModel> GetNotes(string lotNumber)
        {
            return _inventoryMaterialTicketService.GetAllByLotNumber(lotNumber);
        }

        [HttpPost]
        public IActionResult Create(InventoryMaterialTicketModel request)
        {
            

            return Ok();
        }
    }
}
