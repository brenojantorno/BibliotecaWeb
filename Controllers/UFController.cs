using System.Linq;
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
        private readonly BibliotecaDataContext _repository;
        public UFController(BibliotecaDataContext repository)
        {
            _repository = repository;
        }

        Func<UF, dynamic> lambda = (obj) => new
        {
            id = obj?.Id,
            nome = obj?.Nome,
            sigla = obj?.Sigla,
            cidades = obj?.Cidades?.Select(cd => new
            {
                id = cd?.Id,
                nome = cd?.Nome,
            })
        };

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UF>>> Get()
        {
            var lista = await _repository.UF?.ToListAsync();

            return Ok(lista?.Select(uf => lambda(uf)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UF>> Get(int id)
        {
            var obj = await _repository.UF.FindAsync(id);

            return Ok(lambda(obj));
        }
    }
}