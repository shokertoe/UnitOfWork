using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestDDD.Data;
using TestDDD.Data.Exceptions;
using TestDDD.Models;

namespace TestDDD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(id);
                return Ok(user);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        
        public async Task<ActionResult> Insert([FromBody] User user)
        {
            var createdUser = await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetItem", new { id = createdUser.Id}, createdUser);
        }
    }
}
