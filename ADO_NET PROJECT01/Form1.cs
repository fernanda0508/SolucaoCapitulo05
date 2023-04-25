using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NET_PROJECT01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.
            ConnectionStrings["CS_ADO_NET"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into FORNECEDORES(nome, cnpj)" +
                " values (@nome, @cnpj)";
            command.Parameters.AddWithValue("@nome", txtNome.Text);
            command.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            MessageBox.Show("Fornecedor registrado com sucesso");
        }
    }
}
