using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Repository.Models
{
 
    public partial class CarrinhoCompras
    {
        public long IdCarrinhoCompras { get; set; }
        public long IdUsuario { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
        public bool? Finalizado { get; set; }

        public Produtos IdProdutoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
