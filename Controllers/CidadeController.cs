using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BibliotecaWeb.Data;
using BibliotecaWeb.Models;
using BibliotecaWeb.ModelsViews;

namespace BibliotecaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly BibliotecaDataContext _repository;
        public CidadeController(BibliotecaDataContext repository)
        {
            _repository = repository;
        }


        Func<Cidade, dynamic> lambda = (obj) => new
        {
            id = obj?.Id,
            nome = obj?.Nome,
            nomeUF = obj?.UF?.Nome,
            idUF = obj?.IdUF,
        };

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> Get()
        {

            var lista = await _repository.Cidade?.ToListAsync();

            return Ok(lista?.Select(cidade => lambda(cidade)));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetId(int id)
        {
            var obj = await _repository.Cidade.FindAsync(id);
            if (obj == null)
                return BadRequest();

            return Ok(lambda(obj));
        }

        [HttpPost]
        public async Task<ActionResult<Cidade>> Post(VCidade model)
        {

            if (ModelState.IsValid)
            {
                var obj = VCidade.LoadObject(_repository, model);

                if (obj == null)
                    return BadRequest();

                _repository.Cidade.Add(obj);
                await _repository.SaveChangesAsync();

                return Ok(lambda(obj));
            }

            return BadRequest();
        }



        [HttpPut]
        public async Task<ActionResult<Cidade>> Put(VCidade model)
        {

            if (ModelState.IsValid)
            {
                var obj = VCidade.LoadObject(_repository, model);

                if (obj.Id == 0)
                    return BadRequest();

                _repository.Cidade.Update(obj);
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
                var obj = await _repository.Cidade.FindAsync(id);

                if (obj == null)
                    return BadRequest();

                _repository.Cidade.Remove(obj);
                await _repository.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }

    }
}
