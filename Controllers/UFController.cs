using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BibliotecaWeb.Models;
using BibliotecaWeb.Data;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.ModelsViews;

namespace BibliotecaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UFController : ControllerBase
    {
        private readonly IRepository<UF> _repository;
        private readonly BibliotecaDataContext _context;
        public UFController(IRepository<UF> repository, BibliotecaDataContext context)
        {
            _context = context;
            _repository = repository;
        }

        Func<UF, dynamic> lambda = (obj) => new
        {
            id = obj.Id,
            nome = obj.Nome,
            sigla = obj?.Sigla,
            cidades = obj?.Cidades?.Select(cd => new
            {
                id = cd.Id,
                nome = cd.Nome,
            })
        };


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UF>>> Get()
        {
            return Ok(await _repository.Collection()?.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UF>> GetId(int id)
        {
            var obj = await _repository.LoadAsync(id);
            if (obj == null)
                return BadRequest();

            return Ok(lambda(obj));
        }

        [HttpPost()]
        public async Task<ActionResult<UF>> Post(VUF model)
        {
            if (ModelState.IsValid)
            {
                var obj = VUF.InitializeObject(_repository, model);

                if (obj == null)
                    return BadRequest();


                _repository.AddOrUpdate(obj);
                await _context.SaveChangesAsync();

                return Ok(lambda(obj));
            }

            return BadRequest();
        }


        [HttpPut()]
        public async Task<ActionResult<UF>> Put(VUF model)
        {
            if (ModelState.IsValid)
            {
                var obj = VUF.InitializeObject(_repository, model);

                if (obj.Id == 0)
                    return BadRequest();

                _repository.AddOrUpdate(obj);
                await _context.SaveChangesAsync();

                return Ok(lambda(obj));
            }

            return BadRequest();
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var obj = _repository.LoadAsync(id);

                if (obj == null)
                    return BadRequest();


                _repository.Delete(obj.Result);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }


    }
}