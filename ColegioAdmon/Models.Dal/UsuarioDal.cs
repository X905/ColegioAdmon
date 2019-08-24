using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColegioAdmon.Models.Entity;
using ColegioAdmon.Models;


namespace ColegioAdmon.Models.Dal
{
    public class UsuarioDal
    {
        private Db_ColegioEntities db = new Db_ColegioEntities();

        public List<Tbl_Usuario> Listar()
        {
            List<Tbl_Usuario> usuarios = db.Tbl_Usuario.ToList();

            return usuarios;
        }

        public Tbl_Usuario Detalle(int id)
        {
            Tbl_Usuario usuario = db.Tbl_Usuario.Find(id);
            return usuario;
        }

        public Tbl_Usuario Crear(Tbl_Usuario usuario)
        {
            db.Tbl_Usuario.Add(usuario);
            db.SaveChanges();
            return usuario;
        }

        public Tbl_Usuario Actualizar (Tbl_Usuario usuario)
        {
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return usuario;
        }

        public bool Eliminar(Tbl_Usuario usuario)
        {
            try
            {
                db.Tbl_Usuario.Remove(usuario);
                db.SaveChanges();
                return true;    
            }
            catch
            {
                return false;
            }
        }
    }
}