using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VotacaoAlterData.Controllers
{
    [Produces("application/json")]
    [Route("api/Filial")]
    public class FilialController : Controller
    {
        private IRepositoryWrapper _repository;

        public FilialController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllFilial()
        {
            try
            {
                var filiais = _repository.Filial.GetAll();
                return Ok(filiais);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }


        [HttpGet("{id}", Name = "FilialById")]
        public IActionResult GetFilialById(string id)
        {
            try
            {
                var filial = _repository.Filial.GetFilialById(id);
                return Ok(filial);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
             

        [HttpPost]
        public IActionResult CreateFilial([FromBody]Filial filial)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var filialJaExistente = _repository.Filial.GetFilialBySiglaENome(filial.sigla, filial.nome);

                if (filialJaExistente != null)
                {
                    var message = "Filial com sigla e nome ja cadastrados!";
                    return BadRequest(new { message = message });
                }

                _repository.Filial.CreateFilial(filial);

                return CreatedAtRoute("FilialById", new { id = filial.id }, filial);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilial(string id)
        {
            try
            {
                var filial = _repository.Filial.GetFilialById(id);

                _repository.Filial.DeleteFilial(filial);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilial(string id, [FromBody]Filial filial)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _repository.Filial.UpdateFilial(filial);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}