using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public short IdTipoUsuario { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
