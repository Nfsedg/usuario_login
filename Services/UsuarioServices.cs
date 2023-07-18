﻿using Proyecto_Final_23AM.Context;
using Proyecto_Final_23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_23AM.Services
{
    public class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using(var _context = new ApplicationDbContext())
                    {
                        Usuario res =new Usuario();
                        res.Nombre = request.Nombre;
                        res.Username = request.Username;
                        res.Password = request.Password;
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }    
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error" + ex.Message);
            }
        }
        public List<Usuario> GetUsuarios()
        {
            try
            {
                using(var _context=new ApplicationDbContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();
                    usuarios=_context.Usuarios.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();
                    return roles;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }

        }
        public Usuario GetUsuario(int pkUsuario)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.PkUsuario == pkUsuario);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el usuario: " + ex.Message);
            }
        }


    }
}

