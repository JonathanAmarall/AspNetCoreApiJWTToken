using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Interfaces;

namespace Backend.Controllers
{
    [ApiController]
    [Route("v1/account")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<ResultSignDto> Authenticate([FromBody] SignInDto model)
        {
            // Recupera o usuário
            var user = _userRepository.GetUser(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new ResultSignDto
            {
                User = new UserDto {
                            Username = user.Username,
                            Email = user.Email,
                            Id = user.Id,
                            Role = user.Role
                        },
                Token = token
            };
        }

    }
}