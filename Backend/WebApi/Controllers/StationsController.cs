using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationsController(IStationService stationService)
        {
            _stationService = stationService;
        }

        // GET: api/stations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationModel>>> Get()
        {
            return Ok(await _stationService.GetAllAsync());
        }

        // GET: api/stations/1
        [HttpGet("{id}")]
        public async Task<ActionResult<StationModel>> GetById(int id)
        {
            try
            {
                var station = await _stationService.GetByIdAsync(id);
                return Ok(station);
            }
            catch (RailwaysException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/stations
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StationModel model)
        {
            try
            {
                await _stationService.AddAsync(model);
                return Ok(model);
            }
            catch (RailwaysException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/stations/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] StationModel model)
        {
            try
            {
                model.Id = id;
                await _stationService.UpdateAsync(model);
                return NoContent();
            }

            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (RailwaysException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/stations/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _stationService.DeleteAsync(id);
                return Ok();
            }
            catch (RailwaysException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
