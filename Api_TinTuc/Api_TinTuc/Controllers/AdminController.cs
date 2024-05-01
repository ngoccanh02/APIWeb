using Api_TinTuc.Data;
using Api_TinTuc.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_TinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MyDbcontext _context;

        public AdminController(MyDbcontext context)
        {
            _context = context;
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromForm] LoginUser user)
        {
            try
            {
                var login = await _context.users.FirstOrDefaultAsync(e => e.Username == user.UserName && e.Password == user.Password);
                if (login != null)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
