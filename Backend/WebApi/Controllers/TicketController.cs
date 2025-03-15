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
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/tickets/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetAvailableTickets()
        {
            return Ok(await _ticketService.GetAvailableTicketsAsync());
        }

        // GET: api/tickets/history
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetTicketHistory()
        {
            return Ok(await _ticketService.GetTicketHistoryAsync());
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetAll()
        {
            return Ok(await _ticketService.GetAllAsync());
        }

        // GET: api/tickets/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketModel>> GetById(int id)
        {
            try
            {
                var ticket = await _ticketService.GetByIdAsync(id);
                return Ok(ticket);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/tickets
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TicketModel model)
        {
            try
            {
                await _ticketService.AddAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }
            catch (RailwaysException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/tickets/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TicketModel model)
        {
            try
            {
                var existingTicket = await _ticketService.GetByIdAsync(id);
                if (existingTicket == null)
                {
                    return NotFound($"Ticket with ID {id} not found.");
                }

                model.Id = id;
                await _ticketService.UpdateAsync(model);
                return NoContent();
            }
            catch (RailwaysException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/tickets/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ticketService.DeleteAsync(id);
                return NoContent();
            }
            catch (RailwaysException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
