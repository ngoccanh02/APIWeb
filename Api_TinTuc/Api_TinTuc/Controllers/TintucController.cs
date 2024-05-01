using Api_TinTuc.Data;
using Api_TinTuc.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Api_TinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TintucController : ControllerBase
    {
        private readonly MyDbcontext _context;
        private IWebHostEnvironment environment;
        public ServiceA serviceA { get; set; }

        public TintucController(MyDbcontext context, IWebHostEnvironment hostingEnvironment)
        {
            serviceA = new ServiceA(hostingEnvironment);
            _context = context;
            environment = hostingEnvironment;
        }
        [HttpPost("PostTintuc")]
        public async Task<IActionResult> PostTintuc([FromForm] TintucVM tintuc)
        {
            try
            {

                var image = serviceA.SaveImage(tintuc.FormFile);
                if (image.Item1 == 1)
                {
                    tintuc.Image = image.Item2;
                }
                Tintuc tintuc1 = new Tintuc();
                tintuc1.Title = tintuc.Title;
                tintuc1.Content = tintuc.Content;
                tintuc1.Image = tintuc.Image;
                await _context.news.AddAsync(tintuc1);
                await _context.SaveChangesAsync();
                return Ok("Lưu thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTintuc")]
        public async Task<IActionResult> GetTintuc()
        {
            try
            {
                var data = await _context.news.ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTintuc")]
        public async Task<IActionResult> DeleteTintuc(int id)
        {
            try
            {
                var data = await _context.news.FirstOrDefaultAsync(e => e.Id_News == id);
                _context.news.Remove(data);
                await _context.SaveChangesAsync();
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPut("PutTintuc")]
        public async Task<IActionResult> PutTintuc(int id, [FromForm] TintucVM tintuc)
        {
            try
            {
                var data = await _context.news.FirstOrDefaultAsync(e => e.Id_News == id);
                data.Title = tintuc.Title;
                data.Content = tintuc.Content;
                await _context.SaveChangesAsync();
                return Ok("Cập nhật thành công");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Gettintucid")]
        public async Task<IActionResult> Gettintucid(int id)
        {
            try
            {
                var data = await _context.news.FirstOrDefaultAsync(e => e.Id_News == id);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

