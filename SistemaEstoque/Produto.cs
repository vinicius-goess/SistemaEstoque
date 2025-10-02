﻿namespace SistemaEstoque
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueMinimo { get; set; }
        public string Categoria { get; set; }
        public int idCategoria { get; set; }


    }
}