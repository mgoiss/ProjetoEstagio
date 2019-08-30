namespace GUI
{
    partial class frmBuscaCategoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtConsultaCategoria = new System.Windows.Forms.TextBox();
            this.btnBuscaCategoria = new System.Windows.Forms.Button();
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            this.categoriacodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categorianomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projetoEstagioDataSet = new GUI.ProjetoEstagioDataSet();
            this.categoriaTableAdapter = new GUI.ProjetoEstagioDataSetTableAdapters.categoriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoEstagioDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(12, 9);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtConsultaCategoria
            // 
            this.txtConsultaCategoria.Location = new System.Drawing.Point(12, 25);
            this.txtConsultaCategoria.Name = "txtConsultaCategoria";
            this.txtConsultaCategoria.Size = new System.Drawing.Size(672, 20);
            this.txtConsultaCategoria.TabIndex = 1;
            // 
            // btnBuscaCategoria
            // 
            this.btnBuscaCategoria.Location = new System.Drawing.Point(690, 25);
            this.btnBuscaCategoria.Name = "btnBuscaCategoria";
            this.btnBuscaCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaCategoria.TabIndex = 2;
            this.btnBuscaCategoria.Text = "Buscar";
            this.btnBuscaCategoria.UseVisualStyleBackColor = true;
            this.btnBuscaCategoria.Click += new System.EventHandler(this.btnBuscaCategoria_Click);
            // 
            // dgvCategoria
            // 
            this.dgvCategoria.AllowUserToAddRows = false;
            this.dgvCategoria.AllowUserToDeleteRows = false;
            this.dgvCategoria.AutoGenerateColumns = false;
            this.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoriacodDataGridViewTextBoxColumn,
            this.categorianomeDataGridViewTextBoxColumn});
            this.dgvCategoria.DataSource = this.categoriaBindingSource;
            this.dgvCategoria.Location = new System.Drawing.Point(12, 51);
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.ReadOnly = true;
            this.dgvCategoria.Size = new System.Drawing.Size(672, 285);
            this.dgvCategoria.TabIndex = 3;
            this.dgvCategoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaCategoria_CellDoubleClick);
            // 
            // categoriacodDataGridViewTextBoxColumn
            // 
            this.categoriacodDataGridViewTextBoxColumn.DataPropertyName = "categoria_cod";
            this.categoriacodDataGridViewTextBoxColumn.HeaderText = "categoria_cod";
            this.categoriacodDataGridViewTextBoxColumn.Name = "categoriacodDataGridViewTextBoxColumn";
            this.categoriacodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categorianomeDataGridViewTextBoxColumn
            // 
            this.categorianomeDataGridViewTextBoxColumn.DataPropertyName = "categoria_nome";
            this.categorianomeDataGridViewTextBoxColumn.HeaderText = "categoria_nome";
            this.categorianomeDataGridViewTextBoxColumn.Name = "categorianomeDataGridViewTextBoxColumn";
            this.categorianomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriaBindingSource
            // 
            this.categoriaBindingSource.DataMember = "categoria";
            this.categoriaBindingSource.DataSource = this.projetoEstagioDataSet;
            // 
            // projetoEstagioDataSet
            // 
            this.projetoEstagioDataSet.DataSetName = "ProjetoEstagioDataSet";
            this.projetoEstagioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoriaTableAdapter
            // 
            this.categoriaTableAdapter.ClearBeforeFill = true;
            // 
            // frmBuscaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCategoria);
            this.Controls.Add(this.btnBuscaCategoria);
            this.Controls.Add(this.txtConsultaCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Name = "frmBuscaCategoria";
            this.Text = "frmBuscaCategoria";
            this.Load += new System.EventHandler(this.frmBuscaCategoria_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoEstagioDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtConsultaCategoria;
        private System.Windows.Forms.Button btnBuscaCategoria;
        private System.Windows.Forms.DataGridView dgvCategoria;
        private ProjetoEstagioDataSet projetoEstagioDataSet;
        private System.Windows.Forms.BindingSource categoriaBindingSource;
        private ProjetoEstagioDataSetTableAdapters.categoriaTableAdapter categoriaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriacodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categorianomeDataGridViewTextBoxColumn;
    }
}