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
    public partial class frmBuscaCategoria : Form
    {
        public int codigo = 0;
        public frmBuscaCategoria()
        {
            InitializeComponent();
        }

        /*Este método é para o programa reconhecer o duplo click dentro do grid */
        private void dgvConsultaCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvCategoria.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }

        }

        /*Esse é o método do botão buscar dentro da tela de consulta categoria. Falta melhora-lo. Por exemplo,
         quando eu clico em buscar, ele nãio filtra apenas o que estou buscando. Ele traz todos os dados registrados no banco.
         O ideal é buscar apenas o que o usuário digitou.*/
        private void btnBuscaCategoria_Click(object sender, EventArgs e)
        {
            DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);
            BLLCategoria bll = new BLLCategoria(conexaoBD);
            dgvCategoria.DataSource = bll.LocalizarDados(txtConsultaCategoria.Text);
        }
     
        private void frmBuscaCategoria_Load(object sender, EventArgs e)
        {
        

        }
        //Esse é criado automaticamente ao executar o comando de buscar.
        private void frmBuscaCategoria_Load_1(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'projetoEstagioDataSet.categoria'. Você pode movê-la ou removê-la conforme necessário.
            this.categoriaTableAdapter.Fill(this.projetoEstagioDataSet.categoria);
            btnBuscaCategoria_Click(sender, e);
            dgvCategoria.Columns[0].HeaderText = "Código";
            dgvCategoria.Columns[0].Width = 46;
            dgvCategoria.Columns[1].HeaderText = "Categoria";
            dgvCategoria.Columns[1].Width = 600;
        }
    }
}
