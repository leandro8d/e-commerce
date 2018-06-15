using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            CarrinhoCompras = new HashSet<CarrinhoCompras>();
            Comentarios = new HashSet<Comentarios>();
        }

        public long IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public short IdTipoUsuario { get; set; }
        public string Senha{ get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<CarrinhoCompras> CarrinhoCompras { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
