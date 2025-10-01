using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;


namespace SistemaEstoque
{
    public partial class FormSaida : Form
    {
        public FormSaida()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            cmbProduto.DataSource = null;
            cmbProduto.DataSource = Banco.Produtos;
            cmbProduto.DisplayMember = "Nome";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var p = cmbProduto.SelectedItem as Produto;
            if (p == null) { MessageBox.Show("Selecione um produto."); return; }
            int saida = (int)nudSaida.Value;
            if (saida <= 0) { MessageBox.Show("Quantidade inválida."); return; }
            if (saida > p.Quantidade)
            {
                MessageBox.Show("Estoque insuficiente.");
                return;
            }
            p.Quantidade -= saida;
            MessageBox.Show("Saída registrada com sucesso.");
            CarregarProdutos();

        }
    }
}
