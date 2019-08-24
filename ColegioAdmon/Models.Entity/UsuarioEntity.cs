using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioAdmon.Models.Entity
{
    public class UsuarioEntity
    {
        public int Id_Usuario { get; set; }
        [Display(Name ="Nombre")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Apellido")]
        public string ApellidoUsuario { get; set; }
        public bool Sexo { get; set; }
        public int Edad { get; set; }
        [Display(Name = "Rol")]
        public int Id_Rol { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}