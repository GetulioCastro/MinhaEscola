using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhaEscola
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            listaGrid();

        }


        private void btnGravar_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K8FS7AT;Initial Catalog=Escola;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Login (nome, email, senha) values (@nome, @email, @senha)", con);
                cmd.Parameters.AddWithValue("@nome", txbNome.Text);
                cmd.Parameters.AddWithValue("@email", txbEmail.Text);
                cmd.Parameters.AddWithValue("@senha", txbSenha.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados gravados com sucesso!");

                txbNome.Text = "";
                txbEmail.Text = "";
                txbSenha.Text = "";

                txbNome.Focus();

            }
            listaGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K8FS7AT;Initial Catalog=Escola;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update login set nome = @nome, email = @email, senha = @senha where id = @id", con);
                cmd.Parameters.AddWithValue("@id", txbId.Text);
                cmd.Parameters.AddWithValue("@nome", txbNome.Text);
                cmd.Parameters.AddWithValue("@email", txbEmail.Text);
                cmd.Parameters.AddWithValue("@senha", txbSenha.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados alterados com sucesso!");

                txbNome.Text = "";
                txbEmail.Text = "";
                txbSenha.Text = "";

                txbNome.Focus();
            }

            listaGrid();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K8FS7AT;Initial Catalog=Escola;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                if (MessageBox.Show("Tem certeza que quer apagar este item?", "APAGAR!",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete login where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", txbId.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados apagados com sucesso!");

                    txbNome.Text = "";
                    txbEmail.Text = "";
                    txbSenha.Text = "";

                    txbNome.Focus();

                }

            }
            listaGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult obj = MessageBox.Show("Você tem certeza que deseja fechar o formulário?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (obj == DialogResult.Yes)
            {
                Close();
            }
        }

        public void listaGrid()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K8FS7AT;Initial Catalog=Escola;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select id as ID, nome as Nome, email as EMail, senha as Senha from login", con);
                //cmd.Parameters.AddWithValue("@id", txbId.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLista.DataSource = dt;
            }
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K8FS7AT;Initial Catalog=Escola;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                if (e.RowIndex >= 0)
                {
                    con.Open();

                    DataGridViewRow row = this.dgvLista.Rows[e.RowIndex];

                    txbId.Text = row.Cells["ID"].Value.ToString();
                    txbNome.Text = row.Cells["Nome"].Value.ToString();
                    txbEmail.Text = row.Cells["EMail"].Value.ToString();
                    txbSenha.Text = row.Cells["Senha"].Value.ToString();

                }
            }
        }
    }
}

