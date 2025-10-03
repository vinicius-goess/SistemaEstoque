using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Categoria.cs
namespace SistemaEstoque
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }

        // Isso é importante para o ComboBox saber como exibir o nome.
        public override string ToString()
        {
            return Nome;
        }
    }
}
