using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace SistemaEstoque
{
    public partial class FormListagem : Form
    {
        private BindingSource bs = new BindingSource();
        public FormListagem()
        {
            InitializeComponent();
            MontarGrid();
            AtualizarGrid();
        }
        private void MontarGrid()
        {
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.Columns.Clear();
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantidade", HeaderText = "Quantidade", DataPropertyName = "Quantidade" });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço", DataPropertyName = "Preco", DefaultCellStyle = { Format = "C2" } });
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoria", DataPropertyName = "Categoria" });
        }

        private void AtualizarGrid()
        {
            bs.DataSource = Banco.Produtos;
            dgvProdutos.DataSource = bs;
            dgvProdutos.Refresh();
        }

        private Produto GetSelecionado()
        {
            if (dgvProdutos.CurrentRow == null) return null;
            return dgvProdutos.CurrentRow.DataBoundItem as Produto;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var p = GetSelecionado();
            if (p == null) { MessageBox.Show("Selecione um produto."); return; }
            using (var f = new FormCadastro(p))
            {
                f.ShowDialog();
            }
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var p = GetSelecionado();
            if (p == null) { MessageBox.Show("Selecione um produto."); return; }
            if (MessageBox.Show($"Excluir {p.Nome}?", "Confirma", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Banco.Produtos.Remove(p);
                AtualizarGrid();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}
