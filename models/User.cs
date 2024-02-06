using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tp1.models
{
    internal class User //Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 
    {
        public int id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string lastName { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string username { get; set; } = string.Empty;




    }
}
