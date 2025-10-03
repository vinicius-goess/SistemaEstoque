// CategoriaDAO.cs
using System.Collections.Generic;
using MySqlConnector;

namespace SistemaEstoque
{
    public class CategoriaDAO
    {
        public List<Categoria> ObterCategorias() 
        {
            var lista = new List<Categoria>();
            using (var conn = Banco.GetConnection())
            {
                conn.Open();
                string sql = "SELECT idcategoria, nome FROM categoria ORDER BY nome";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Adiciona um objeto Categoria completo à lista
                        lista.Add(new Categoria
                        {
                            IdCategoria = reader.GetInt32("idcategoria"),
                            Nome = reader.GetString("nome")
                        });
                    }
                }
            }
            return lista;
        }
    }
}