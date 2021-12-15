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
    public class RenterController : ControllerBase
    {
        private readonly IRenterRepo _renterRepo;
        private readonly IMapper _mapper;

        public RenterController(IRenterRepo renterRepo, IBuildingRepo buildingRepo, IMapper mapper)
        {
            _renterRepo = renterRepo;
            _mapper = mapper;
        }

        // GET api/renters
        [HttpGet]
        [Route("renters")]
        public ActionResult<IEnumerable<RenterReadDto>> GetRenters()
        {
            var renters = _renterRepo.GetAllRenters();

            return Ok(_mapper.Map<IEnumerable<RenterReadDto>>(renters));
        }

        // GET api/renters/{id}
        [HttpGet("renters/{id}")]
        [ActionName(nameof(GetRenter))]
        public ActionResult<RenterReadDto> GetRenter(int id)
        {
            var renter = _renterRepo.GetRenterById(id);

            if (renter != null)
            {
                return Ok(_mapper.Map<RenterReadDto>(renter));
            }
            return NotFound();
        }

        // POST api/renters
        [HttpPost]
        [Route("renters")]
        public ActionResult<RenterReadDto> CreateRenter(RenterCreateDto renterCreateDto)
        {
            var renterModel = _mapper.Map<Renter>(renterCreateDto);
            _renterRepo.CreateRenter(renterModel);
            _renterRepo.SaveChanges();

            var renterReadDto = _mapper.Map<RenterReadDto>(renterModel);

            return CreatedAtAction(nameof(GetRenter), new { id = renterReadDto.RenterId }, renterReadDto);
        }

        // PUT api/renters/{id}
        [HttpPut]
        [Route("renters/{id}")]
        public ActionResult UpdateRenter(int id, RenterUpdateDto renterUpdateDto)
        {
            var existingRenter = _renterRepo.GetRenterById(id);

            if (existingRenter == null)
            {
                return NotFound();
            }

            _mapper.Map(renterUpdateDto, existingRenter);
            _renterRepo.UpdateRenter(existingRenter);
            _renterRepo.SaveChanges();

            return NoContent();
        }

        // PATCH api/renters/{id}
        [HttpPatch]
        [Route("renters/{id}")]
        public ActionResult UpdateRenterPartial(int id, JsonPatchDocument<RenterUpdateDto> patchDoc)
        {
            var existingRenter = _renterRepo.GetRenterById(id);

            if (existingRenter == null)
            {
                return NotFound();
            }

            var renterToPatch = _mapper.Map<RenterUpdateDto>(existingRenter);
            patchDoc.ApplyTo(renterToPatch, ModelState);

            if (!TryValidateModel(renterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(renterToPatch, existingRenter);
            _renterRepo.UpdateRenter(existingRenter);
            _renterRepo.SaveChanges();

            return NoContent();
        }

        // DELETE api/renters/{id}
        [HttpDelete]
        [Route("renters/{id}")]
        public ActionResult DeleteRenter(int id)
        {
            var existingRenter = _renterRepo.GetRenterById(id);

            if (existingRenter == null)
            {
                return NotFound();
            }

            _renterRepo.DeleteRenter(existingRenter);
            _renterRepo.SaveChanges();

            return NoContent();
        }
    }
}
