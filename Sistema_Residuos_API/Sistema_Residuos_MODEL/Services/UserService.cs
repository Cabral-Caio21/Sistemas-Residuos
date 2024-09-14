﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sistema_Residuos_MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserService
{
    private readonly Sistema_ResiduosContext _context;
    private readonly PasswordHasher<Usuario> _passwordHasher;

    public UserService(Sistema_ResiduosContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<Usuario>();
    }

    public async Task CreateUserAsync(string nome, string email, string senha, string role)
    {
        var user = new Usuario
        {
            Nome = nome,
            Email = email,
            Senha = _passwordHasher.HashPassword(null, senha), // Hash da senha
            Role = role
        };
        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> GetUserByCredentialsAsync(string email, string password)
    {
        var user = await _context.Usuarios
                .SingleOrDefaultAsync(u => u.Email == email);

        if (user == null) return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.Senha, password);

        if (result == PasswordVerificationResult.Success)
        {
            return user;
        }

        return null;
    }

    public Usuario GetUserById(int userId) // Corrigido para usar INT
    {
        return _context.Usuarios.Find(userId);
    }
}