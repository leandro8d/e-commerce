using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            CarrinhoCompras = new HashSet<CarrinhoCompras>();
            Comentarios = new HashSet<Comentarios>();
        }

        public long IdProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }

        public ICollection<CarrinhoCompras> CarrinhoCompras { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
