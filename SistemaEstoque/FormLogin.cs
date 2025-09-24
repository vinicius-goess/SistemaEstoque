using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySqlConnector;
using MySql.Data.MySqlClient;


namespace SistemaEstoque
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        
        public bool ValidarLogin(string login, string senha)
        {
            try
            {
                using (var conn = ConexaoMySQL.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM usuario WHERE login=@login AND senha=@senha";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtSenha.Text;

            if (user == "admin" && pass == "123")
            {
                MessageBox.Show("Login efetuado com sucesso, clique em OK para continuar!.");
                this.Hide();
                using (var menu = new FormMenu())
                {
                    menu.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
