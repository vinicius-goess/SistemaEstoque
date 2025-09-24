using MySql.Data.MySqlClient;
using System;


namespace SistemaEstoque
{
    public class ConexaoMySQL
    {
        private static string connStr = "Server=localhost;Database=bd_sistema_estoque;Uid=admin;Pwd=123;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }
        public void TestarConexao()
        {
            using (var conexao = new MySqlConnection(connStr))
            {
                try
                {
                    conexao.Open();
                    Console.WriteLine("Conexão realizada com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar: " + ex.Message);
                }
            }
        }

        public void InserirProduto(Produto p)
        {
            string sql = "INSERT INTO produto (nome_produto, descricao, quantidade, preco_custo, preco_venda, estoque_minimo, fk_categoria_idcategoria) " +
                         "VALUES (@nome, @descricao, @quantidade, @precoCusto, @precoVenda, @estoqueMinimo, @idCategoria)";
            using (var conexao = new MySqlConnection(connStr))
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                cmd.Parameters.AddWithValue("@quantidade", p.Quantidade);
                cmd.Parameters.AddWithValue("@precoCusto", p.PrecoCusto);
                cmd.Parameters.AddWithValue("@precoVenda", p.PrecoVenda);
                cmd.Parameters.AddWithValue("@estoqueMinimo", p.EstoqueMinimo);

                conexao.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}