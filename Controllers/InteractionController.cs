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
    [Route("api/interactions")]
    public class InteractionController : ControllerBase
    {
        private readonly IRenterRepo _renterRepo;
        private readonly IBuildingRepo _buildingRepo;
        private readonly IInteractionRepo _interactionRepo;
        private readonly IMapper _mapper;

        public InteractionController(IInteractionRepo interactionRepo, IMapper mapper, IBuildingRepo buildingRepo, IRenterRepo renterRepo)
        {
            _interactionRepo = interactionRepo;
            _mapper = mapper;
            _renterRepo = renterRepo;
            _buildingRepo = buildingRepo;
        }

        // GET api/interactions
        [HttpGet]
        public ActionResult<IEnumerable<InteractionReadDto>> GetInteraction()
        {
            var interactions = _interactionRepo.GetAllInteractions();

            return Ok(_mapper.Map<IEnumerable<InteractionReadDto>>(interactions));
        }

        // GET api/interactions/{id}
        [HttpGet("{id}")]
        [ActionName(nameof(GetInteraction))]
        public ActionResult<InteractionReadDto> GetInteraction(int id)
        {
            var interaction = _interactionRepo.GetInteractionById(id);

            if (interaction != null)
            {
                return Ok(_mapper.Map<InteractionReadDto>(interaction));
            }
            return NotFound();
        }

        // POST api/interactions
        [HttpPost]
        public ActionResult<InteractionReadDto> CreateInteraction(Interaction interaction)
        {
            var renter = _renterRepo.GetRenterById(interaction.RenterId);
            var building = _buildingRepo.GetBuildingById(interaction.BuildingId);

            if (renter.IsEntity == false && building.IsBusiness == true)
            {
                Interaction temp = new()
                {
                    Id = interaction.Id,
                    RenterId = interaction.RenterId,
                    BuildingId = interaction.BuildingId,
                    RentingArea = interaction.RentingArea,
                    Cost = interaction.RentingArea * building.SalePrice * 9 / 10
                };
                _interactionRepo.CreateInteraction(temp);
            }
            else
            {
                Interaction temp = new()
                {
                    Id = interaction.Id,
                    RenterId = interaction.RenterId,
                    BuildingId = interaction.BuildingId,
                    RentingArea = interaction.RentingArea,
                    Cost = interaction.RentingArea * building.SalePrice
                };
                _interactionRepo.CreateInteraction(temp);
            }
            
            _interactionRepo.SaveChanges();

            var interactionReadDto = _mapper.Map<InteractionReadDto>(interaction);

            return CreatedAtAction(nameof(GetInteraction), new { id = interactionReadDto.Id }, interactionReadDto);
        }

        // PUT api/interactions/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateInteraction(int id, InteractionUpdateDto interactionUpdateDto)
        {
            var existingInteraction = _interactionRepo.GetInteractionById(id);

            if (existingInteraction == null)
            {
                return NotFound();
            }

            _mapper.Map(interactionUpdateDto, existingInteraction);
            _interactionRepo.UpdateInteraction(existingInteraction);
            _interactionRepo.SaveChanges();

            return NoContent();
        }

        // PATCH api/interactions/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateInteractionPartial(int id, JsonPatchDocument<InteractionUpdateDto> patchDoc)
        {
            var existingInteraction = _interactionRepo.GetInteractionById(id);

            if (existingInteraction == null)
            {
                return NotFound();
            }

            var interactionToPatch = _mapper.Map<InteractionUpdateDto>(existingInteraction);
            patchDoc.ApplyTo(interactionToPatch, ModelState);

            if (!TryValidateModel(interactionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(interactionToPatch, existingInteraction);
            _interactionRepo.UpdateInteraction(existingInteraction);
            _interactionRepo.SaveChanges();

            return NoContent();
        }

        // DELETE api/interactions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteInteraction(int id)
        {
            var existingInteraction = _interactionRepo.GetInteractionById(id);

            if (existingInteraction == null)
            {
                return NotFound();
            }

            _interactionRepo.DeleteInteraction(existingInteraction);
            _interactionRepo.SaveChanges();

            return NoContent();
        }

        // GET api/interactions/rentermain/{id}
        [HttpGet]
        [Route("rentermain/{id}")]
        public ActionResult RenterSpendings(int id)
        {
            var rentedBuildings = _interactionRepo.GetAllInteractions().Where(j => j.RenterId == id);

            if (rentedBuildings == null)
            {
                return NotFound();
            }

            decimal totalCost = 0;
            foreach(var obj in rentedBuildings)
            {
                totalCost += obj.Cost;
            }

            return Ok(totalCost);
        }

        // GET api/interactions/buildingmain/{id}
        [HttpGet]
        [Route("buildingmain/{id}")]
        public ActionResult BuildingIncome(int id)
        {
            var buildingRenters = _interactionRepo.GetAllInteractions().Where(j => j.BuildingId == id);

            if (buildingRenters == null)
            {
                return NotFound();
            }

            decimal totalIncome = 0;
            foreach (var obj in buildingRenters)
            {
                totalIncome += obj.Cost;
            }

            return Ok(totalIncome);
        }
    }
}
