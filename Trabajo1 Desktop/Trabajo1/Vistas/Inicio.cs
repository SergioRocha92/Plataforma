using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo1.DAOs;
using Trabajo1.Vistas;

namespace Trabajo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            var usuario = txtUsuario.Text;
            var password = txtPassword.Text;

            UsuariosDAO.val1();

            if (UsuariosDAO.buscarUsuario(usuario, password))
            {
                this.Hide();
                var princ = new Programa();
                princ.Show();
            }
            else
            {
                MessageBox.Show("credenciales incorrectas", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
