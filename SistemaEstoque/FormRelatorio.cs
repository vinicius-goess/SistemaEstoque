using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstoque
{
    public partial class FormRelatorio : Form
    {
        public FormRelatorio()
        {
            InitializeComponent();
            GerarRelatorio();
        }

        private void GerarRelatorio()
        {
            var baixos = Banco.Produtos.Where(p => p.Quantidade < 5).ToList();
            dgvRelatorio.DataSource = baixos;
            decimal total = Banco.Produtos.Sum(p => p.Quantidade * p.Preco);
            lblValorTotal.Text = $"Valor total em estoque: {total:C2}";
        }

        private void btnAtualizarRel_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }
    }
}
