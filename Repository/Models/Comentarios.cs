using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Repository.Models
{
    
    public partial class Comentarios
    {
        public long IdComentario { get; set; }
        public string Titulo { get; set; }
        public string Comentario { get; set; }
        public long IdUsuario { get; set; }
        public long IdProduto { get; set; }

        public Produtos IdProdutoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
