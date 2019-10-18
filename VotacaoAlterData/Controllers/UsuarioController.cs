using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VotacaoAlterData.Helpers;

namespace VotacaoAlterData.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly AppSettings _appSettings;
        public UsuarioController(IRepositoryWrapper repository, IOptions<AppSettings> appSettings)
        {
           _repository = repository;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            try
            {
                var usuarios = _repository.Usuario.GetAllUsuario();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
             
                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }


        [HttpGet("{id}", Name = "UsuarioById")]
        public IActionResult GetUsuarioById(string id)
        {
            try
            {
                var usuario = _repository.Usuario.GetUsuarioById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
               
               return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Usuario usuario)
        {
            var user = _repository.Usuario.GetByUsuario (usuario.idFilial.ToString(), usuario.email, usuario.senha);
            
            if (user == null)
                return BadRequest(new { message = "Usuário ou senha inválidos" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };

            //  var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = GenerateToken(usuario.email); //tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.id,
                email = user.email,
                nome = user.nome,
                Token = tokenString,
                idFilial = user.idFilial
            });
        }


        public static string GenerateToken(string username, int expireMinutes = 20)
        {

            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username)
        });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:4724", audience: "http://localhost:4724",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;

        }


        [HttpPost]
        public IActionResult CreateUsuario([FromBody]Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                    return BadRequest();

                _repository.Usuario.CreateUsuario(usuario);

                return CreatedAtRoute("UsuarioById", new { id = usuario.id }, usuario);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(string id)
        {
            try
            {
                var usuario = _repository.Usuario.GetUsuarioById(id);
              
                _repository.Usuario.DeleteUsuario(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(Guid id, [FromBody]Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                    return BadRequest();

                _repository.Usuario.UpdateUsuario(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, "Internal server error");
            }
        }

    }
}