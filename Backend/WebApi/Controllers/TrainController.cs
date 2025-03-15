using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainsController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        // GET: api/trains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainModel>>> GetAll()
        {
            return Ok(await _trainService.GetAllAsync());
        }

        // GET: api/trains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainModel>> GetById(int id)
        {
            try
            {
                var train = await _trainService.GetByIdAsync(id);
                return Ok(train);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/trains/search?station1=1&station2=2
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TrainModel>>> GetByTwoStations([FromQuery] int station1, [FromQuery] int station2)
        {
            try
            {
                var result = await _trainService.GetTrainsByTwoStations(new StationModel { Id = station1 }, new StationModel { Id = station2 });
                return Ok(result);
            }
            catch (InvalidRouteException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/trains
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TrainModel model)
        {
            try
            {
                await _trainService.AddAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }
            catch (RailwaysException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/trains/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TrainModel model)
        {
            try
            {
                model.Id = id;
                await _trainService.UpdateAsync(model);
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

        // GET: api/trains/by-station? stationId = 1
        [HttpGet("by-station")]
        public async Task<ActionResult<IEnumerable<TrainModel>>> GetByStation([FromQuery] int stationId)
        {
            try
            {
                var trains = await _trainService.GetTrainsByStation(new StationModel { Id = stationId });
                return Ok(trains);
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


        // DELETE: api/trains/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _trainService.DeleteAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
