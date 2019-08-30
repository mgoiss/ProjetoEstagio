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
    public partial class frmBuscaSubCategoria : Form
    {
        public int codigo = 0;
        public frmBuscaSubCategoria()
        {
            InitializeComponent();
        }

        private void dgvSubCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvSubCategoria.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        private void btnBuscaSubCategoria_Click(object sender, EventArgs e)
        {
            DALConexao conexaoBD = new DALConexao(ConexaoBD.StringConexaoBD);
            BLLSubCategoria bll = new BLLSubCategoria(conexaoBD);
            dgvSubCategoria.DataSource = bll.LocalizarDados(txtConsultaSubCategoria.Text);
        }

        private void frmBuscaSubCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'projetoEstagioDataSet.subcategoria'. Você pode movê-la ou removê-la conforme necessário.
            this.subcategoriaTableAdapter.Fill(this.projetoEstagioDataSet.subcategoria);
            btnBuscaSubCategoria_Click(sender, e);         
            dgvSubCategoria.Columns[0].HeaderText = "Código da SubCategoria";
            dgvSubCategoria.Columns[0].Width = 46;
            dgvSubCategoria.Columns[1].HeaderText = "Nome da SubCategoria";
            dgvSubCategoria.Columns[1].Width = 600;
            dgvSubCategoria.Columns[2].HeaderText = "Código da Categoria";
            dgvSubCategoria.Columns[2].Width = 46;
        }
    }
}
