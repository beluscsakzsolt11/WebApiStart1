using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStart1.Services;
using WebApiStart1.Models;
using WebApiStart1.DTUs;
using Org.BouncyCastle.Crypto.Digests;

namespace WebApiStart1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyogyszerController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAllGyogyszer()
        {
            try
            {
                List<Gyogyszer> result = new GyogyszerService().GetAllGyogyszer();
                if (result.Count > 0)
                {
                    return Ok(result);

                }
                else
                {
                    return NotFound("Hiba történt");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetByIdGyogyszer(int id)
        {
            try
            {
                Gyogyszer result = new GyogyszerService().GetByIdGyogyszer(id);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Nincs ilyen azonosítójú gyógyszer");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Hiba történt: " + ex.Message);

            }

        }

        [HttpGet("NevHatoanyag")]
        public IActionResult NevHatoanyag()
        {
            try
            {
                List<NevHatoanyagDTO> result = new GyogyszerService().GetAllGyogyszer().Select(g => new NevHatoanyagDTO()
                {
                    Id = g.Id,
                    Nev = g.Nev,
                    Hatoanyag = g.Hatoanyag
                }).ToList();

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Nincs ilyen adat");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("NevHatoanyagById/{id}")]
        public IActionResult NevHatoanyagById(int id)
        {
            try
            {
                Gyogyszer result = new GyogyszerService().GetByIdGyogyszer(id);
                if (result is not null)
                {
                    NevHatoanyagDTO dto = new NevHatoanyagDTO()
                    {
                        Id = result.Id,
                        Nev = result.Nev,
                        Hatoanyag = result.Hatoanyag
                    };
                    return Ok(dto);
                }
                else
                {
                    return NotFound("Nincs megjeleníthető adat");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
