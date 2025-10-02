using System;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;
using MySqlConnector;



namespace SistemaEstoque
{
    public static class Banco
    {
        public static string ConnectionString = "Server=localhost;Database=bd_sistema_estoque;Uid=admin;Pwd=123";
        //public static List<Produto> Produtos { get; } = new List<Produto>();

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }


    }
