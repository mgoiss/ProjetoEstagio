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
    public partial class frmCadastroCategoria : Form
    {
        public String operacao;
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        //Este método foi criado apenas para a tela iniciar com alguns botões desativados.
        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            Alterarbotoes(1);
        }

        /*Esse método altera botões é para ativar/desativar os botões do formulário de cadastro. Na execução vocês irão entender melhor. 
         O código está dentro do campo, #region, logo abaixo. */
        #region
        public void Alterarbotoes(int op)
        {
            btnAlterar.Enabled = false;
            btnBuscar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Visible = false;

            if (op == 1) //Padrão
            {
                btnSalvar.Text = "Cadastrar";
                btnBuscar.Enabled = true;
                btnSalvar.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                //Carregando os dados
                dgvCategoria.DataSource = BLLCategoria.CarregarGrid();
            }

            if (op == 2) //Atualizar
            {
                btnSalvar.Text = "Atualizar";
                btnSalvar.Enabled = true;
                btnCancelar.Visible = true;
            }
        }
        #endregion

        /*Esse método é para limpar as telas sempre que uma ação for executada na tela. Por exemplo, os campos serão limpos após  
         a finalização do cadastro. */
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            Alterarbotoes(1);
        }

        //Método do botão alterar (Método foi criado na camada DAL)
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.RowCount != 0)
            {
                //Pegando os dados diretamente do DataGrid
                txtCodigo.Text = dgvCategoria.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvCategoria.CurrentRow.Cells[1].Value.ToString();
                //Alterando as informações 
                Alterarbotoes(2);
            }
        }
        //Método do botão salvar (Método criado na camada DAL)
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try

            {
                /*Aqui eu chamei a classe MCategoria que está na camada Modelo. Caso eu não chamasse ela aqui, eu não iria conseguir acessar
               os atributos da classe. A classe está sendo instanciada pela varíavel modelo, que está guardando todos os atributos da 
               classe.*/
                MCategoria modelo = new MCategoria(txtNome.Text);

                //Analisando se o usuário deseja atualizar ou salvar um novo registro
                if (btnSalvar.Text != "Atualizar")
                {
                    BLLCategoria.Incluir(modelo);
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }
                else
                {
                    modelo.CodigoCategoria = Convert.ToInt32(txtCodigo.Text); //Pegando o ID
                    BLLCategoria.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso!");
                }
                LimpaTela();
            }
            /* A mensagem de erro já está perfeita. Com esse método ele já idenifica o tipo de erro que está causando e retorna 
             para o usuário. Só precisa apenas aprimorar. Colocar um ícone e etc.*/
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }
        //Método do botão cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }
        //Método do botão excluir (Método criado na camada DAL)
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui ele executa um diálogo perguntando se o usuário deseja ou não excluir o registro.
                if (MessageBox.Show("Deseja excluir o registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    /*Caso "sim", é aberto a conexão com o banco e executado o método de excluir. */
                    //Método de excluir sendo chamado.
                    BLLCategoria.Excluir(int.Parse(dgvCategoria.CurrentRow.Cells[0].Value.ToString()));
                    LimpaTela();
                }
            }
            catch
            {
                //Caso apresente algum erro. Será retornado esta mensagem.
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outro local");
                Alterarbotoes(1);
            }
        }
        /*Esse é o método para buscar os dados.*/
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvCategoria.DataSource = BLLCategoria.LocalizarDados(txtConsultaCategoria.Text);
        }
    }
    
}
