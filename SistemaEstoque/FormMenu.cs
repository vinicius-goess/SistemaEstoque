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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            using (var f = new FormCadastro())
                f.ShowDialog();
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            using (var f = new FormListagem())
                f.ShowDialog();
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            using (var f = new FormSaida())
                f.ShowDialog();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            using (var f = new FormRelatorio())
                f.ShowDialog();
        }

        private void btnSairMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
