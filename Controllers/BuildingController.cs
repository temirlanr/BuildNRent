using AutoMapper;
using BuildNRent.Dtos;
using BuildNRent.Models;
using BuildNRent.Repos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepo _buildingRepo;
        private readonly IMapper _mapper;

        public BuildingController(IRenterRepo renterRepo, IBuildingRepo buildingRepo, IMapper mapper)
        {
            _buildingRepo = buildingRepo;
            _mapper = mapper;
        }

        // GET api/buildings
        [HttpGet]
        [Route("buildings")]
        public ActionResult<IEnumerable<BuildingReadDto>> GetBuildings()
        {
            var buildings = _buildingRepo.GetAllBuildings();

            return Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(buildings));
        }

        // GET api/buildings/{id}
        [HttpGet]
        [Route("buildings/{id}")]
        [ActionName(nameof(GetBuilding))]
        public ActionResult<BuildingReadDto> GetBuilding(int id)
        {
            var building = _buildingRepo.GetBuildingById(id);

            if (building != null)
            {
                return Ok(_mapper.Map<BuildingReadDto>(building));
            }
            return NotFound();
        }

        // POST api/buildings
        [HttpPost]
        [Route("buildings")]
        public ActionResult<BuildingReadDto> CreateBuilding(BuildingCreateDto buildingCreateDto)
        {
            var buildingModel = _mapper.Map<Building>(buildingCreateDto);
            _buildingRepo.CreateBuilding(buildingModel);
            _buildingRepo.SaveChanges();

            var buildingReadDto = _mapper.Map<BuildingReadDto>(buildingModel);

            return CreatedAtAction(nameof(GetBuilding), new { id = buildingReadDto.BuildingId }, buildingReadDto);
        }

        // PUT api/buildings/{id}
        [HttpPut]
        [Route("buildings/{id}")]
        public ActionResult UpdateBuilding(int id, BuildingUpdateDto buildingUpdateDto)
        {
            var existingBuilding = _buildingRepo.GetBuildingById(id);

            if (existingBuilding == null)
            {
                return NotFound();
            }

            _mapper.Map(buildingUpdateDto, existingBuilding);
            _buildingRepo.UpdateBuilding(existingBuilding);
            _buildingRepo.SaveChanges();

            return NoContent();
        }

        // PATCH api/buildings/{id}
        [HttpPatch]
        [Route("buildings/{id}")]
        public ActionResult UpdateBuildingPartial(int id, JsonPatchDocument<BuildingUpdateDto> patchDoc)
        {
            var existingBuilding = _buildingRepo.GetBuildingById(id);

            if (existingBuilding == null)
            {
                return NotFound();
            }

            var buildingToPatch = _mapper.Map<BuildingUpdateDto>(existingBuilding);
            patchDoc.ApplyTo(buildingToPatch, ModelState);

            if (!TryValidateModel(buildingToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(buildingToPatch, existingBuilding);
            _buildingRepo.UpdateBuilding(existingBuilding);
            _buildingRepo.SaveChanges();

            return NoContent();
        }

        // DELETE api/buildings/{id}
        [HttpDelete]
        [Route("buildings/{id}")]
        public ActionResult DeleteBuilding(int id)
        {
            var existingBuilding = _buildingRepo.GetBuildingById(id);

            if (existingBuilding == null)
            {
                return NotFound();
            }

            _buildingRepo.DeleteBuilding(existingBuilding);
            _buildingRepo.SaveChanges();

            return NoContent();
        }
    }
}
