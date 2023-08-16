using UsuariosApi.Models;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using AutoMapper;
using UsuariosApi.Data;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private CadastroService _cadastroService;

    public UsuarioController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _cadastroService.Cadastra(dto);
        return Ok("Usuário cadastrado");

    }

}