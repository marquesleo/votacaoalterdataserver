using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VotacaoAlterData.Controllers
{
    [Produces("application/json")]
    [Route("api/VotacaoDoRecurso")]
    public class VotacaoDoRecursoController : Controller
    {

        private IRepositoryWrapper _repository;

        public VotacaoDoRecursoController(IRepositoryWrapper repository)
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

                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}", Name = "VotacaoDoRecursoByID")]
        public IActionResult GetById(string id)
        {
            try
            {
                var votacao = _repository.VotacaoRecurso.GetVotacaoDoRecursoById(id);
                return Ok(votacao);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet()]
        [Route("votosdosusuario/{idUsuario}")]
        public IActionResult GetVotosDoUsuario(string idUsuario)
        {
            try
            {
                var votacao = _repository.VotacaoRecurso.GetVotacaoDoRecursoById(idUsuario);
                return Ok(votacao);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }


       
        [HttpPost]
        public IActionResult CreateVotacao([FromBody]List<Entities.BO.RecursoParaVotacao> lstRecursoParaVotacao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                //var votacaoJaExistente = _repository.VotacaoRecurso.GetVotacaoDoRecursoByFilialUsuarioERecurso(votacaoDoRecurso.idFilial.ToString(),
                //    votacaoDoRecurso.idRecurso.ToString(),
                //    votacaoDoRecurso.idUsuario.ToString());

                //if (votacaoJaExistente != null)
                //{
                //    var message = "Votação desse recurso já foi feita para esse usuário!";
                //    return BadRequest(new { message = message });
                //}


                foreach (var item in lstRecursoParaVotacao)
                {
                    var votacao = new Entities.Models.VotacaoDoRecurso();
                    votacao.id = Guid.NewGuid();
                    votacao.idFilial = item.idFilial;
                    votacao.idUsuario = item.idusuario;
                    votacao.observacao = item.observacao;
                    votacao.dtVotacao = DateTime.Now;
                    _repository.VotacaoRecurso.Create(votacao);
                }



                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var votacao = _repository.VotacaoRecurso.GetVotacaoDoRecursoById(id);

                _repository.VotacaoRecurso.Delete(votacao);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        
    }
}
