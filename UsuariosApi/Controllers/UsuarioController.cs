﻿using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
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

            IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

            if(result.Succeeded) return Ok(result);

            throw new Exception("Erro ao cadastrar usuario");


        }
    }
}
