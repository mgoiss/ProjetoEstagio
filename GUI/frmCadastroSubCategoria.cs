using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void alterarbotoes(int op)
        {
            btnInserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnBuscar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            txtSubCatNome.Enabled = false;

            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnBuscar.Enabled = true;
                cbxCodCat.Enabled = false;
            }

            if (op == 2)
            {
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                txtSubCatNome.Enabled = true;
                cbxCodCat.Enabled = true;
            }
            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            this.alterarbotoes(1);
            /*Como subcategoria pertence a categoria, protanto para poder fazer o cadastro de uma subcategoria, teremos que associa-la 
             * a uma categoria e esseme´todo abaixo é justamente para poder trazer todos os dados de categoria para dentro de uma combobox
             e tornar possível essa associação. */
            DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);
            BLLCategoria bll = new BLLCategoria(conexaoBD);
            cbxCodCat.DataSource = bll.LocalizarDados("");
            cbxCodCat.DisplayMember = "categoria_nome";
            cbxCodCat.ValueMember = "categoria_cod";
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.alterarbotoes(2);
            this.operacao = "inserir";
        }
    }
}
