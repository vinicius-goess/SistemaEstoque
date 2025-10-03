// FormCadastro.cs
using System;
using System.Windows.Forms;

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

        // MÉTODO CORRIGIDO
        private void PreencherCategorias()
        {
            // 1. Instancia o DAO para buscar categorias
            var categoriaDAO = new CategoriaDAO();

            // 2. Chama o método que busca as categorias do banco
            var categorias = categoriaDAO.ObterCategorias();

            // 3. Limpa o ComboBox
            cmbCategoria.Items.Clear();

            // 4. Adiciona as categorias (objetos) ao ComboBox
            foreach (var cat in categorias)
            {
                cmbCategoria.Items.Add(cat);
            }

            // Opcional: seleciona o primeiro item se a lista não estiver vazia
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }
        }

        private void CarregarProduto()
        {
            // Este método também precisará de ajuste se você for editar
            // Mas para o cadastro, o foco é o PreencherCategorias e o btnSalvar_Click
            if (produtoEditando == null) return;
            txtNome.Text = produtoEditando.Nome;
            nudQuantidade.Value = produtoEditando.Quantidade;
            txtPreco.Text = produtoEditando.PrecoVenda.ToString("F2");
            // Lógica para selecionar a categoria correta ao editar
            foreach (Categoria item in cmbCategoria.Items)
            {
                if (item.Nome == produtoEditando.Categoria)
                {
                    cmbCategoria.SelectedItem = item;
                    break;
                }
            }
        }

        // MÉTODO CORRIGIDO
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

            // Pega o objeto Categoria inteiro que foi selecionado
            Categoria categoriaSelecionada = cmbCategoria.SelectedItem as Categoria;

            if (categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma categoria válida.");
                return;
            }

            if (produtoEditando == null)
            {
                var p = new Produto
                {
                    Nome = txtNome.Text.Trim(),
                    Quantidade = (int)nudQuantidade.Value,
                    PrecoVenda = preco,
                    // Atribui o ID da categoria selecionada!
                    idCategoria = categoriaSelecionada.IdCategoria
                };
                var conexao = new ConexaoMySQL();
                conexao.InserirProduto(p);
                MessageBox.Show("Produto salvo com sucesso.");
                LimparCampos();
            }
            else
            {
                // Lógica para ATUALIZAR (também precisa do ID da categoria)
                produtoEditando.Nome = txtNome.Text.Trim();
                produtoEditando.Quantidade = (int)nudQuantidade.Value;
                produtoEditando.PrecoVenda = preco;
                produtoEditando.idCategoria = categoriaSelecionada.IdCategoria;

                // Você precisará chamar um método de ATUALIZAÇÃO aqui
                // Ex: var dao = new ProdutoDAO(); dao.Atualizar(produtoEditando);

                MessageBox.Show("Produto atualizado.");
                this.Close();
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            nudQuantidade.Value = 0;
            txtPreco.Clear();
            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}