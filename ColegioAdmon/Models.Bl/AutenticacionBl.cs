using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColegioAdmon.Models.Dal;
using ColegioAdmon.Models.Entity;

namespace ColegioAdmon.Models.Bl
{
    public class AutenticacionBl
    {
        private UsuarioDal UsersDal = new UsuarioDal();
        private AutenticacionDal AuthDal = new AutenticacionDal();

        public List<UsuarioEntity> Listar()
        {
            List<UsuarioEntity> usuarios = (from users in UsersDal.Listar()
                                            join auth in AuthDal.Listar() on users.Id_Usuario equals auth.Id_Usuario
                                            select new UsuarioEntity()
                                            {
                                                Id_Usuario = users.Id_Usuario,
                                                ApellidoUsuario = users.ApellidoUsuario,
                                                Clave = auth.Clave,
                                                Edad = users.Edad,
                                                Id_Rol = auth.Id_Rol,
                                                NombreUsuario = users.NombreUsuario,
                                                Sexo = users.Sexo,
                                                Usuario = auth.Usuario
                                            }).ToList();
            return usuarios;
        }

        public bool Registrar(Tbl_Usuario usuario, Tbl_Autenticacion autenticacion, int rol)
        {
            try
            {
                Tbl_Usuario user = UsersDal.Crear(usuario);
                autenticacion.Id_Usuario = user.Id_Usuario;
                Tbl_Autenticacion auth = AuthDal.Crear(autenticacion);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Acceso(Tbl_Autenticacion autenticacion)
        {
            var query = AuthDal.Listar().Where(x => x.Clave == autenticacion.Clave && x.Usuario == autenticacion.Usuario).FirstOrDefault();

            if(query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UsuarioEntity Detalle(int id)
        {
            Tbl_Usuario user = UsersDal.Detalle(id);
            Tbl_Autenticacion auth = AuthDal.Listar().Where(x => x.Id_Usuario == id).FirstOrDefault();

            return new UsuarioEntity
            {
                ApellidoUsuario = user.ApellidoUsuario,
                Id_Usuario = user.Id_Usuario,
                Clave = auth.Clave,
                Edad = user.Edad,
                Id_Rol = auth.Id_Rol,
                NombreUsuario = user.NombreUsuario,
                Sexo = user.Sexo,
                Usuario = auth.Usuario
            };
        }
    }
}