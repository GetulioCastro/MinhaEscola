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
    public partial class frmEscola : Form
    {
        public frmEscola()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult obj = MessageBox.Show("Você tem certeza que deseja encerrar o programa?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (obj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult obj = MessageBox.Show("Você tem certeza que deseja encerrar o programa?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (obj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login formulario = new Login();
            formulario.ShowDialog();
        }
    }
}
