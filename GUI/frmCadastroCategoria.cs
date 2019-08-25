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

        /*Esse método altera botões é para ativar/desativar os botões do formulário de cadastro. Na execução vocês irão entender melhor. 
         O código está dentro do campo, #region, logo abaixo. */
        #region
        public void alterarbotoes(int op)
        {
            btnInserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnBuscar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNome.Enabled = false;

            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnBuscar.Enabled = true;
            }

            if (op == 2)
            {
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                txtNome.Enabled = true;
            }
            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
        #endregion

        /*Esse método é para limpar as telas sempre que uma ação for executada na tela. Por exemplo, os campos serão limpos após  
         a finalização do cadastro. */
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }
        //Esse método é para o form iniciar com os botões desativados.
        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alterarbotoes(1);
        }

        //Método do botão inserir (Método criado na camada DAL)
        private void btnInserir_Click(object sender, EventArgs e)
        {
            /*operação é uma variável global.Ela está sendo tratada em um método lá em baixo e sendo chamada aqui e no campo alterar.
             Vou explicar melhor no método em que ela está sendo trabalhada. */
            this.operacao = "inserir";
            /*método alterarbotões sendo chamado. O número dentro do parêntese é o parâmetro que passei para ele executar a segunda opção
             que estã lá em cima descrita no método. */
            this.alterarbotoes(2);
        }

        //Método do botão alterar (Método foi criado na camada DAL)
        private void btnAlterar_Click(object sender, EventArgs e)
        {

            this.operacao = "alterar";
            this.alterarbotoes(2);

        }

        //Método do botão salvar (Método criado na camada DAL)
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try

            {
                /*Aqui eu chamei a classe MCategoria que está na camada Modelo. Caso eu não chamasse ela aqui, eu não iria conseguir acessar
               os atributos da classe. A classe está sendo instanciada pela varíavel modelo, que está guardando todos os atributos da 
               classe.*/
                MCategoria modelo = new MCategoria();
                modelo.NomeCategoria = txtNome.Text;
                //Aqui eu chamo a classe DALConexao para poder abrir o acesso à base de dados.
                DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);
                /*Aqui é chamado a BLL para poder fazer alguns tratamentos e ela recebe como parâmetro conexãoBD que é a string de 
                 conexão já que ela trabalhada em conjunto com as camadas Modelo e Dal.*/
                BLLCategoria bll = new BLLCategoria(conexaoBD);
                /*Aqui é onde está sendo tratada a variável. Se o usuário clicar em inserir, irá apresentar a mensagem abaixo.
                 se apresentar algum erro, irá cair na excessão lá em baixo. No catch. Se for alteração de cadastro, irá retornar 
                 a mensagem de alteração que está no else.*/
                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro realizado com sucesso!" + modelo.CodigoCategoria.ToString());
                }
                else
                {
                    modelo.CodigoCategoria = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso!");
                }
                this.LimpaTela();
                this.alterarbotoes(1);
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
            this.LimpaTela();
            this.alterarbotoes(1);
        }

        //Método do botão excluir (Método criado na camada DAL)
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui ele executa um diálogo perguntando se o usuário deseja ou não excluir o registro.
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Atenção", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    /*Caso "sim", é aberto a conexão com o banco e executado o método de excluir. */
                    DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);
                    BLLCategoria bll = new BLLCategoria(conexaoBD);
                    //Método de excluir sendo chamado.
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimpaTela();
                    this.alterarbotoes(1);
                }

            }
            catch
            {
                //Caso apresente algum erro. Será retornado esta mensagem.
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outro local");
                this.alterarbotoes(3);
            }
        }

        //Este método foi criado apenas para a tela iniciar com alguns botões desativados.
        private void frmCadastroCategoria_Load_1(object sender, EventArgs e)
        {
            this.alterarbotoes(1);
        }

        /*Esse é o método para carregar os dados. Quando o usuário clicar lá no grid em um registro, os dados do cadastro serão
         carregados na tela de cadastro para poder ser alterado ou excluído.*/
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscaCategoria f = new frmBuscaCategoria();
            f.ShowDialog();
            /*Quando clicar em buscar irá carregar a tela de busa que está sendo instanciada no código acima pela varíavel f
             e assim que carregar o GRID e que o usuário fizer uma ação (clicar duas vezes em um registro), será executado esse
             if abaixo. Código é uma variável que criei na tela do GRID e ele recebe o ID. No grid eu coloquei para registrar 
             de 1 pra cima. Então, tudo que for de ferente de 0 ele executa o comando dentro do if.*/
            if (f.codigo !=0)
            {
                /*Abre a conexão com o banco. Já expliquei lá em cima a função da DAL, BLL e MCategoria. Sobre o pq elas são chamadas.
                 E quando o usuário faz o duplo click, os dados são trazido para esta tela de cadastro.*/
                DALConexao conexao = new DALConexao(ConexaoBD.StringConexaoBD);
                BLLCategoria bll = new BLLCategoria(conexao);
                MCategoria modelo = bll.CarregarDados(f.codigo);
                txtCodigo.Text = modelo.CodigoCategoria.ToString();
                txtNome.Text = modelo.NomeCategoria;
                this.alterarbotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alterarbotoes(1);
            }
            //Dispose serve para fechar as janelas quando abre uma nova. Isso deixa o programa mais otimizado.
            f.Dispose();
        }
    }
    
}
