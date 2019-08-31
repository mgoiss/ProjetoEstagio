using BLL;
using DAL;
using Modelo;
using System;
using System.Windows.Forms;


namespace GUI
{
    public partial class frmCadastroSubCategoria : Form
    {
        public String operacao;
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }

        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            //Iniciando os dados do combobox Categoria
            cbxCodCat.DataSource = DALCategoria.CarregarGrid();
            cbxCodCat.ValueMember = "categoria_cod";
            cbxCodCat.DisplayMember = "categoria_nome";
            cbxCodCat.SelectedIndex = -1;

            dgvSubCategoria.DataSource = DALSubCategoria.CarregarGrid();
        }
    }
}