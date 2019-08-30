using BLL;
using DAL;
using Modelo;
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
        public void LimpaTela()
        {
            txtNomeSubCategoria.Clear();
            txtCodSubCategoria.Clear();
        }
        public void alterarbotoes(int op)
        {
            btnInserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnBuscar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNomeSubCategoria.Enabled = false;

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
                txtNomeSubCategoria.Enabled = true;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscaSubCategoria f = new frmBuscaSubCategoria();
            f.ShowDialog();
      
            if (f.codigo != 0)
            {
          
                DALConexao conexao = new DALConexao(ConexaoBD.StringConexaoBD);
                BLLSubCategoria bll = new BLLSubCategoria(conexao);
                MSubCategoria modelo = bll.CarregarDados(f.codigo);
                txtCodSubCategoria.Text = modelo.subCodigoCategoria.ToString();
                txtNomeSubCategoria.Text = modelo.subNomeCategoria;
                this.alterarbotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alterarbotoes(1);
            }
        
            f.Dispose();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.alterarbotoes(2);
            this.operacao = "alterar";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try

            {
                MSubCategoria modelo = new MSubCategoria();
                modelo.subNomeCategoria = txtNomeSubCategoria.Text;
                modelo.CodigoCategoria = Convert.ToInt32(cbxCodCat.SelectedValue);

                DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);

                BLLSubCategoria bll = new BLLSubCategoria(conexaoBD);

                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro realizado com sucesso!" + modelo.subCodigoCategoria.ToString());
                }
                else
                {
                    modelo.subCodigoCategoria = Convert.ToInt32(txtCodSubCategoria.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso!");
                }
                this.LimpaTela();
                this.alterarbotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.alterarbotoes(1);
            this.LimpaTela();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Atenção", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                        
                    DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);
                    BLLSubCategoria bll = new BLLSubCategoria(conexaoBD);
                    
                    bll.Excluir(Convert.ToInt32(txtCodSubCategoria.Text));
                    this.LimpaTela();
                    this.alterarbotoes(1);
                }

            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outro local");
                this.alterarbotoes(3);
            }
        }
    }
   

 
}