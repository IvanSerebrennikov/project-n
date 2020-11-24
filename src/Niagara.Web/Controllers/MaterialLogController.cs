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
    public class MaterialLogController : ControllerBase
    {
        private readonly IMaterialLogService _materialLogService;

        public MaterialLogController(IMaterialLogService materialLogService)
        {
            _materialLogService = materialLogService;
        }

        [HttpGet]
        public IEnumerable<MaterialLogModel> GetAll()
        {
            return _materialLogService.GetAll();
        }

        [HttpGet("{lotNumber}")]
        public IActionResult Get(string lotNumber)
        {
            var materialLogModel = _materialLogService.GetByLotNumber(lotNumber);

            if (materialLogModel == null)
            {
                return BadRequest("Material Log was not found.");
            }

            return Ok(materialLogModel);;
        }

        [HttpPost]
        public IActionResult Create(MaterialLogModel model)
        {
            var createdMaterialLogModel = _materialLogService.Create(model);

            return Ok(createdMaterialLogModel);
        }

        [HttpPut]
        public IActionResult Update(MaterialLogModel model)
        {
            var updatedMaterialLogModel = _materialLogService.Update(model);

            if (updatedMaterialLogModel == null)
            {
                return BadRequest("Material Log was not found.");
            }

            return Ok(updatedMaterialLogModel);
        }
    }
}
