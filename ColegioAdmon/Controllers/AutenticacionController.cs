using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ColegioAdmon.Models;
using ColegioAdmon.Models.Dal;
using ColegioAdmon.Models.Entity;
using ColegioAdmon.Models.Bl;

namespace ColegioAdmon.Controllers
{
    public class AutenticacionController : Controller
    {
        private Db_ColegioEntities db = new Db_ColegioEntities();
        private AutenticacionBl AuthBl = new AutenticacionBl();
        // GET: Autenticacion
        public ActionResult Index(bool? banderaRegistro)
        {
            ViewBag.Bandera = banderaRegistro;
            var usuarios = AuthBl.Listar();
            return View(usuarios);
        }
        //Registro de usuarios
        [HttpPost]
        public ActionResult Registrar(Tbl_Usuario usuario, Tbl_Autenticacion autenticacion, int rol)
        {
            bool banderaRegistro = AuthBl.Registrar(usuario, autenticacion, rol);
            return Index(banderaRegistro);
        }
        //Vista de acceso
        public ActionResult Login(bool? banderaAcceso)
        {
            ViewBag.BanderaAcceso = banderaAcceso;
            return View();
        }
        //Validar acceso
        [HttpPost]
        public ActionResult Login(Tbl_Autenticacion autenticacion)
        {
            bool banderaAcceso = AuthBl.Acceso(autenticacion);
            return Login(banderaAcceso);
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            UsuarioEntity usuario = AuthBl.Detalle(id);
            return View();
        }
    }
}