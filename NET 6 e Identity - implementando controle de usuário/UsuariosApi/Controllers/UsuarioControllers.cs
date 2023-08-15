using UsuariosApi.Models;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using AutoMapper;
using UsuariosApi.Data;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    
    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await
        _userManager.CreateAsync(usuario, dto.Password);
        if(resultado.Succeeded)
        {
            return Ok("Usuário cadastrado com sucesso!!!");
        }else
        {
            throw new ApplicationException("Falha ao cadastrar usuário!!!");
        }

    }

}