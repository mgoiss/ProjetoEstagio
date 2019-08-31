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

        /*Esse método altera botões é para ativar/desativar os botões do formulário de cadastro. Na execução vocês irão entender melhor. 
         O código está dentro do campo, #region, logo abaixo. */
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
                dgvSubCategoria.DataSource = DALSubCategoria.CarregarGrid();
            }

            if (op == 2) //Atualizar
            {
                btnSalvar.Text = "Atualizar";
                btnSalvar.Enabled = true;
                btnCancelar.Visible = true;
            }
        }

        /*Esse método é para limpar as telas sempre que uma ação for executada na tela. Por exemplo, os campos serão limpos após  
         a finalização do cadastro. */
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtSubCatNome.Clear();
            txtConsultaSubCategoria.Clear();
            cbxCodCat.SelectedIndex = -1;
            Alterarbotoes(1);
        }

        //Evento load do formulario
        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            //Iniciando os dados do combobox Categoria
            cbxCodCat.DataSource = DALCategoria.CarregarGrid();
            cbxCodCat.ValueMember = "categoria_cod";
            cbxCodCat.DisplayMember = "categoria_nome";

            Alterarbotoes(1);
            dgvSubCategoria.DataSource = DALSubCategoria.CarregarGrid();
        }

        //Evento click botão salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                /*Aqui eu chamei a classe MCategoria que está na camada Modelo. Caso eu não chamasse ela aqui, eu não iria conseguir acessar
               os atributos da classe. A classe está sendo instanciada pela varíavel modelo, que está guardando todos os atributos da 
               classe.*/
                MSubCategoria modelo = new MSubCategoria(txtSubCatNome.Text, int.Parse(cbxCodCat.SelectedValue.ToString()));

                //Analisando se o usuário deseja atualizar ou salvar um novo registro
                if (btnSalvar.Text != "Atualizar")
                {
                    BLLSubCategoria.Incluir(modelo);
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }
                else
                {
                    modelo.subCodigoCategoria = int.Parse(txtCodigo.Text); //Pegando o ID
                    BLLSubCategoria.Alterar(modelo);
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
        //Evento click cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }
        //Esse evento procura procura um registro no banco
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSubCategoria.DataSource = BLLSubCategoria.LocalizarDados(txtConsultaSubCategoria.Text);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        //Método do botão alterar (Método foi criado na camada DAL)
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvSubCategoria.RowCount != 0)
            {
                //Pegando os dados diretamente do DataGrid
                txtCodigo.Text = dgvSubCategoria.CurrentRow.Cells[0].Value.ToString();
                txtSubCatNome.Text = dgvSubCategoria.CurrentRow.Cells[1].Value.ToString();
                cbxCodCat.SelectedValue = dgvSubCategoria.CurrentRow.Cells[2].Value.ToString();                
                //Alterando as informações 
                Alterarbotoes(2);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui ele executa um diálogo perguntando se o usuário deseja ou não excluir o registro.
                if (MessageBox.Show("Deseja excluir o registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    /*Caso "sim", é aberto a conexão com o banco e executado o método de excluir. */
                    //Método de excluir sendo chamado.
                    BLLSubCategoria.Excluir(int.Parse(dgvSubCategoria.CurrentRow.Cells[0].Value.ToString()));
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
    }
}