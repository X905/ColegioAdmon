using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColegioAdmon.Models.Entity;

namespace ColegioAdmon.Models.Dal
{
    public class AutenticacionDal
    {
        private Db_ColegioEntities db = new Db_ColegioEntities();

        public List<Tbl_Autenticacion> Listar()
        {
            var auth = db.Tbl_Autenticacion.ToList();

            return auth;
        }

        public Tbl_Autenticacion Detalle(int id)
        {
            var auth = db.Tbl_Autenticacion.Find(id);
            return auth;
        }

        public Tbl_Autenticacion Crear (Tbl_Autenticacion autenticacion)
        {
            db.Tbl_Autenticacion.Add(autenticacion);
            db.SaveChanges();
            return autenticacion;
        }

        public Tbl_Autenticacion Actualizar(Tbl_Autenticacion auth)
        {
            db.Entry(auth).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return auth;
        }
        public bool Eliminar(Tbl_Autenticacion auth)
        {
            try
            {
                db.Tbl_Autenticacion.Remove(auth);
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