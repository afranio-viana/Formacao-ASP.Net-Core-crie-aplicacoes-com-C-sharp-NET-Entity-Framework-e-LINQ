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
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastra(dto);
        return Ok("Usuário cadastrado");

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login (LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }

}