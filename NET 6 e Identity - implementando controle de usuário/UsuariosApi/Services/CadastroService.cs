using UsuariosApi.Data.Dtos;
using AutoMapper;
using UsuariosApi.Models;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Services;

public class CadastroService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public CadastroService (IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task Cadastra (CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await
            _userManager.CreateAsync(usuario, dto.Password);

        if(!resultado.Succeeded)
        {
            throw new NotImplementedException("Falha ao cadastrar usuário");
        }
    }

}