using UsuariosApi.Models;
using Microssoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
namespace UsuariosApi.Controllers;

[ApiContolle]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult CadastrarUsuario(CreateUsuarioDto dto)
    {
        throw new NotImplementedException();
        
    }

}