using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VotacaoAlterData.Controllers
{
    [Produces("application/json")]
    [Route("api/Recursos")]
    public class RecursoController : Controller
    {
        private IRepositoryWrapper _repository;

        public RecursoController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllRecursos()
        {
            try
            {
                var recursos = _repository.Recurso.GetAll();
                return Ok(recursos);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }


        [HttpGet("{id}", Name = "RecursoById")]
        public IActionResult GetRecursoById(string id)
        {
            try
            {
                var filial = _repository.Recurso.GetRecursoById(id);
                return Ok(filial);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("recursosnaovotados/{id}")]
        [Route("recursosnaovotados/{id}")]
        public IActionResult GetRecursoASeremVotados(string id)
        {
            try
            {
                var recursos = _repository.Recurso.GetRecursosNaoVotados(id);
                return Ok(recursos);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }


        [HttpPost]
        public IActionResult CreateRecurso([FromBody]Recurso recurso)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                

                _repository.Recurso.CreateRecurso(recurso);

                
                return CreatedAtRoute("RecursoById", new { id = recurso.id }, recurso);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecurso(string id)
        {
            try
            {
                var recurso = _repository.Recurso.GetRecursoById(id);

                _repository.Recurso.DeleteRecurso(recurso);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecurso(string id, [FromBody]Recurso recurso)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _repository.Recurso.UpdateRecurso(recurso);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

    }
}