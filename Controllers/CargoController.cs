using System.IO.Pipes;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BibliotecaWeb.Data;
using BibliotecaWeb.Models;
using BibliotecaWeb.ModelsViews;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private BibliotecaDataContext _repository;

        public CargoController(BibliotecaDataContext repository)
        {
            _repository = repository;
        }

        Func<Cargo, dynamic> lambda = obj => new
        {
            id = obj?.Id,
            nome = obj?.Nome,
        };

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> Get()
        {
            var lista = await _repository.Cargo.ToListAsync();
            return Ok(lista?.Select(e => lambda(e)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cargo>>> Get(int id)
        {
            var obj = await _repository.Cargo.FindAsync(id);
            return Ok(lambda(obj));
        }


        [HttpPost]
        public async Task<ActionResult<Cargo>> Post(VCargo model)
        {
            if (ModelState.IsValid)
            {
                var obj = VCargo.LoadObject(_repository, model);

                if (obj == null)
                    return BadRequest();

                _repository.Cargo.Add(obj);
                await _repository.SaveChangesAsync();

                return Ok(lambda(obj));
            }

            return BadRequest();
        }



        [HttpPut]
        public async Task<ActionResult<Cargo>> Put(VCargo model)
        {
            if (ModelState.IsValid)
            {
                var obj = VCargo.LoadObject(_repository, model);

                if (obj.Id == 0)
                    return BadRequest();

                _repository.Cargo.Update(obj);
                await _repository.SaveChangesAsync();

                return Ok(lambda(obj));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                var obj = await _repository.Cargo.FindAsync(id);

                if (obj == null)
                    return BadRequest();

                _repository.Cargo.Remove(obj);
                await _repository.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }

    }
}