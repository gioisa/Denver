using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Denver._Model;
using Denver.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Denver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CigarettesController : ControllerBase
    {
        private readonly ICigarettesRepository _repo;

        public CigarettesController(ICigarettesRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var getCigarettes = _repo.GetCigarettes();
            return Ok(getCigarettes);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cigarettes cigarettes = _repo.GetCigarettesById(id);
            if (cigarettes != null)
            {
                return Ok(cigarettes);
            }
            else
            {
                return BadRequest("Oh tidak, data tidak ada");
            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromForm]Cigarettes cigarettes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Oops.. Ada yang error nih");
            }

            int success = _repo.AddCigarettes(cigarettes);
            if (success == 1)
            {
                return Created("api/cigarettes", cigarettes);
            }
            return BadRequest();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]Cigarettes cigarettes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Tidak ada data yang di edit");
            }

            int success = _repo.UpdateCigarettes(id, cigarettes);

            if (success == 1)
            {
                return Ok(cigarettes);
            }

            return BadRequest("Aduh... Editnya gagal");
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int success = _repo.DeleteCigarettes(id);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
