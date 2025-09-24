using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaEstoque;

namespace SistemaEstoque
{
    public partial class FormCadastro : Form
    {
        private Produto produtoEditando;
        public FormCadastro()
        {
            InitializeComponent();
            PreencherCategorias();
        }

        public FormCadastro(Produto prod) : this()
        {
            produtoEditando = prod;
            CarregarProduto();
        }

        private void PreencherCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[] { "Alimentos", "Bebidas", "Higiene", "Eletrônicos", "Outros" });
            cmbCategoria.SelectedIndex = 0;

        }

        private void CarregarProduto()
        {
            if (produtoEditando == null) return;
            txtNome.Text = produtoEditando.Nome;
            nudQuantidade.Value = produtoEditando.Quantidade;
            txtPreco.Text = produtoEditando.PrecoVenda.ToString("F2");
            cmbCategoria.SelectedItem = produtoEditando.Categoria;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do produto.");
                return;
            }
            if (!decimal.TryParse(txtPreco.Text, out decimal preco))
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            if (produtoEditando == null)
            {
                var p = new Produto
                {
                    Nome = txtNome.Text.Trim(),
                    Quantidade = (int)nudQuantidade.Value,
                    PrecoVenda = preco,
                    Categoria = cmbCategoria.SelectedItem.ToString()
                };
                var conexao = new ConexaoMySQL();
                conexao.InserirProduto(p);
                MessageBox.Show("Produto salvo com sucesso.");
                LimparCampos();
            }
            else
            {
                produtoEditando.Nome = txtNome.Text.Trim();
                produtoEditando.Quantidade = (int)nudQuantidade.Value;
                produtoEditando.PrecoVenda = preco;
                produtoEditando.Categoria = cmbCategoria.SelectedItem.ToString();
                MessageBox.Show("Produto atualizado.");
                this.Close();
            }
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            nudQuantidade.Value = 0;
            txtPreco.Clear();
            cmbCategoria.SelectedIndex = 0;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
    }

